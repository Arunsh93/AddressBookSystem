using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookDataBase
{
    public class AddressBookModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string AddressBookName { get; set; }
        public string Type { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
