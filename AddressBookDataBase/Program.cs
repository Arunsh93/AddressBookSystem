using System;

namespace AddressBookDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Address Book Database Details!*******");
            AddressBookDatabase addressBookDataBase = new AddressBookDatabase();
            AddressBookModel addressBook = new AddressBookModel();

            addressBook.Firstname = "Vishwanath";
            addressBook.Lastname = "Hubballi";
            addressBook.Address = "Vivekanand Nagar";
            addressBook.City = "Mundaragi";
            addressBook.State = "Karnataka";
            addressBook.ZipCode = "582120";
            addressBook.PhoneNumber = "9620692457";
            addressBook.EmailId = "Vishwa@gmail.com";
            addressBook.AddressBookName = "Book2";
            addressBook.Type = "Friends";

            //addressBookDataBase.UpdateContact(addressBook);

            //addressBookDataBase.GetPersonDetailsfromDatabase();

            addressBookDataBase.RetriveContactsInPurticularPeriod();
        }
    }
}
