using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminEventDetails : System.Web.UI.Page
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
            lbl_Pax.Text = events.pax.ToString();

            string location = events.location.ToString().Replace(" ", "");

            string url = "https://www.google.com/maps/embed/v1/place?key=AIzaSyATJvsFJHxUwDi2afigP1yau3Vzvep24l4&&q=";
            string urllocation = url + location;
            lbl_Location.Text = "<iframe width='450' height='250' frameborder= '0' style='border:0' src=" + urllocation + "></iframe>";
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewEvents.aspx");
        }

        protected void btn_RegistrationData_Click(object sender, EventArgs e)
        {
            string eventId = Request.QueryString["eventId"].ToString();
            Response.Redirect("AdminViewRegistrationData.aspx?EventID=" + eventId);
        }
    }
}