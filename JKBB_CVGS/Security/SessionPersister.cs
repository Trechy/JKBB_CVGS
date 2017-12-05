using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JKBB_CVGS.Security
{
    //https://www.youtube.com/watch?v=iNSy97kqGQY
    public static class SessionPersister
    {
        static string emailSessionvar = "Email";
        static string roleSessionvar = "Role";

        public static string Email
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session[emailSessionvar];
                if (sessionVar != null)
                {
                    return sessionVar as string;
                }
                return null;
                
            }
            set
            {
                HttpContext.Current.Session[emailSessionvar] = value;
            }
        }

        public static string Role
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session[roleSessionvar];
                if (sessionVar != null)
                {
                    return sessionVar as string;
                }
                return null;

            }
            set
            {
                HttpContext.Current.Session[roleSessionvar] = value;
            }
        }
    }
}