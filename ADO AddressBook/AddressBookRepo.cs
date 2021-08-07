using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_AddressBook
{
    public class AddressBookRepo
    {
        //adding server name and database name
        public static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog = Address_Book_service_DB;";
        //Createing conection object to connect with database
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public int RetriveAllData()
        {
            int count = 0;
            try
            {
                //create object for AddressBookData
                AddressBookData addressBook = new AddressBookData();
                SqlCommand command = new SqlCommand("RetriveAllData", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //calling method to display values
                        DisplayTotalData(reader,addressBook);
                        count++;
                    }
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
        public string UpdateContactPhoneNumber(AddressBookData data)
        {
            try
            {
                SqlCommand command = new SqlCommand("UpdatePhoneNumber", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@firstName", data.firstname);
                command.Parameters.AddWithValue("@lastName", data.lastName);
                command.Parameters.AddWithValue("@phoneNumber", data.phone);
                sqlConnection.Open();
                int result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Updated");
                    return "Updated";
                }
                else
                {
                    Console.WriteLine("Not Update");
                    return "Not Updated";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Not Updated";
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public int RetriveBaseONPerticularPeriod()
        {
            int count = 0;
            try
            {
                //create object for AddressBookData
                AddressBookData addressBook = new AddressBookData();
                SqlCommand command = new SqlCommand("RetriveByDateRange", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //calling method to display values
                        DisplayTotalData(reader, addressBook);
                        count++;
                    }
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
        public static void DisplayTotalData (SqlDataReader reader,AddressBookData addressBook)
        {
            addressBook.personId = Convert.ToInt32(reader["PersonID"] == DBNull.Value ? default : reader["PersonID"]);
            addressBook.name = Convert.ToString(reader["Name"] == DBNull.Value ? default : reader["Name"]);
            addressBook.address= Convert.ToString(reader["Address"] == DBNull.Value ? default : reader["Address"]);
            addressBook.phone = Convert.ToInt64(reader["PhoneNumber"] == DBNull.Value ? default : reader["PhoneNumber"]);
            addressBook.emailId= Convert.ToString(reader["EmailID"] == DBNull.Value ? default : reader["EmailID"]);
            addressBook.date = Convert.ToDateTime(reader["AddDate"] == DBNull.Value ? default : reader["AddDate"]);
            addressBook.personTypeId= Convert.ToInt32(reader["PersonTypeID"] == DBNull.Value ? default : reader["PersonTypeID"]);
            addressBook.personType= Convert.ToString(reader["PersonType"] == DBNull.Value ? default : reader["PersonType"]);
            addressBook.addressBookId= Convert.ToInt32(reader["AddressBookID"] == DBNull.Value ? default : reader["AddressBookID"]);
            addressBook.addressBookName = Convert.ToString(reader["AddressBookName"] == DBNull.Value ? default : reader["AddressBookName"]);
            Console.WriteLine($"PersonId:{addressBook.personId}|Name:{addressBook.name}|Address:{addressBook.address}|PhoneNumber:{addressBook.phone}|" +
                $"EmailID:{addressBook.emailId}|Date:{addressBook.date}|PersonTypeId:{addressBook.personTypeId}|PersonType:{addressBook.personType}|" +
                $"AddressBookID:{addressBook.addressBookId}|AddressBookName:{addressBook.addressBookName}\n");
        }
    }
}
