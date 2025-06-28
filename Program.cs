using System;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    internal class Program
    {
        static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=YOUR_DATABASE_PASSWORD";

        static void printAllContacts()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Contacts";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                int contactID, countryID; 
                string firstName, lastName, email, phone, address;

                while (reader.Read())
                {
                    contactID = (int)reader["ContactID"];
                    firstName = (string)reader["FirstName"];
                    lastName = (string)reader["LastName"];
                    email = (string)reader["Email"];
                    phone = (string)reader["Phone"];
                    address = (string)reader["Address"];
                    countryID = (int)reader["CountryID"];

                    Console.WriteLine("ContactID " + contactID);
                    Console.WriteLine("FirstName " + firstName);
                    Console.WriteLine("LastName " + lastName);
                    Console.WriteLine("Email " + email);
                    Console.WriteLine("Phone " + phone);
                    Console.WriteLine("Address " + address);
                    Console.WriteLine("CountryID " + countryID);
                    Console.WriteLine();
                }

                reader.Close();
                connection.Close();
            
            } catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        static void printAllContactsWithFirstName(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from contacts where firstname = @firstname";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstname", firstName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                int contactID, countryID;
                string firstName2, lastName, email, phone, address;

                while (reader.Read())
                {
                    contactID = (int)reader["ContactID"];
                    firstName2 = (string)reader["FirstName"];
                    lastName = (string)reader["LastName"];
                    email = (string)reader["Email"];
                    phone = (string)reader["Phone"];
                    address = (string)reader["Address"];
                    countryID = (int)reader["CountryID"];

                    Console.WriteLine("ContactID " + contactID);
                    Console.WriteLine("FirstName " + firstName);
                    Console.WriteLine("LastName " + lastName);
                    Console.WriteLine("Email " + email);
                    Console.WriteLine("Phone " + phone);
                    Console.WriteLine("Address " + address);
                    Console.WriteLine("CountryID " + countryID);
                    Console.WriteLine();
                }

                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        static void searchContactsStartWith(string startWith)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from contacts where firstname like '' + @startWith + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@startWith", startWith);

            // print data ..
        }
        static void searchContactsEndWith(string endWith)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from contacts where firstname like '%' + @endWith + ''";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@endWith", endWith);

            // print data ..
        }
        static void searchContactsContains(string contains)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from contacts where firstname like '%' + @contains + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@contains", contains);

            // print data ..
        }

        static String getFirstName(int contactID)
        {
            string firstName = "";

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select firstname from contacts where contactid = @contactid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@contactid", contactID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar(); // return single value, not like ExecuteReader() read all rows

                if (result != null)
                {
                    firstName = result.ToString();
                }

                connection.Close();

            } catch (Exception ex)
            {
                Console.WriteLine("ERROR: ", ex.Message);
            }

            return firstName;
        }

        public struct stContact
        {
            public int ID { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
            public int countryID { get; set; }
        }
        static bool findContactByID(int contactID, ref stContact contactInfo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from contacts where contactid = @contactid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@contactid", contactID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    contactInfo.ID = (int)reader["contactid"];
                    contactInfo.firstName = (string)reader["firstname"];
                    contactInfo.lastName = (string)reader["lastname"];
                    contactInfo.email = (string)reader["email"];
                    contactInfo.phone = (string)reader["phone"];
                    contactInfo.address = (string)reader["address"];
                    contactInfo.countryID = (int)reader["countryid"];
                }

                reader.Close();
                connection.Close();
            } catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            return isFound;
        }

        static void Main(string[] args)
        {
            stContact contactInfo = new stContact();

            if (findContactByID(1, ref contactInfo))
            {
                Console.WriteLine("ContactID: " + contactInfo.ID);
                Console.WriteLine("Firstname: " + contactInfo.firstName);
                Console.WriteLine("LastName: " + contactInfo.lastName);
                Console.WriteLine("Email: " + contactInfo.email);
                Console.WriteLine("Phone: " + contactInfo.phone);
                Console.WriteLine("Address: " + contactInfo.address);
                Console.WriteLine("CountryID: " + contactInfo.countryID);
            } else
            {
                Console.WriteLine("NOT FOUND!");
            }
        }
    }
}
