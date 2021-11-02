using System;

public class Class1
{
	public Class1()
	{
        string connectionString = @"Data Source=(LocalDb)\localdb;Initial Catalog=AddressBookSystem;Integrated Security=True";

        public int GetPersonDetailsfromDatabase()
        {
            int Count = 0;
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string retrieveQuery = @"select p.person_id,p.firstname,p.lastname,p.phone,p.email,ab.book_name,ab.book_id,ab.book_type,p.zip ,a.city,a.state from person p inner join address a on p.zip=a.zip inner join Person_addressbook pa on pa.person_id=p.person_id inner join addressbook ab on ab.book_id=pa.book_id";
                    ;
                    SqlCommand sqlCommand = new SqlCommand(retrieveQuery, connection);
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine("Address Book Services Database has following Contact details right now");
                        while (sqlDataReader.Read())
                        {
                            addressBookModel.person_id = sqlDataReader.GetInt32(0);
                            addressBookModel.firstname = sqlDataReader.GetString(1);
                            addressBookModel.lastname = sqlDataReader.GetString(2);
                            addressBookModel.phone = sqlDataReader.GetString(3);
                            addressBookModel.email = sqlDataReader.GetString(4);
                            addressBookModel.book_id = sqlDataReader.GetInt32(6);
                            addressBookModel.city = sqlDataReader.GetString(9);
                            addressBookModel.zip = sqlDataReader.GetInt32(8);
                            addressBookModel.state = sqlDataReader.GetString(10);
                            addressBookModel.book_name = sqlDataReader.GetString(5);
                            addressBookModel.book_type = sqlDataReader.GetString(7);
                            Count++;
                            Console.WriteLine("{0}, {1}, {2}, {4}, {5}, {6}, {7}, {8}, {9}, {10}", addressBookModel.person_id, addressBookModel.firstname, addressBookModel.lastname,
                                addressBookModel.phone, addressBookModel.email, addressBookModel.book_id, addressBookModel.city, addressBookModel.zip, addressBookModel.state, addressBookModel.book_name, addressBookModel.book_type);
                        }
                        Console.WriteLine("New Contact Added Successfully");
                        sqlDataReader.Close();
                    }
                    connection.Close();
                }
                return Count;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
