using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminViewRegistrationData : System.Web.UI.Page
    {
        RegisterEvent aEvent = new RegisterEvent();
        Event events = null;
        RegisterEvent registration = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }

            Event aEvent = new Event();
            RegisterEvent aRegistration = new RegisterEvent();
            string eventId = Request.QueryString["eventId"].ToString();
            events = aEvent.getEventDetails(Convert.ToInt32(eventId));
            registration = aRegistration.getSumOfPax(Convert.ToInt32(eventId));

            lbl_event.Text = events.eventTitle;
            lbl_EventPax.Text = events.pax.ToString();
            lbl_CurrentPax.Text = registration.pax.ToString();
        }
        protected void bind()
        {
            List<RegisterEvent> eventList = new List<RegisterEvent>();
            string eventId = Request.QueryString["eventId"].ToString();
            eventList = aEvent.getRegistrationDetails(int.Parse(eventId));
            gv_RegistrationDetails.DataSource = eventList;
            gv_RegistrationDetails.DataBind();

            int[] custID = new int[] { };
            foreach (var info in eventList)
            {
                custID = custID.Append(info.custID).ToArray();
            }
            ddl_custID.DataSource = custID;
            ddl_custID.DataBind();
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            string eventId = Request.QueryString["eventId"].ToString();
            Response.Redirect("AdminEventDetails.aspx?EventID=" + eventId);
        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            GridviewToExcel();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }

        public void GridviewToExcel()
        {
            string eventId = Request.QueryString["eventId"].ToString();
            StringBuilder builder = new StringBuilder();
            builder.Append("Customer ID ,Customer First Name, Customer Last Name, Number of Pax attending" + Environment.NewLine);
            foreach (GridViewRow row in gv_RegistrationDetails.Rows)
            {
                string custID = row.Cells[0].Text;
                string custFname = row.Cells[1].Text;
                string custLname = row.Cells[2].Text;
                string pax = row.Cells[3].Text;
                builder.Append(custID + "," + custFname + "," + custLname + "," + pax + Environment.NewLine);
            }
            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AddHeader("Content-Disposition", "attachment;filename=Event " + eventId + ".csv");
            Response.Write(builder.ToString());
            Response.End();
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            List<RegisterEvent> upcomingEventList = new List<RegisterEvent>();
            string eventId = Request.QueryString["eventId"].ToString();
            upcomingEventList = aEvent.getRegistrationDetails(int.Parse(eventId));
            gv_RegistrationDetails.DataSource = upcomingEventList;
            gv_RegistrationDetails.DataBind();
        }

        protected void btn_SearchFirstName_Click(object sender, EventArgs e)
        {
            List<RegisterEvent> filteredEventList = new List<RegisterEvent>();
            List<RegisterEvent> upcomingEventList = new List<RegisterEvent>();
            string eventId = Request.QueryString["eventId"].ToString();
            upcomingEventList = aEvent.getRegistrationDetails(int.Parse(eventId));
            foreach (var info in upcomingEventList)
            {
                if (info.custFname == tb_firstName.Text)
                {
                    filteredEventList.Add(info);
                    gv_RegistrationDetails.DataSource = filteredEventList;
                    gv_RegistrationDetails.DataBind();
                }
                else
                {
                    gv_RegistrationDetails.DataSource = filteredEventList;
                    gv_RegistrationDetails.DataBind();
                }
            }
        }

        protected void btn_SearchLastName_Click(object sender, EventArgs e)
        {
            List<RegisterEvent> filteredEventList = new List<RegisterEvent>();
            List<RegisterEvent> upcomingEventList = new List<RegisterEvent>();
            string eventId = Request.QueryString["eventId"].ToString();
            upcomingEventList = aEvent.getRegistrationDetails(int.Parse(eventId));
            foreach (var info in upcomingEventList)
            {
                if (info.custLname == tb_lastName.Text)
                {
                    filteredEventList.Add(info);
                    gv_RegistrationDetails.DataSource = filteredEventList;
                    gv_RegistrationDetails.DataBind();
                }
                else
                {
                    gv_RegistrationDetails.DataSource = filteredEventList;
                    gv_RegistrationDetails.DataBind();
                }
            }
        }

        protected void btn_Filter_Click(object sender, EventArgs e)
        {
            List<RegisterEvent> filteredEventList = new List<RegisterEvent>();
            List<RegisterEvent> upcomingEventList = new List<RegisterEvent>();
            string eventId = Request.QueryString["eventId"].ToString();
            upcomingEventList = aEvent.getRegistrationDetails(int.Parse(eventId));
            foreach (var info in upcomingEventList)
            {
                if (info.custID == Convert.ToInt32(ddl_custID.SelectedValue))
                {
                    filteredEventList.Add(info);
                    gv_RegistrationDetails.DataSource = filteredEventList;
                    gv_RegistrationDetails.DataBind();
                }
                else
                {
                    gv_RegistrationDetails.DataSource = filteredEventList;
                    gv_RegistrationDetails.DataBind();
                }
            }
        }
    }
}