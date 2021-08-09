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
        List<AddressBookData> bookList = new List<AddressBookData>();
        public int TransverDataToListUsingThreads()
        {
            int count = 0;
            try
            {
                //create object for AddressBookData
                AddressBookData addressBook = new AddressBookData();
                Stopwatch stopWatch = new Stopwatch();
                SqlCommand command = new SqlCommand("RetriveAllData", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        stopWatch.Start();
                        //calling method to display and add to list
                        DisplayAndAddToList(reader, addressBook);
                        count++;
                    }
                    stopWatch.Stop();
                    Console.WriteLine("Time elapsed using Thread: {0}", stopWatch.ElapsedMilliseconds);
                }
                else
                {
                    Console.WriteLine("Data Not Found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return count;
        }
        public void DisplayAndAddToList(SqlDataReader reader, AddressBookData addressBook)
        {
            addressBook.personId = Convert.ToInt32(reader["PersonID"] == DBNull.Value ? default : reader["PersonID"]);
            addressBook.name = Convert.ToString(reader["Name"] == DBNull.Value ? default : reader["Name"]);
            addressBook.address = Convert.ToString(reader["Address"] == DBNull.Value ? default : reader["Address"]);
            addressBook.phone = Convert.ToInt64(reader["PhoneNumber"] == DBNull.Value ? default : reader["PhoneNumber"]);
            addressBook.emailId = Convert.ToString(reader["EmailID"] == DBNull.Value ? default : reader["EmailID"]);
            addressBook.date = Convert.ToDateTime(reader["AddDate"] == DBNull.Value ? default : reader["AddDate"]);
            addressBook.personTypeId = Convert.ToInt32(reader["PersonTypeID"] == DBNull.Value ? default : reader["PersonTypeID"]);
            addressBook.personType = Convert.ToString(reader["PersonType"] == DBNull.Value ? default : reader["PersonType"]);
            addressBook.addressBookId = Convert.ToInt32(reader["AddressBookID"] == DBNull.Value ? default : reader["AddressBookID"]);
            addressBook.addressBookName = Convert.ToString(reader["AddressBookName"] == DBNull.Value ? default : reader["AddressBookName"]);
            Thread thread = new Thread(() =>
            {
                Console.WriteLine($"PersonId:{addressBook.personId}|Name:{addressBook.name}|Address:{addressBook.address}|PhoneNumber:{addressBook.phone}|" +
                $"EmailID:{addressBook.emailId}|Date:{addressBook.date}|PersonTypeId:{addressBook.personTypeId}|PersonType:{addressBook.personType}|" +
                $"AddressBookID:{addressBook.addressBookId}|AddressBookName:{addressBook.addressBookName}\n");
                bookList.Add(addressBook);
            });
            thread.Start();
        }
    }
}
