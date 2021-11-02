using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookDataBase
{
    public class AddressBookDatabase
    {
        public static string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectingString);

        public int GetPersonDetailsfromDatabase()
        {
            int count = 0;
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    string RetriveQuery = @"Select * From AddressBookTable";
                    SqlCommand sqlCommand = new SqlCommand(RetriveQuery, connection);
                    connection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        Console.WriteLine("Address Book Services Database Has Following Contacts!");
                        while (dataReader.Read())
                        {
                            addressBookModel.Id = dataReader.GetInt32(0);
                            addressBookModel.Firstname = dataReader.GetString(1);
                            addressBookModel.Lastname = dataReader.GetString(2);
                            addressBookModel.Address = dataReader.GetString(3);
                            addressBookModel.City = dataReader.GetString(4);
                            addressBookModel.State = dataReader.GetString(5);
                            addressBookModel.ZipCode = dataReader.GetString(6);
                            addressBookModel.PhoneNumber = dataReader.GetString(7);
                            addressBookModel.EmailId = dataReader.GetString(8);
                            addressBookModel.AddressBookName = dataReader.GetString(9);
                            addressBookModel.Type = dataReader.GetString(10);
                            count++;
                            Console.WriteLine("{0}, {1}, {2}, {4}, {5}, {6}, {7}, {8}, {9}, {10}", addressBookModel.Id, addressBookModel.Firstname, addressBookModel.Lastname,
                                                addressBookModel.Address, addressBookModel.City, addressBookModel.State, addressBookModel.ZipCode, addressBookModel.PhoneNumber,
                                                addressBookModel.EmailId, addressBookModel.AddressBookName, addressBookModel.Type);
                        }
                        Console.WriteLine("New Contacts Added Successfully!");
                        dataReader.Close();
                    }                     
                }
                return count;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
