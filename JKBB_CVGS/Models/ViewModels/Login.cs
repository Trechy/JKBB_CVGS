using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JKBB_CVGS.Models.ViewModels
{
    public class Login
    {
        /// <summary>
        /// Checks if employee with given password exists in the database
        /// </summary>
        /// <param name="_email">Email</param>
        /// <param name="_password">Password</param>
        /// <returns>True if employee exist and password is correct</returns>
        public bool IsValid(string _email, string _password)
        {
            bool flag = false;
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Member] WHERE [Email]='" + _email +
                    "' AND [Password]='" + password + "'", conn);
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
                return flag;
            }
        }

        private string userName;
        private string email;
        private string password;
        private string firstName;
        private string lastName;

        public string UserName { get => userName; set => userName = value; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

    }
}