using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminAddNewEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewEvents.aspx");
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string location = tb_Location.Text;
            location = location.Replace(" ", "");
            try
            {
                string url = "https://www.google.com/maps/embed/v1/place?key=AIzaSyATJvsFJHxUwDi2afigP1yau3Vzvep24l4&&q=";
                string urllocation = url + location;
                lbl_Location.Text = "<iframe width='450' height='250' frameborder= '0' style='border:0' src=" + urllocation + "></iframe>";
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Unable to find the location');</script>");
            }
        }
        protected void cv_StartDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToDateTime(tb_StartDate.Text) > DateTime.Now)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void cv_Time_ServerValidate(object source, ServerValidateEventArgs args)
        {
           if (tb_StartDate.Text == tb_EndDate.Text)
            {
                if (Convert.ToDateTime(tb_StartTime.Text) < Convert.ToDateTime(tb_EndTime.Text))
                {
                    args.IsValid = true;
                } else
                {
                    args.IsValid = false;
                }
            } else
            {
                args.IsValid = true;
            }
        }

        protected void btn_CreateEvent_Click(object sender, EventArgs e)
        {
            int result = 0;
            string image = "";

            if (FileUpload1.HasFile == true)
            {
                image = "Images\\" + FileUpload1.FileName;
            }

            Page.Validate();
            if (Page.IsValid)
            {
                Event info = new Event(tb_EventTitle.Text, tb_EventDescription.Text, FileUpload1.FileName, DateTime.Parse(tb_StartDate.Text),
                    DateTime.Parse(tb_EndDate.Text), TimeSpan.Parse(tb_StartTime.Text), TimeSpan.Parse(tb_EndTime.Text),
                    tb_Location.Text, ddl_Category.Text, int.Parse(tb_Pax.Text));
                result = info.EventInsert();
            }

            if (result > 0)
            {
                string saveimg = Server.MapPath(" ") + "\\" + image;
                FileUpload1.SaveAs(saveimg);
                Response.Write("<script>alert('Successfully added a new event.');</script>");
            }
            else { Response.Write("<script>alert('Unsuccessful in adding a new event');</script>"); }
        }
    }
}