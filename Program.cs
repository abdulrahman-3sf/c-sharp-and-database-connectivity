using System;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    internal class Program
    {
        static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=zzxxcc122";

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

        static void Main(string[] args)
        {
            printAllContacts();
            printAllContactsWithFirstName("jane");
            //searchContactsStartWith("j");
            //searchContactsEndWith("ne");
            //searchContactsContains("ae");
        }
    }
}
