using System;
using System.Collections.Generic;

namespace AddressBookDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Address Book Database Details!*******");
            AddressBookDatabase addressBookDataBase = new AddressBookDatabase();
            List<AddressBookModel> addressBook = new List<AddressBookModel>()
            {
                new AddressBookModel() {Firstname = "Stuti", Lastname = "Gaddi", Address = "Betageri", City = "Gadag", State = "Karnataka", ZipCode = "582120", PhoneNumber = "9620692457", EmailId = "Stuti@gmail.com", AddressBookName = "Book2", Type = "Friends", AddedDate =  new System.DateTime(2021, 11, 02)},
                new AddressBookModel() {Firstname = "Rachu", Lastname = "Minajagi", Address = "Shahapur", City = "Gadag", State = "Karnataka", ZipCode = "582120", PhoneNumber = "9620127142", EmailId = "Rachu@gmail.com", AddressBookName = "Book2", Type = "Friends", AddedDate = new System.DateTime(2021, 11, 02)},
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
            addressBookDataBase.AddNewContactsWithoutThread(addressBook);
        }
    }
}
