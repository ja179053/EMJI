using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMJI.Components.Classes
{
    public class User
    {
        public UserAccess permissions;
        public User() {
            permissions = UserAccess.Staff;
#if DEBUG
            permissions = UserAccess.Admin;
#endif

        }
    }
    public enum UserAccess
    {
        Client,
        Staff,
        Admin
    }
}
