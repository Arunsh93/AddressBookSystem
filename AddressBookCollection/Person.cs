using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookCollection
{
    class Person
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public int zip { get; set; }

        public string phoneNumber { get; set; }

        public string emailId { get; set; }

        public override string ToString()
        {
            return "First Name :" + firstName + "\nLast Name : " + lastName + "\nAddress : " + address + "\nCity : " + city + "\nState : " + state + "\nZip : " + zip + "\nPhone Number : " + phoneNumber + "\nEmail: " + emailId + "\n";
        }
    }
}
