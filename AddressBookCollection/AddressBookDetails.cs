using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookCollection
{
    class AddressBookDetails
    {
        public static List<Person> contacts;
        public static List<Person> searchContact = new List<Person>();
        //Address Book to Dictionary
        public static Dictionary<string, List<Person>> addDictionary = new Dictionary<string, List<Person>>();
        public static void AddContact()
        {
            string addressBookName;
            contacts = new List<Person>();

            while(true)
            {
                Console.WriteLine("Enter the Name of Address Book");
                addressBookName = Console.ReadLine();
                if(addDictionary.Count > 0)
                {
                    if(addDictionary.ContainsKey(addressBookName))
                    {
                        Console.WriteLine("This name Address Book is already Exist!");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Enter Number Of Contacts you want to add");
            int numOfContacts = int.Parse(Console.ReadLine());

            while(numOfContacts > 0)
            {
                Person person = new Person();
                while(true)
                {
                    Console.WriteLine("Enter First name: ");
                    string firstName = Console.ReadLine();
                    if(contacts.Count > 0)
                    {
                        var x = contacts.Find(x => x.firstName.Equals(firstName.ToLower()));
                        if(x != null)
                        {
                            Console.WriteLine("Entering name is Already Exist!");
                        }
                        else
                        {
                            person.firstName = firstName;
                            break;
                        }
                    }
                    else
                    {
                        person.firstName = firstName;
                        break;
                    }                   
                }
                Console.WriteLine("Enter Last name: ");
                person.lastName = Console.ReadLine();
                Console.WriteLine("Enter Address: ");
                person.address = Console.ReadLine();
                Console.WriteLine("Enter City: ");
                person.city = Console.ReadLine();
                Console.WriteLine("Enter State: ");
                person.state = Console.ReadLine();
                Console.WriteLine("Enter Zipcode: ");
                person.zip = int.Parse(Console.ReadLine());
                while (true)
                {
                    Console.WriteLine("Enter Phone Number: ");
                    string phoneNumber = Console.ReadLine();
                    if (phoneNumber.Length == 10)
                    {
                        person.phoneNumber = phoneNumber;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Phone Number Invalid! Phone number should have 10 digits!");
                    }
                }
                while (true)
                {
                    Console.WriteLine("Enter EmailId: ");
                    string email = Console.ReadLine();
                    if (email.Contains("@"))
                    {
                        person.emailId = email;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Emailid Should Contain @ ");
                    }
                }
                contacts.Add(person);
                Console.WriteLine("********************************");
                numOfContacts--;

            }
            addDictionary.Add(addressBookName, contacts);
            Console.WriteLine("Successfully Added!");
        }

        public static void ViewConatcts()
        {
            if (addDictionary.Count > 0)
            {
                Console.WriteLine("*****Yours Contact List*****");
                foreach(KeyValuePair<string, List<Person>> dictionary in addDictionary)
                {
                    Console.WriteLine($"================{dictionary.Key}=================");
                    foreach(var addressBook in dictionary.Value)
                    {
                        PrintValues(addressBook);
                        Console.WriteLine("**********************************");
                    }
                }
            }
            else
            {
                Console.WriteLine("Your AddressBook is Empty!");
            }
        }

        public static void EditContact()
        {
            int f;
            if (contacts.Count > 0)
            {
                Console.WriteLine("Name of Person you want to Edit: ");
                string editName = Console.ReadLine();

                foreach (var name in contacts)
                {
                    if (editName.ToLower() == name.firstName.ToLower())
                    {
                        while (true)
                        {
                            f = 0;
                            Console.WriteLine("1.First name\n2.Last name\n3.Address\n4.City\n5.State\n6.ZipCode\n7.Phone Number\n8.email\n9.Exit");
                            Console.WriteLine("Enter Option You want to edit");
                            int option = int.Parse(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    Console.Write("Edit First name: ");
                                    name.firstName = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Write("Edit Last name: ");
                                    name.lastName = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.Write("Edit Address: ");
                                    name.address = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.Write("Edit City name: ");
                                    name.city = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.Write("Edit State: ");
                                    name.state = Console.ReadLine();
                                    break;
                                case 6:
                                    Console.Write("Edit Zipcode: ");
                                    name.zip = int.Parse(Console.ReadLine());
                                    break;
                                case 7:
                                    while (true)
                                    {
                                        Console.WriteLine("Enter Phone Number: ");
                                        string phoneNumber = Console.ReadLine();
                                        if (phoneNumber.Length == 10)
                                        {
                                            name.phoneNumber = phoneNumber;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Phone Number Invalid! Phone number should have 10 digits!");
                                        }
                                    }
                                    break;
                                case 8:
                                    while (true)
                                    {
                                        Console.WriteLine("Enter EmailId: ");
                                        string email = Console.ReadLine();
                                        if (email.Contains("@"))
                                        {
                                            name.emailId = email;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Emailid Should Contain @ ");
                                        }
                                    }
                                    break;
                                case 9:
                                    Console.WriteLine("Edited!");
                                    f = 1;
                                    break;
                            }
                            if (f == 1)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entered Name is Not in Contact!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Yours Contact List is Empty!");
            }
        }

        public static void DeleteContact()
        {
            int f = 0;
            if (contacts.Count > 0)
            {
                Console.WriteLine("Enter the Name of Person you want to delete");
                string deleteName = Console.ReadLine();

                foreach (var x in contacts)
                {
                    if (deleteName.ToLower() == x.firstName.ToLower())
                    {
                        Console.WriteLine($"Deleted The {x.firstName} contacts");
                        contacts.Remove(x);
                        f = 1;
                        break;
                    }
                }
                if (f == 0)
                {
                    Console.WriteLine("Name is Not in the List!");
                }
            }
            else
            {
                Console.WriteLine("Address book is Empty!");
            }
        }

        public static void SearchDetail()
        {
            string personName;
            Console.WriteLine("1. Search by City name \n2. Search by State name \nEnter your option");
            int searchOption = int.Parse(Console.ReadLine());
            switch (searchOption)
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to search");
                    string cityName = Console.ReadLine();
                    Console.WriteLine("Enter the name of person you want to search");
                    personName = Console.ReadLine();
                    SearchByCityName(cityName, personName);
                    break;
                case 2:
                    Console.WriteLine("Enter the State name in which you want to search");
                    string stateName = Console.ReadLine();
                    Console.WriteLine("Enter the name of person you want to search");
                    personName = Console.ReadLine();
                    
                    SearchByStateName(stateName, personName);
                    break;
                default:
                    return;
            }
        }

        public static void SearchByCityName(string cityName, string personName)
        {
            if(addDictionary.Count>0)
            {
                foreach(KeyValuePair<string, List<Person>> dict in addDictionary)
                {
                    searchContact = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.city.Equals(cityName));
                }

                if(searchContact.Count > 0)
                {
                    foreach(var x in searchContact)
                    {
                        PrintValues(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person Not Found!");
                }
            }
            else
            {
                Console.WriteLine("Address Book is Empty!");
            }
        }

        public static void SearchByStateName(string stateName, string personName)
        {
            if (addDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, List<Person>> dict in addDictionary)
                {
                    searchContact = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.state.Equals(stateName));
                }

                if (searchContact.Count > 0)
                {
                    foreach (var x in searchContact)
                    {
                        PrintValues(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person Not Found!");
                }
            }
            else
            {
                Console.WriteLine("Address Book is Empty!");
            }
        }
        public static void PrintValues(Person person)
        {
            Console.WriteLine($"First Name: {person.firstName}");
            Console.WriteLine($"Last Name : {person.lastName}");
            Console.WriteLine($"Address   : {person.address}");
            Console.WriteLine($"City      : {person.city}");
            Console.WriteLine($"State     : {person.state}");
            Console.WriteLine($"Zip Code  : {person.zip}");
            Console.WriteLine($"Phone Number: {person.phoneNumber}");
            Console.WriteLine($"EmailId   : {person.emailId}");
        }
    }
}
