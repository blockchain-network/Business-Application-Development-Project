using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ViewRegisteredEvent : System.Web.UI.Page
    {
        EventRegistrationDetails aEvent = new EventRegistrationDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            List<EventRegistrationDetails> upcomingEventList = new List<EventRegistrationDetails>();
            upcomingEventList = aEvent.getUpcomingRegisteredEvent(int.Parse(Session["custID"].ToString()));
            gv_UpcomingEvents.DataSource = upcomingEventList;
            gv_UpcomingEvents.DataBind();

            List<EventRegistrationDetails> pastEventList = new List<EventRegistrationDetails>();
            pastEventList = aEvent.getPastRegisteredEvent(int.Parse(Session["custID"].ToString()));
            gv_PastEvents.DataSource = pastEventList;
            gv_PastEvents.DataBind();

        }

        protected void gv_UpcomingEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_UpcomingEvents.SelectedRow;

            string eventId = row.Cells[0].Text;

            Response.Redirect("CustomerEventDetails.aspx?EventID=" + eventId);
        }

        protected void gv_PastEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_PastEvents.SelectedRow;

            string eventId = row.Cells[0].Text;

            Response.Redirect("CustomerEventDetails.aspx?EventID=" + eventId);
        }

        protected void gv_UpcomingEvents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            RegisterEvent aRegistration = new RegisterEvent();
            GridViewRow row = (GridViewRow)gv_UpcomingEvents.Rows[e.RowIndex];
            string eventId = row.Cells[0].Text.ToString();
            string custID = Session["custID"].ToString();
            result = aRegistration.DeleteRegistration(Convert.ToInt32(custID), Convert.ToInt32(eventId));

            if (result > 0)
            {
                Response.Write("<script>alert('Registration have been deleted successfully');</script>");
                Response.Redirect("ViewRegisteredEvent.aspx");
            }
            else
            {
                Response.Write("<script>alert('Unsuccessful in deleting the registration');</script>");
            }
        }
    }
}