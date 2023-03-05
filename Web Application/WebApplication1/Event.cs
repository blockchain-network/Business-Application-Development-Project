using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication1
{
    public class Event
    {
        string _connStr = ConfigurationManager.ConnectionStrings["OliviaDBContext"].ConnectionString;
        private int _eventId = 0;
        private string _eventTitle = string.Empty;
        private string _eventDescription = "";
        private string _eventImg = "";
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;
        private TimeSpan _startTime = TimeSpan.Zero;
        private TimeSpan _endTime = TimeSpan.Zero;
        private string _location = "";
        private string _category = "";
        private int _pax = 0;

        // Default constructor
        public Event()
        {
        }

        // Constructor that take in all data required to build a Product object
        public Event(int eventId, string eventTitle, string eventDescription, string eventImg, DateTime startDate,
            DateTime endDate, TimeSpan startTime, TimeSpan endTime, string location, string category, int pax)
        {
            _eventId = eventId;
            _eventTitle = eventTitle;
            _eventDescription = eventDescription;
            _eventImg = eventImg;
            _startDate = startDate;
            _endDate = endDate;
            _startTime = startTime;
            _endTime = endTime;
            _location = location;
            _category = category;
            _pax = pax;
        }
        public Event(string eventTitle, string eventDescription, string eventImg, DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime, string location, string category, int pax)
            : this(0, eventTitle, eventDescription, eventImg, startDate, endDate, startTime, endTime, location, category, pax)
        {
            
        }

        public int eventId
        {
            get { return _eventId; }
            set { _eventId = value; }
        }
        public string eventTitle
        {
            get { return _eventTitle; }
            set { _eventTitle = value; }
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
        public int pax
        {
            get { return _pax; }
            set { _pax = value; }
        }

        // Add a new event (Admin)
        public int EventInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Events(eventTitle, eventDescription, eventImg, startDate, endDate, startTime, endTime, location, category, pax)"
                + " values (@eventTitle, @eventDescription, @eventImg, @startDate, @endDate, @startTime, @endTime, @location, @category, @pax)";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@eventTitle", this.eventTitle);
                cmd.Parameters.AddWithValue("@eventDescription", this.eventDescription);
                cmd.Parameters.AddWithValue("@eventImg", this.eventImg);
                cmd.Parameters.AddWithValue("@startDate", this.startDate);    
                cmd.Parameters.AddWithValue("@endDate", this.endDate);
                cmd.Parameters.AddWithValue("@startTime", this.startTime);
                cmd.Parameters.AddWithValue("@endTime", this.endTime);
                cmd.Parameters.AddWithValue("@location", this.location);
                cmd.Parameters.AddWithValue("@category", this.category);
                cmd.Parameters.AddWithValue("@pax", this.pax);

                conn.Open();
                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                conn.Close();

                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public List<Event> getEvent()
        {
            List<Event> upcomingEventList = new List<Event>();

            string eventTitle, eventDescription, eventImg, location, category;
            int eventId, pax;
            DateTime startDate, endDate;
            TimeSpan startTime, endTime;

            string queryStr = "SELECT * FROM Events Order By eventId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                eventId = int.Parse(dr["eventId"].ToString());
                eventTitle = dr["eventTitle"].ToString();
                eventDescription = dr["eventDescription"].ToString();
                eventImg = dr["eventImg"].ToString();
                startDate = DateTime.Parse(dr["startDate"].ToString());
                endDate = DateTime.Parse(dr["endDate"].ToString());
                startTime = TimeSpan.Parse(dr["startTime"].ToString());
                endTime = TimeSpan.Parse(dr["endTime"].ToString());
                location = dr["location"].ToString();
                category = dr["category"].ToString();
                pax = int.Parse(dr["pax"].ToString());

                Event information = new Event(eventId, eventTitle, eventDescription, eventImg, startDate, endDate, startTime, endTime, location, category, pax);
                upcomingEventList.Add(information);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return upcomingEventList;
        }

        // List all upcoming events for Admin
        public List<Event> getUpcomingEvent()
        {
            List<Event> upcomingEventList = new List<Event>();

            string eventTitle, eventDescription, eventImg, location, category;
            int eventId, pax;
            DateTime startDate, endDate;
            TimeSpan startTime, endTime;

            string queryStr = "SELECT * FROM Events Order By eventId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                eventId = int.Parse(dr["eventId"].ToString());
                eventTitle = dr["eventTitle"].ToString();
                eventDescription = dr["eventDescription"].ToString();
                eventImg = dr["eventImg"].ToString();
                startDate = DateTime.Parse(dr["startDate"].ToString());
                endDate = DateTime.Parse(dr["endDate"].ToString());
                startTime = TimeSpan.Parse(dr["startTime"].ToString());
                endTime = TimeSpan.Parse(dr["endTime"].ToString());
                location = dr["location"].ToString();
                category = dr["category"].ToString();
                pax = int.Parse(dr["pax"].ToString());

                if (endDate >= DateTime.Now.Date)
                {
                    Event information = new Event(eventId, eventTitle, eventDescription, eventImg, startDate, endDate, startTime, endTime, location, category, pax);
                    upcomingEventList.Add(information);
                } 
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return upcomingEventList;
        }

        // List all past event for Admin
        public List<Event> getPastEvent()
        {
            List<Event> pastEventList = new List<Event>();

            string eventTitle, eventDescription, eventImg, location, category;
            int eventId, pax;
            DateTime startDate, endDate;
            TimeSpan startTime, endTime;

            string queryStr = "SELECT * FROM Events Order By eventId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                eventId = int.Parse(dr["eventId"].ToString());
                eventTitle = dr["eventTitle"].ToString();
                eventDescription = dr["eventDescription"].ToString();
                eventImg = dr["eventImg"].ToString();
                startDate = DateTime.Parse(dr["startDate"].ToString());
                endDate = DateTime.Parse(dr["endDate"].ToString());
                startTime = TimeSpan.Parse(dr["startTime"].ToString());
                endTime = TimeSpan.Parse(dr["endTime"].ToString());
                location = dr["location"].ToString();
                category = dr["category"].ToString();
                pax = int.Parse(dr["pax"].ToString());

                if (endDate < DateTime.Now.Date)
                {
                    Event information = new Event(eventId, eventTitle, eventDescription, eventImg, startDate, endDate, startTime, endTime, location, category, pax);
                    pastEventList.Add(information);
                }
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return pastEventList;
        }

        // List Event Details
        public Event getEventDetails(int eventId)
        {

            Event eventDetail = null;

            string eventTitle, eventDescription, eventImg, location, category;
            int pax;
            DateTime startDate, endDate;
            TimeSpan startTime, endTime;

            string queryStr = "SELECT * FROM Events WHERE eventId = @eventId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@eventId", eventId);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                eventId = int.Parse(dr["eventId"].ToString());
                eventTitle = dr["eventTitle"].ToString();
                eventDescription = dr["eventDescription"].ToString();
                eventImg = dr["eventImg"].ToString();
                startDate = DateTime.Parse(dr["startDate"].ToString());
                endDate = DateTime.Parse(dr["endDate"].ToString());
                startTime = TimeSpan.Parse(dr["startTime"].ToString());
                endTime = TimeSpan.Parse(dr["endTime"].ToString());
                location = dr["location"].ToString();
                category = dr["category"].ToString();
                pax = int.Parse(dr["pax"].ToString());

                eventDetail = new Event(eventId, eventTitle, eventDescription, eventImg, startDate, endDate, startTime, endTime, location, category, pax);
            }
            else
            {
                eventDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return eventDetail;
        }

        // Update for Events
        public int EventUpdate(int eventId, string eventTitle, string location)
        {
            string queryStr = "UPDATE Events SET" +
                " eventTitle = @eventTitle, " +
                " location = @location " +
                " WHERE eventId = @eventId";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@eventId", eventId);
                cmd.Parameters.AddWithValue("@eventTitle", eventTitle);
                cmd.Parameters.AddWithValue("@location", location);

                conn.Open();
                int nofRow = 0;
                nofRow = cmd.ExecuteNonQuery();

                conn.Close();

                return nofRow;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        // Delete Event
        public int EventDelete(int ID)
        {
            string queryStr = "DELETE FROM Events WHERE eventId=@ID";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                conn.Open();
                int nofRow = 0;
                nofRow = cmd.ExecuteNonQuery();
                conn.Close();
                return nofRow;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}