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

        static void Main(string[] args)
        {
            printAllContacts();
        }
    }
}
