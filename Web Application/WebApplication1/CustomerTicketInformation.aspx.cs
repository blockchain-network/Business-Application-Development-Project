using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Drawing.Imaging;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;


namespace WebApplication1
{
    public partial class CustomerTicketInformation : System.Web.UI.Page
    {
        RegisterEvent ticketinfo = null;
        Event events = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterEvent aRegistration = new RegisterEvent();
            Event aEvent = new Event();
            string eventId = Session["eventId"].ToString();
            string custID = Session["custID"].ToString();
            ticketinfo = aRegistration.getTicketInformation(Convert.ToInt32(eventId), Convert.ToInt32(custID));
            events = aEvent.getEventDetails(Convert.ToInt32(eventId));

            lbl_Title.Text = ticketinfo.eventTitle;
            lbl_eventTitle.Text = ticketinfo.eventTitle;
            lbl_custFname.Text = ticketinfo.custFname;
            lbl_custLname.Text = ticketinfo.custLname;
            lbl_Pax.Text = ticketinfo.pax.ToString();
            lbl_StartDate.Text = events.startDate.ToString("d");
            lbl_EndDate.Text = events.endDate.ToString("d");
            lbl_StartTime.Text = events.startTime.ToString();
            lbl_EndTime.Text = events.endTime.ToString();
            lbl_Location1.Text = events.location;
            string location = events.location.ToString().Replace(" ", "");

            string url = "https://www.google.com/maps/embed/v1/place?key=AIzaSyATJvsFJHxUwDi2afigP1yau3Vzvep24l4&&q=";
            string urllocation = url + location;
            lbl_Location.Text = "<iframe width='450' height='250' frameborder= '0' style='border:0' src=" + urllocation + "></iframe>";


            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var MyData = QG.CreateQrCode(eventId + custID, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            Bitmap bitmap = code.GetGraphic(50);
            
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage); //Get Base64
            QRcode.ImageUrl = "data:image/png;base64," + SigBase64;
            img.Save(Server.MapPath("Images/") + eventId + custID  + ".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            string eventId = Session["eventId"].ToString();
            string custID = Session["custID"].ToString();
            string filePath = Server.MapPath("Images\\") + eventId + custID + ".Jpeg";
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Event" + eventId + custID + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            table.RenderControl(htmlTextWriter);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document Doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            HTMLWorker htmlparser = new HTMLWorker(Doc);
            PdfWriter.GetInstance(Doc, Response.OutputStream);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(filePath);
            img.ScalePercent(10);
            Doc.Open();
            htmlparser.Parse(stringReader);
            Doc.Add(img);
            Doc.Close();
            Response.Write(Doc);
            Response.End();
        }
    }
}