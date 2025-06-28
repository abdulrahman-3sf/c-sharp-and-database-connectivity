using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

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
            
            } 
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
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

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
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
            } catch (Exception ex)
            {
                Console.WriteLine("ERROR: ", ex.Message);
            }
            finally
            {
                connection.Close();
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

            } catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static void addNewContact(stContact contactInfo)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"insert into contacts (firstname, lastname, email, phone, address, countryid) 
                                values (@firstname, @lastname, @email, @phone, @address, @countryid)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstname", contactInfo.firstName);
            command.Parameters.AddWithValue("@lastname", contactInfo.lastName);
            command.Parameters.AddWithValue("@email", contactInfo.email);
            command.Parameters.AddWithValue("@phone", contactInfo.phone);
            command.Parameters.AddWithValue("@address", contactInfo.address);
            command.Parameters.AddWithValue("@countryid", contactInfo.countryID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record Inserted SUCCESSFULLY!");
                } else
                {
                    Console.WriteLine("Record Insertion FAILED!");
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        static void addNewContactAndGetID(stContact contactInfo)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"insert into contacts (firstname, lastname, email, phone, address, countryid) 
                                values (@firstname, @lastname, @email, @phone, @address, @countryid);
                             select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstname", contactInfo.firstName);
            command.Parameters.AddWithValue("@lastname", contactInfo.lastName);
            command.Parameters.AddWithValue("@email", contactInfo.email);
            command.Parameters.AddWithValue("@phone", contactInfo.phone);
            command.Parameters.AddWithValue("@address", contactInfo.address);
            command.Parameters.AddWithValue("@countryid", contactInfo.countryID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Console.WriteLine("Newly Inserted ID: " + insertedID);
                } else
                {
                    Console.WriteLine("Failed to Retreive the Inserted ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        static void updateContact(int contactID, stContact contactInfo)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update contacts
                                set firstname = @firstname,
                                    lastname = @lastname,
                                    email = @email,
                                    phone = @phone,
                                    address = @address,
                                    countryid = @countryid
                                where contactid = @contactid;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstname", contactInfo.firstName);
            command.Parameters.AddWithValue("@lastname", contactInfo.lastName);
            command.Parameters.AddWithValue("@email", contactInfo.email);
            command.Parameters.AddWithValue("@phone", contactInfo.phone);
            command.Parameters.AddWithValue("@address", contactInfo.address);
            command.Parameters.AddWithValue("@countryid", contactInfo.countryID);
            command.Parameters.AddWithValue("@contactid", contactID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record Updated SUCCESSFULLY!");
                }
                else
                {
                    Console.WriteLine("Record Update FAILED!");
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            } 
            finally
            {
                connection.Close();
            }
        }

        static void deleteContact(int contactID)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"delete contacts where contactid = @contactid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@contactid", contactID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record Updated SUCCESSFULLY!");
                }
                else
                {
                    Console.WriteLine("Record Update FAILED!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        static void Main(string[] args)
        {
            deleteContact(4);
        }
    }
}
