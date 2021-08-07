using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_AddressBook
{
    public class AddressBookData
    {
        public int personId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public long phone { get; set; }
        public string emailId { get; set; }
        public DateTime date { get; set; }
        public int personTypeId { get; set; }
        public string personType { get; set; }
        public int addressBookId { get; set; }
        public string addressBookName { get; set; }
    }
}
