using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public class RegisterEvent
    {
        string _connStr = ConfigurationManager.ConnectionStrings["OliviaDBContext"].ConnectionString;
        private int _custID = 0;
        private int _eventId = 0;
        private string _custFname = "";
        private string _custLname = "";
        private string _eventTitle = string.Empty;
        private int _pax = 0;
        
        public RegisterEvent()
        {
        }

        public RegisterEvent(int custID, int eventId, string custFname, string custLname, string eventTitle, int pax)
        {
            _custID = custID;
            _eventId = eventId;
            _custFname = custFname;
            _custLname = custLname;
            _eventTitle = eventTitle;
            _pax = pax;
        }

        public RegisterEvent(int eventId, int pax)
            : this(0, eventId, null, null, null, pax)
        {

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
        public int pax
        {
            get { return _pax; }
            set { _pax = value; }
        }

        public int RegisterEventInsert()
        {
            int result = 0;
            string queryStr = "INSERT INTO TicketInformation(custID, eventId, custFname, custLname, eventTitle, pax)" 
                + "values (@custID, @eventId, @custFname, @custLname, @eventTitle, @pax)";

            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@custID", this.custID);
                cmd.Parameters.AddWithValue("@eventId", this.eventId);
                cmd.Parameters.AddWithValue("@custFname", this.custFname);
                cmd.Parameters.AddWithValue("@custLname", this.custLname);
                cmd.Parameters.AddWithValue("@eventTitle", this.eventTitle);
                cmd.Parameters.AddWithValue("@pax", this.pax);

                conn.Open();
                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                conn.Close();

                return result;
            } catch (Exception ex)
            {
                return 0;
            }
        }

        public RegisterEvent getRegisteredEvent(int eventId, int custID)
        {
            RegisterEvent information = null;
            string queryStr = "SELECT * FROM TicketInformation WHERE (@eventId = eventId and @custID = custID)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@eventId", eventId);
            cmd.Parameters.AddWithValue("@custID", custID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                custID = int.Parse(dr["custID"].ToString());
                eventId = int.Parse(dr["eventId"].ToString());
                eventTitle = dr["eventTitle"].ToString();
                custFname = dr["custFname"].ToString();
                custLname = dr["custLname"].ToString();
                pax = int.Parse(dr["pax"].ToString());

                information = new RegisterEvent(custID, eventId, custFname, custLname, eventTitle, pax);
 
            } else
            {
                information = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return information;
        }

        public RegisterEvent getTicketInformation(int eventId, int custID)
        {

            RegisterEvent registrationDetail = null;

            string eventTitle, custFname, custLname;
            int pax;

            string queryStr = "SELECT * FROM TicketInformation WHERE (@eventId = eventId and @custID = custID)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@eventId", eventId);
            cmd.Parameters.AddWithValue("@custID", custID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                custID = int.Parse(dr["custID"].ToString());
                eventId = int.Parse(dr["eventId"].ToString());
                custFname = dr["custFname"].ToString();
                custLname = dr["custLname"].ToString();
                eventTitle = dr["eventTitle"].ToString();
                pax = int.Parse(dr["pax"].ToString());

                registrationDetail = new RegisterEvent(custID, eventId, custFname, custLname, eventTitle, pax);
            }
            else
            {
                registrationDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return registrationDetail;
        }
        
        public int DeleteRegistration(int custID, int eventId)
        {
            string queryStr = "DELETE FROM TicketInformation WHERE (@eventId = eventId and @custID = custID)";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@custID", custID);
                cmd.Parameters.AddWithValue("@eventId", eventId);

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
        public List<RegisterEvent> getRegistrationDetails(int eventId)
        {
            List<RegisterEvent> registeredEvent = new List<RegisterEvent>();
            string queryStr = "SELECT * FROM TicketInformation WHERE @eventId = eventId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@eventId", eventId);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                custID = int.Parse(dr["custID"].ToString());
                eventId = int.Parse(dr["eventId"].ToString());
                eventTitle = dr["eventTitle"].ToString();
                custFname = dr["custFname"].ToString();
                custLname = dr["custLname"].ToString();
                pax = int.Parse(dr["pax"].ToString());
                RegisterEvent information = new RegisterEvent(custID, eventId, custFname, custLname, eventTitle, pax);
                registeredEvent.Add(information);

            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return registeredEvent;
        }
        public RegisterEvent getSumOfPax(int eventId)
        {

            RegisterEvent eventDetail = null;

            int pax;

            string queryStr = "SELECT SUM(pax), eventId FROM TicketInformation WHERE eventId = @eventId Group by eventId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@eventId", eventId);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                eventId = int.Parse(dr["eventId"].ToString());
                pax = int.Parse(dr[0].ToString());

                eventDetail = new RegisterEvent(0, eventId, null, null, null, pax);
            }
            else
            {
                eventDetail = new RegisterEvent(0, eventId, null, null, null, 0);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return eventDetail;
        }

        public List <RegisterEvent> DeleteAllRegistration(int eventId)
        {
            List<RegisterEvent> registeredEvent = new List<RegisterEvent>();
            string queryStr = "SELECT * FROM TicketInformation WHERE @eventId = eventId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@eventId", eventId);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                custID = int.Parse(dr["custID"].ToString());
                eventId = int.Parse(dr["eventId"].ToString());
                eventTitle = dr["eventTitle"].ToString();
                custFname = dr["custFname"].ToString();
                custLname = dr["custLname"].ToString();
                pax = int.Parse(dr["pax"].ToString());
                RegisterEvent information = new RegisterEvent(custID, eventId, custFname, custLname, eventTitle, pax);
                registeredEvent.Add(information);

            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return registeredEvent;
        }

        public List<RegisterEvent> UpdateAllRegistration(int eventId)
        {
            List<RegisterEvent> registeredEvent = new List<RegisterEvent>();
            string queryStr = "SELECT * FROM TicketInformation WHERE @eventId = eventId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@eventId", eventId);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                custID = int.Parse(dr["custID"].ToString());
                eventId = int.Parse(dr["eventId"].ToString());
                eventTitle = dr["eventTitle"].ToString();
                custFname = dr["custFname"].ToString();
                custLname = dr["custLname"].ToString();
                pax = int.Parse(dr["pax"].ToString());
                RegisterEvent information = new RegisterEvent(custID, eventId, custFname, custLname, eventTitle, pax);
                registeredEvent.Add(information);

            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return registeredEvent;
        }

        public int UpdateEventTitle(int custID, int eventId, string eventTitle)
        {
            string queryStr = "UPDATE TicketInformation SET" +
                " eventTitle = @eventTitle " +
                " WHERE (@eventId = eventId and @custID = custID)";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@eventId", eventId);
                cmd.Parameters.AddWithValue("@custID", custID);
                cmd.Parameters.AddWithValue("@eventTitle", eventTitle);

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