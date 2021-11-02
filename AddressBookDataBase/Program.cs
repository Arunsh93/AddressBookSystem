using System;
using System.Collections.Generic;

namespace AddressBook_DataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Address Book Database Details!*******");
            AddressBookDatabase addressBookDataBase = new AddressBookDatabase();
            List<AddressBookModel> addressBook = new List<AddressBookModel>()
            {
                new AddressBookModel() {Firstname = "Vinod", Lastname = "Hiral", Address = "MNaka", City = "Gadag", State = "Karnataka", ZipCode = "582120", PhoneNumber = "9620692457", EmailId = "Vinod@gmail.com", AddressBookName = "Book2", Type = "Friends", AddedDate =  new System.DateTime(2021, 11, 02)},
                new AddressBookModel() {Firstname = "Uday", Lastname = "Badiger", Address = "Arahunasi", City = "Gadag", State = "Karnataka", ZipCode = "582120", PhoneNumber = "9535306678", EmailId = "Uday@gmail.com", AddressBookName = "Book2", Type = "Friends", AddedDate = new System.DateTime(2021, 11, 02)},
            };

            /*addressBook.Firstname = "Vishwanath";
            addressBook.Lastname = "Hubballi";
            addressBook.Address = "Vivekanand Nagar";
            addressBook.City = "Mundaragi";
            addressBook.State = "Karnataka";
            addressBook.ZipCode = "582120";
            addressBook.PhoneNumber = "9620692457";
            addressBook.EmailId = "Vishwa@gmail.com";
            addressBook.AddressBookName = "Book2";
            addressBook.Type = "Friends";*/

            //addressBookDataBase.UpdateContact(addressBook);

            //addressBookDataBase.GetPersonDetailsfromDatabase();

            //addressBookDataBase.RetriveContactsInPurticularPeriod();

            //addressBookDataBase.RetriveCountByCityOrState();
            addressBookDataBase.AddNewContactsWithThread(addressBook);
        }
    }
}
