using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CustomerViewEvents : System.Web.UI.Page
    {
        Event aEvent = new Event();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            List<Event> upcomingEventList = new List<Event>();
            upcomingEventList = aEvent.getUpcomingEvent();
            gv_UpcomingEvents.DataSource = upcomingEventList;
            gv_UpcomingEvents.DataBind();
        }

        protected void gv_UpcomingEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_UpcomingEvents.SelectedRow;

            string eventId = row.Cells[0].Text;

            Response.Redirect("CustomerEventDetails.aspx?EventID=" + eventId);
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            List<Event> filteredEventList = new List<Event>();
            List<Event> upcomingEventList = new List<Event>();
            upcomingEventList = aEvent.getUpcomingEvent();
            foreach (var info in upcomingEventList)
            {
                if (info.eventTitle == tb_Search.Text)
                {
                    filteredEventList.Add(info);
                    gv_UpcomingEvents.DataSource = filteredEventList;
                    gv_UpcomingEvents.DataBind();
                }
                else
                {
                    gv_UpcomingEvents.DataSource = filteredEventList;
                    gv_UpcomingEvents.DataBind();
                }
            }
        }

        protected void btn_Filter_Click(object sender, EventArgs e)
        {
            List<Event> filteredEventList = new List<Event>();
            List<Event> upcomingEventList = new List<Event>();
            upcomingEventList = aEvent.getUpcomingEvent();
            foreach (var info in upcomingEventList)
            {
                if (info.category == ddl_Category.SelectedValue)
                {
                    filteredEventList.Add(info);
                    gv_UpcomingEvents.DataSource = filteredEventList;
                    gv_UpcomingEvents.DataBind();
                }
                else
                {
                    gv_UpcomingEvents.DataSource = filteredEventList;
                    gv_UpcomingEvents.DataBind();
                }
            }
        }

        protected void btn_SearchAll_Click(object sender, EventArgs e)
        {
            List<Event> filteredEventList = new List<Event>();
            List<Event> upcomingEventList = new List<Event>();
            upcomingEventList = aEvent.getUpcomingEvent();
            foreach (var info in upcomingEventList)
            {
                if (info.category == ddl_Category.SelectedValue && info.eventTitle == tb_Search.Text)
                {
                    filteredEventList.Add(info);
                    gv_UpcomingEvents.DataSource = filteredEventList;
                    gv_UpcomingEvents.DataBind();
                }
                else
                {
                    gv_UpcomingEvents.DataSource = filteredEventList;
                    gv_UpcomingEvents.DataBind();
                }
            }
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            List<Event> upcomingEventList = new List<Event>();
            upcomingEventList = aEvent.getUpcomingEvent();
            gv_UpcomingEvents.DataSource = upcomingEventList;
            gv_UpcomingEvents.DataBind();
        }
    }
}