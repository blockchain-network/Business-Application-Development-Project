using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public class EventRegistrationDetails
    {
        string _connStr = ConfigurationManager.ConnectionStrings["OliviaDBContext"].ConnectionString;
        private int _custID = 0;
        private int _eventId = 0;
        private string _custFname = "";
        private string _custLname = "";
        private string _eventTitle = string.Empty;
        private int _custpax = 0;
        private string _eventDescription = "";
        private string _eventImg = "";
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;
        private TimeSpan _startTime = TimeSpan.Zero;
        private TimeSpan _endTime = TimeSpan.Zero;
        private string _location = "";
        private string _category = "";
        private int _eventpax = 0;

        public EventRegistrationDetails()
        {
        }

        public EventRegistrationDetails(int custID, int eventId, string custFname, string custLname, string eventTitle, int custPax, string eventDescription, string eventImg, DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime, string location, string category, int eventPax)
        {
            _custID = custID;
            _eventId = eventId;
            _custFname = custFname;
            _custLname = custLname;
            _eventTitle = eventTitle;
            _custpax = custPax;
            _eventDescription = eventDescription;
            _eventImg = eventImg;
            _startDate = startDate;
            _endDate = endDate;
            _startTime = startTime;
            _endTime = endTime;
            _location = location;
            _category = category;
            _eventpax = eventPax;
        }

        public int custID
        {
            get { return _custID; }
            set { _custID = value; }
        }
        public int eventId
        {
            get { return _eventId; }
            set { _eventId = value; }
        }
        public string custFname
        {
            get { return _custFname; }
            set { _custFname = value; }
        }
        public string custLname
        {
            get { return _custLname; }
            set { _custLname = value; }
        }
        public string eventTitle
        {
            get { return _eventTitle; }
            set { _eventTitle = value; }
        }
        public int custPax
        {
            get { return _custpax; }
            set { _custpax = value; }
        }

        public string eventDescription
        {
            get { return _eventDescription; }
            set { _eventDescription = value; }
        }
        public string eventImg
        {
            get { return _eventImg; }
            set { _eventImg = value; }
        }
        public DateTime startDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        public DateTime endDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        public TimeSpan startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        public TimeSpan endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        public string location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string category
        {
            get { return _category; }
            set { _category = value; }
        }
        public int eventPax
        {
            get { return _eventpax; }
            set { _eventpax = value; }
        }

        public List<EventRegistrationDetails> getUpcomingRegisteredEvent(int custId)
        {
            List<EventRegistrationDetails> upcomingRegisteredEvent = new List<EventRegistrationDetails>();
            string queryStr = "SELECT * FROM TicketInformation t Inner Join Events e on e.eventId = t.eventId  WHERE @custID = custId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@custID", custId);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                custID = int.Parse(dr["custID"].ToString());
                eventId = int.Parse(dr["eventId"].ToString());
                eventTitle = dr["eventTitle"].ToString();
                custFname = dr["custFname"].ToString();
                custLname = dr["custLname"].ToString();
                custPax = int.Parse(dr["pax"].ToString());
                eventDescription = dr["eventDescription"].ToString();
                eventImg = dr["eventImg"].ToString();
                startDate = DateTime.Parse(dr["startDate"].ToString());
                endDate = DateTime.Parse(dr["endDate"].ToString());
                startTime = TimeSpan.Parse(dr["startTime"].ToString());
                endTime = TimeSpan.Parse(dr["endTime"].ToString());
                location = dr["location"].ToString();
                category = dr["category"].ToString();
                eventPax = int.Parse(dr["pax"].ToString());

                if (endDate >= DateTime.Now.Date)
                {
                    EventRegistrationDetails information = new EventRegistrationDetails(custID, eventId, custFname, custLname, eventTitle, custPax, eventDescription, eventImg, startDate, endDate, startTime, endTime, location, category, eventPax);
                    upcomingRegisteredEvent.Add(information);
                }

            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return upcomingRegisteredEvent;
        }

        public List<EventRegistrationDetails> getPastRegisteredEvent(int custId)
        {
            List<EventRegistrationDetails> pastRegisteredEvent = new List<EventRegistrationDetails>();
            string queryStr = "SELECT * FROM TicketInformation t Inner Join Events e on e.eventId = t.eventId  WHERE @custID = custId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@custID", custId);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                custID = int.Parse(dr["custID"].ToString());
                eventId = int.Parse(dr["eventId"].ToString());
                eventTitle = dr["eventTitle"].ToString();
                custFname = dr["custFname"].ToString();
                custLname = dr["custLname"].ToString();
                custPax = int.Parse(dr["pax"].ToString());
                eventDescription = dr["eventDescription"].ToString();
                eventImg = dr["eventImg"].ToString();
                startDate = DateTime.Parse(dr["startDate"].ToString());
                endDate = DateTime.Parse(dr["endDate"].ToString());
                startTime = TimeSpan.Parse(dr["startTime"].ToString());
                endTime = TimeSpan.Parse(dr["endTime"].ToString());
                location = dr["location"].ToString();
                category = dr["category"].ToString();
                eventPax = int.Parse(dr["pax"].ToString());

                if (endDate < DateTime.Now.Date)
                {
                    EventRegistrationDetails information = new EventRegistrationDetails(custID, eventId, custFname, custLname, eventTitle, custPax, eventDescription, eventImg, startDate, endDate, startTime, endTime, location, category, eventPax);
                    pastRegisteredEvent.Add(information);
                }

            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return pastRegisteredEvent;
        }
        
    }
   
}