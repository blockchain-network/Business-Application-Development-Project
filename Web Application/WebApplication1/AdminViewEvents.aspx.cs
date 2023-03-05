using AjaxControlToolkit;
using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminViewEvents : System.Web.UI.Page
    {
        Event aEvent = new Event();
        RegisterEvent aRegistration = null;
        Event details = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }

            List<Event> eventList = new List<Event>();
            eventList = aEvent.getEvent();

            int[] eventID = new int[] { };
            foreach (var info in eventList)
            {
                eventID = eventID.Append(info.eventId).ToArray();
            }

            RegisterEvent signUp = new RegisterEvent();
            Event anEvent = new Event();
            decimal[] percentage = new decimal[] {  };
            
            foreach (var items in eventID)
            {
                aRegistration = signUp.getSumOfPax(items);
                details = anEvent.getEventDetails(items);
                decimal result = Decimal.Divide(aRegistration.pax, details.pax) * 100;
                percentage = percentage.Append(result).ToArray();
            }
           
            BarChartSeries barChartSeries = new BarChartSeries();
            barChartSeries.Name = "Event ID";
            barChartSeries.Data = percentage;

            this.barChartEvent.ChartTitle = "Sign Up rate (%) for OLIVIA Events";
            this.barChartEvent.ChartHeight = "400px";
            this.barChartEvent.Series.Add(barChartSeries);
            this.barChartEvent.CategoriesAxis = string.Join(",", eventID);

        }

        protected void bind()
        {
            List<Event> upcomingEventList = new List<Event>();
            upcomingEventList = aEvent.getUpcomingEvent();
            gv_UpcomingEvents.DataSource = upcomingEventList;
            gv_UpcomingEvents.DataBind();

            List<Event> pastEventList = new List<Event>();
            pastEventList = aEvent.getPastEvent();
            gv_PastEvents.DataSource = pastEventList;
            gv_PastEvents.DataBind();
        }

        protected void btn_AddNewEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddNewEvents.aspx");
        }

        protected void gv_UpcomingEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_UpcomingEvents.SelectedRow;

            string eventId = row.Cells[0].Text;

            Response.Redirect("AdminEventDetails.aspx?EventID=" + eventId);
        }

        protected void gv_PastEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_PastEvents.SelectedRow;

            string eventId = row.Cells[0].Text;

            Response.Redirect("AdminEventDetails.aspx?EventID=" + eventId);
        }

        protected void gv_UpcomingEvents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_UpcomingEvents.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gv_UpcomingEvents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_UpcomingEvents.EditIndex = -1;
            bind();
        }

        protected void gv_UpcomingEvents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            int update = 0;
            Event aEvent = new Event();
            GridViewRow row = (GridViewRow)gv_UpcomingEvents.Rows[e.RowIndex];
            string id = gv_UpcomingEvents.DataKeys[e.RowIndex].Value.ToString();
            string eventTitle = ((TextBox)row.Cells[1].Controls[0]).Text;
            string location = ((TextBox)row.Cells[5].Controls[0]).Text;

            List<RegisterEvent> UpdateRegistration = new List<RegisterEvent>();
            RegisterEvent aRegistration = new RegisterEvent();
            UpdateRegistration = aRegistration.UpdateAllRegistration(Convert.ToInt32(id));

            result = aEvent.EventUpdate(Convert.ToInt32(id), eventTitle, location);
            if (result > 0)
            {
                Response.Write("<script>alert('Event updated successfully');</script>");
                foreach (var items in UpdateRegistration)
                {
                    update = aRegistration.UpdateEventTitle(items.custID, items.eventId, eventTitle);
                }
            }
            else
            {
                Response.Write("<script>alert('Event NOT updated');</script>");
            }
            gv_UpcomingEvents.EditIndex = -1;
            bind();
        }

        string _connStr = ConfigurationManager.ConnectionStrings["OliviaDBContext"].ConnectionString;

        protected void gv_UpcomingEvents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int delete = 0;
            Event aEvent = new Event();
            List<RegisterEvent> DeleteRegistration = new List<RegisterEvent>();
            RegisterEvent aRegistration = new RegisterEvent();
            string categoryID = gv_UpcomingEvents.DataKeys[e.RowIndex].Value.ToString();
            result = aEvent.EventDelete(Convert.ToInt32(categoryID));
            DeleteRegistration = aRegistration.DeleteAllRegistration(Convert.ToInt32(categoryID));
            
            if (result > 0)
            {
                Response.Write("<script>alert('Event deleted successfully');</script>");
                foreach (var items in DeleteRegistration)
                {
                    delete = aRegistration.DeleteRegistration(items.custID, Convert.ToInt32(categoryID));
                    
                    string queryStr = "SELECT * FROM Customer WHERE @custID = custID";
                    SqlConnection conn = new SqlConnection(_connStr);
                    SqlCommand cmd = new SqlCommand(queryStr, conn);
                    cmd.Parameters.AddWithValue("@custID", items.custID);

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    
                    if (dr.Read())
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("autoreply.oliviaevents@gmail.com");
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        SmtpServer.Port = 587;
                        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                        SmtpServer.UseDefaultCredentials = false;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("autoreply.oliviaevents@gmail.com", "vuhy sifu ionp vaeg");

                        mail.Subject = "Cancellation for " + items.eventTitle;
                        SmtpServer.EnableSsl = true;
                        SmtpServer.Timeout = 40000;
                        mail.Body = "Dear " + items.custFname + " " + items.custLname + ", \n\n" +
                            "Thank you for interest in " + items.eventTitle + ". We regret to inform you that the event that you registered for is no longer available. " +
                            "This was a difficult decision to make, but we were left with no choice.\n\n" + "We extend our sincere apologies for any inconvenience this may cause. \n\n" + 
                            "Yours Sincerely, \n" + "OLIVIA Events Team";
                        mail.To.Add(dr["custEmail"].ToString());
                        SmtpServer.Send(mail);
                        mail.To.Clear();
                    }

                    conn.Close();
                    dr.Close();
                    dr.Dispose();

                }
                Response.Redirect("AdminViewEvents.aspx");
            }
            else
            {
                Response.Write("<script>alert('Unsuccessful in deleting event');</script>");
            }
        }

        protected void btn_SearchUpcoming_Click(object sender, EventArgs e)
        {
            List<Event> filteredEventList = new List<Event>();
            List<Event> upcomingEventList = new List<Event>();
            upcomingEventList = aEvent.getUpcomingEvent();
            foreach (var info in upcomingEventList)
            {
                if (info.eventTitle == tb_UpcomingSearch.Text)
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

        protected void btn_UpcomingFilter_Click(object sender, EventArgs e)
        {
            List<Event> filteredEventList = new List<Event>();
            List<Event> upcomingEventList = new List<Event>();
            upcomingEventList = aEvent.getUpcomingEvent();
            foreach (var info in upcomingEventList)
            {
                if (info.category == ddl_CategoryUpcoming.SelectedValue)
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

        protected void btn_UpcomingFilterAll_Click(object sender, EventArgs e)
        {
            List<Event> filteredEventList = new List<Event>();
            List<Event> upcomingEventList = new List<Event>();
            upcomingEventList = aEvent.getUpcomingEvent();
            foreach (var info in upcomingEventList)
            {
                if (info.category == ddl_CategoryUpcoming.SelectedValue && info.eventTitle == tb_UpcomingSearch.Text)
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
        protected void btn_UpcomingReset_Click(object sender, EventArgs e)
        {
            List<Event> upcomingEventList = new List<Event>();
            upcomingEventList = aEvent.getUpcomingEvent();
            gv_UpcomingEvents.DataSource = upcomingEventList;
            gv_UpcomingEvents.DataBind();
        }

        protected void btn_SearchPast_Click(object sender, EventArgs e)
        {
            List<Event> filteredEventList = new List<Event>();
            List<Event> pastEventList = new List<Event>();
            pastEventList = aEvent.getPastEvent();
            foreach (var info in pastEventList)
            {
                if (info.eventTitle == tb_PastSearch.Text)
                {
                    filteredEventList.Add(info);
                    gv_PastEvents.DataSource = filteredEventList;
                    gv_PastEvents.DataBind();
                }
                else
                {
                    gv_PastEvents.DataSource = filteredEventList;
                    gv_PastEvents.DataBind();
                }
            }
        }

        protected void btn_PastFilter_Click(object sender, EventArgs e)
        {
            List<Event> filteredEventList = new List<Event>();
            List<Event> pastEventList = new List<Event>();
            pastEventList = aEvent.getPastEvent();
            foreach (var info in pastEventList)
            {
                if (info.category == ddl_CategoryPast.SelectedValue)
                {
                    filteredEventList.Add(info);
                    gv_PastEvents.DataSource = filteredEventList;
                    gv_PastEvents.DataBind();
                }
                else
                {
                    gv_PastEvents.DataSource = filteredEventList;
                    gv_PastEvents.DataBind();
                }
            }
        }

        protected void btn_PastFilterAll_Click(object sender, EventArgs e)
        {
            List<Event> filteredEventList = new List<Event>();
            List<Event> pastEventList = new List<Event>();
            pastEventList = aEvent.getPastEvent();
            foreach (var info in pastEventList)
            {
                if (info.category == ddl_CategoryPast.SelectedValue && info.eventTitle == tb_PastSearch.Text)
                {
                    filteredEventList.Add(info);
                    gv_PastEvents.DataSource = filteredEventList;
                    gv_PastEvents.DataBind();
                }
                else
                {
                    gv_PastEvents.DataSource = filteredEventList;
                    gv_PastEvents.DataBind();
                }
            }
        }

        protected void btn_PastReset_Click(object sender, EventArgs e)
        {
            List<Event> pastEventList = new List<Event>();
            pastEventList = aEvent.getPastEvent();
            gv_PastEvents.DataSource = pastEventList;
            gv_PastEvents.DataBind();
        }
    }
}