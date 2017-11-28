using JKBB_CVGS.Models;
using JKBB_CVGS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace JKBB_CVGS.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private User user;

        public CustomPrincipal(User user)
        {
            this.user = user;
            this.Identity = new GenericIdentity(user.Email);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.user.Role.Equals(r));
        }
    }
}