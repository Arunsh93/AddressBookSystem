﻿using System;

namespace AddressBookCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Welcome to Address Book Using Collection****");

            while (true)
            {
                Console.WriteLine("1. Add Member to Contact List \n2. View Members in Contact list \n3.Exit");
                Console.Write("Enter an Option: ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddressBookDetails.AddContact();
                        break;
                    case 2:
                        AddressBookDetails.ViewConatcts();
                        break;
                    case 3:
                        return;
                }
            }
        }
    }
}