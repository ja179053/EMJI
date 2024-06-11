using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMJI.Models
{
    public class Client
    {
        public string FirstName, Surname, PhoneNumber, Email, Notes;
        public Guid ID;
        public string FullName { get => FirstName + " " + Surname; }
        public bool CanContact = false;
    }
}
