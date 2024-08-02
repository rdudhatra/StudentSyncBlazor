using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services
{
    public class AuthenticationService
    {
        public bool IsAuthenticated { get; set; }

        public void Login()
        {
            IsAuthenticated = true;
        }

        public void Logout()
        {
            IsAuthenticated = false;
        }
    }

}
