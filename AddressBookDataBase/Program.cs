using System;

namespace AddressBookDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Address Book Database Details!*******");
            AddressBookDatabase addressBookDataBase = new AddressBookDatabase();
            addressBookDataBase.GetPersonDetailsfromDatabase();
        }
    }
}
