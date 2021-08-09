using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADO_AddressBook
{
    public class AddressBookThreads
    {
        //adding server name and database name
        public static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog = Address_Book_service_DB;";
        //Createing conection object to connect with database
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void InsertMultiplePerson(AddressBookData data)
        {
            try
            {
                DateTime date = Convert.ToDateTime("2020-10-30");
                SqlCommand command = new SqlCommand("InsertDataInERTable", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@addressBookId", data.addressBookId);
                command.Parameters.AddWithValue("@firstName", data.firstname);
                command.Parameters.AddWithValue("@lastName", data.lastName);
                command.Parameters.AddWithValue("@address", data.address);
                command.Parameters.AddWithValue("@city", data.city);
                command.Parameters.AddWithValue("@state", data.state);
                command.Parameters.AddWithValue("@zipCode", data.Zipcode);
                command.Parameters.AddWithValue("@phoneNumber", data.phone);
                command.Parameters.AddWithValue("@emailId", data.emailId);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@personTypeId", data.personTypeId);
                sqlConnection.Open();
                int result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Updated");
                }
                else
                {
                    Console.WriteLine("Not Update");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public int ForCalculatingTime(List<AddressBookData> book)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            AddContactListToDBWithThread(book);
            stopwatch.Stop();
            Console.WriteLine($"Time taken for With Thread :{stopwatch.ElapsedMilliseconds}");
            if(stopwatch.ElapsedMilliseconds != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        // Method to Add List of Contacts To DB With Thread......................
        public void AddContactListToDBWithThread(List<AddressBookData> bookList)
        {
            bookList.ForEach(book =>
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Contact adding start: " + book.firstname);
                    this.InsertMultiplePerson(book);
                    Console.WriteLine("Contact adding end: " + book.firstname);
                });
                thread.Start();
                thread.Join();
            });
        }
    }
}
