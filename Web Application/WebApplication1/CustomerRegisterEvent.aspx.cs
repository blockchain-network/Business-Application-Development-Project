using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Net.Mail;

using System.Drawing;
using System.Drawing.Imaging;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Data;

namespace WebApplication1
{
    public partial class CustomerRegisterEvent : System.Web.UI.Page
    {
        Event events = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Event aEvent = new Event();
            string eventId = Request.QueryString["eventId"].ToString();
            events = aEvent.getEventDetails(Convert.ToInt32(eventId));

            lbl_Title.Text = events.eventTitle;
            lbl_eventTitle.Text = events.eventTitle;
            lbl_eventDescription.Text = events.eventDescription;
            lbl_StartDate.Text = events.startDate.ToString("d");
            lbl_EndDate.Text = events.endDate.ToString("d");
            lbl_StartTime.Text = events.startTime.ToString();
            lbl_EndTime.Text = events.endTime.ToString();
            lbl_Category.Text = events.category;
            Event_Img.ImageUrl = "~\\Images\\" + events.eventImg;
            string location = events.location.ToString().Replace(" ", "");

            string url = "https://www.google.com/maps/embed/v1/place?key=AIzaSyATJvsFJHxUwDi2afigP1yau3Vzvep24l4&&q=";
            string urllocation = url + location;
            lbl_Location.Text = "<iframe width='450' height='250' frameborder= '0' style='border:0' src=" + urllocation + "></iframe>";
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            string eventId = Request.QueryString["eventId"].ToString();
            Response.Redirect("CustomerEventDetails.aspx?EventID=" + eventId);
        }

        protected void btn_Register_Click(object sender, EventArgs e)
        {
            int result = 0;
            string custID = Session["custID"].ToString();
            string custFname = Session["custFname"].ToString();
            string custLname = Session["custLname"].ToString();
            string eventId = Request.QueryString["eventId"].ToString();
            Page.Validate();
            if (Page.IsValid)
            {
                RegisterEvent info = new RegisterEvent(int.Parse(custID), int.Parse(eventId), custFname, custLname, lbl_eventTitle.Text, int.Parse(tb_Pax.Text));
                result = info.RegisterEventInsert();
            }

            if (result > 0)
            {
                SendEmail();
                Response.Write("<script>alert('Successfully registered for an event.');</script>");

            }
            else { Response.Write("<script>alert('Unsuccessful in registering for an event');</script>"); }
        }

        RegisterEvent ticketinfo = null;
        Event bevents = null;
        protected void SendEmail()
        {
            RegisterEvent aRegistration = new RegisterEvent();
            Event aEvent = new Event();
            string eventId = Request.QueryString["eventId"].ToString();
            string custID = Session["custID"].ToString();
            ticketinfo = aRegistration.getTicketInformation(Convert.ToInt32(eventId), Convert.ToInt32(custID));
            bevents = aEvent.getEventDetails(Convert.ToInt32(eventId));

            PdfPTable table = new PdfPTable(2);
            table.AddCell("Event Title: ");
            table.AddCell(ticketinfo.eventTitle);

            table.AddCell("Name: ");
            table.AddCell(ticketinfo.custFname + " " + ticketinfo.custLname);

            table.AddCell("Number of pax attending: ");
            table.AddCell(ticketinfo.pax.ToString());

            table.AddCell("Date: ");
            table.AddCell(bevents.startDate.ToString("d") + " - " + bevents.endDate.ToString("d"));

            table.AddCell("Time: ");
            table.AddCell(bevents.startTime + " - " + bevents.endTime);

            table.AddCell("Location: ");
            table.AddCell(bevents.location);
            
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var MyData = QG.CreateQrCode(eventId + custID, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            Bitmap bitmap = code.GetGraphic(50);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage); //Get Base64
            img.Save(Server.MapPath("Images/") + eventId + custID + ".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

           
            using (MemoryStream memoryStream = new MemoryStream())
            {
                StringWriter stringWriter = new StringWriter();
                StringReader stringReader = new StringReader(stringWriter.ToString());
                Document Doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                HTMLWorker htmlparser = new HTMLWorker(Doc);
                PdfWriter.GetInstance(Doc, memoryStream);
                string filePath = Server.MapPath("Images\\") + eventId + custID + ".Jpeg";
                iTextSharp.text.Image aImg = iTextSharp.text.Image.GetInstance(filePath);
                aImg.ScalePercent(10);
                Doc.Open();
                htmlparser.Parse(stringReader);
                Doc.Add(table);
                Doc.Add(aImg);
                Doc.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("autoreply.oliviaevents@gmail.com");
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("autoreply.oliviaevents@gmail.com", "vuhy sifu ionp vaeg");

                mail.Subject = "Registration for " + lbl_eventTitle.Text;
                SmtpServer.EnableSsl = true;
                SmtpServer.Timeout = 40000;
                mail.Body = "Dear " + Session["custFname"].ToString() + " " + Session["custLname"].ToString() + ", \n\n" +
                    "Thank you for registering for " + lbl_eventTitle.Text + ". Your registration details have been confirmed and your e-ticket is attached. \n\n" + "Yours Sincerely, \n" + "OLIVIA Events Team";
                mail.To.Add(Session["custEmail"].ToString());
                mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "Event" + eventId + custID + ".pdf"));
                SmtpServer.Send(mail);
                mail.To.Clear();

            }
        }

        Event custEvents = null;
        RegisterEvent registration = null;
        protected void custValid_Pax_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Event aEvent = new Event();
            RegisterEvent aRegistration = new RegisterEvent();
            string eventId = Request.QueryString["eventId"].ToString();
            custEvents = aEvent.getEventDetails(Convert.ToInt32(eventId));
            registration = aRegistration.getSumOfPax(Convert.ToInt32(eventId));
            int event_pax = custEvents.pax;
            int current_pax = registration.pax;

            if (current_pax + Convert.ToInt32(tb_Pax.Text) > event_pax)
            {
                args.IsValid = false;
            } else
            {
                args.IsValid = true;
            }

        }
    }
}