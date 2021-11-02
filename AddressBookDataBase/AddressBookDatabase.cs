using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_DataBase
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool UpdateContact(AddressBookModel model)
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("SpAddressBookDetails", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", model.Firstname);
                    sqlCommand.Parameters.AddWithValue("@LastName", model.Lastname);
                    sqlCommand.Parameters.AddWithValue("@Address", model.Address);
                    sqlCommand.Parameters.AddWithValue("@City", model.City);
                    sqlCommand.Parameters.AddWithValue("@State", model.State);
                    sqlCommand.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@EmailId", model.EmailId);
                    sqlCommand.Parameters.AddWithValue("@AddressBookName", model.AddressBookName);
                    sqlCommand.Parameters.AddWithValue("@Type", model.Type);

                    connection.Open();
                    var Result = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Contact Updated Successfully!");
                    connection.Close();
                    if (Result == 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool RetriveContactsInPurticularPeriod()
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    string RetriveQuery = @"Select * From AddressBookTable Where AddedDate Between '2021-10-10' and getdate();";
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
                            addressBookModel.AddedDate = dataReader.GetDateTime(11);
                            Console.WriteLine("{0}, {1}, {2}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}", addressBookModel.Id, addressBookModel.Firstname, addressBookModel.Lastname,
                                                addressBookModel.Address, addressBookModel.City, addressBookModel.State, addressBookModel.ZipCode, addressBookModel.PhoneNumber,
                                                addressBookModel.EmailId, addressBookModel.AddressBookName, addressBookModel.Type, addressBookModel.AddedDate);
                        }
                        Console.WriteLine("Contacts Between Given Period!");
                        dataReader.Close();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public int RetriveCountByCityOrState()
        {
            AddressBookModel addressBookModel = new AddressBookModel();
            using (this.connection)
            {
                //SqlCommand sqlCommand = new SqlCommand("SpRetriveContactsByCityOrState", connection);
                //sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue("@State", addressBookModel.Id);

                string RetriveQuery = @"Select * From AddressBookTable Where City = 'Bangalore' OR State = 'Karnataka';";
                SqlCommand sqlCommand = new SqlCommand(RetriveQuery, connection);
                int Count = 0;
                connection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if(dataReader.HasRows)
                {
                    Console.WriteLine("NUMBER OF CONTACTS BELONGS TO CITY OR STATE!");
                    while (dataReader.Read())
                    {
                        Count++;
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
                        addressBookModel.AddedDate = dataReader.GetDateTime(11);
                        Console.WriteLine("{0}, {1}, {2}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}", addressBookModel.Id, addressBookModel.Firstname, addressBookModel.Lastname,
                                            addressBookModel.Address, addressBookModel.City, addressBookModel.State, addressBookModel.ZipCode, addressBookModel.PhoneNumber,
                                            addressBookModel.EmailId, addressBookModel.AddressBookName, addressBookModel.Type, addressBookModel.AddedDate);
                    }
                    Console.WriteLine("NUMBER OF CONTACTS BELONGS TO CITY OR STATE : " + Count);
                }
                return Count;
            }
        }

        public bool AddNewContactsWithoutThread(List<AddressBookModel> model)
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    foreach(AddressBookModel model1 in model)
                    {
                        SqlCommand sqlCommand = new SqlCommand("SpAddNewContacts", connection);
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@FirstName", model1.Firstname);
                        sqlCommand.Parameters.AddWithValue("@LastName", model1.Lastname);
                        sqlCommand.Parameters.AddWithValue("@Address", model1.Address);
                        sqlCommand.Parameters.AddWithValue("@City", model1.City);
                        sqlCommand.Parameters.AddWithValue("@State", model1.State);
                        sqlCommand.Parameters.AddWithValue("@ZipCode", model1.ZipCode);
                        sqlCommand.Parameters.AddWithValue("@PhoneNumber", model1.PhoneNumber);
                        sqlCommand.Parameters.AddWithValue("@EmailId", model1.EmailId);
                        sqlCommand.Parameters.AddWithValue("@AddressBookName", model1.AddressBookName);
                        sqlCommand.Parameters.AddWithValue("@Type", model1.Type);
                        sqlCommand.Parameters.AddWithValue("@AddedDate", model1.AddedDate);

                        connection.Open();
                        var Result = sqlCommand.ExecuteNonQuery();
                        Console.WriteLine("Contact Updated Successfully!");
                        connection.Close();
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int AddNewContactsWithThread(List<AddressBookModel> model)
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    foreach (AddressBookModel model1 in model)
                    {
                        Task thread = new Task(() =>
                        {
                            SqlCommand sqlCommand = new SqlCommand("SpAddNewContacts", connection);
                            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@FirstName", model1.Firstname);
                            sqlCommand.Parameters.AddWithValue("@LastName", model1.Lastname);
                            sqlCommand.Parameters.AddWithValue("@Address", model1.Address);
                            sqlCommand.Parameters.AddWithValue("@City", model1.City);
                            sqlCommand.Parameters.AddWithValue("@State", model1.State);
                            sqlCommand.Parameters.AddWithValue("@ZipCode", model1.ZipCode);
                            sqlCommand.Parameters.AddWithValue("@PhoneNumber", model1.PhoneNumber);
                            sqlCommand.Parameters.AddWithValue("@EmailId", model1.EmailId);
                            sqlCommand.Parameters.AddWithValue("@AddressBookName", model1.AddressBookName);
                            sqlCommand.Parameters.AddWithValue("@Type", model1.Type);
                            sqlCommand.Parameters.AddWithValue("@AddedDate", model1.AddedDate);

                            connection.Open();
                            var Result = sqlCommand.ExecuteNonQuery();
                            connection.Close();
                        });
                        thread.Start();
                    }
                    Console.WriteLine(model.Count);
                    return model.Count;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }   
}
