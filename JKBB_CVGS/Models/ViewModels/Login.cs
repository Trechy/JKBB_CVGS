using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;

namespace JKBB_CVGS.Models.ViewModels
{
    public class Login
    {
        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_email">Email</param>
        /// <param name="_password">Password</param>
        /// <returns>True if employee exist and password is correct</returns>
        public bool IsValid(string _email, string _password)
        {
            bool flag = false;
            bool flag2 = false;
            string connString = ConfigurationManager.ConnectionStrings["CVGS_Context"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Member] WHERE [Email]='" + _email +
                    "' AND [Password]='" + password + "'", conn);
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Employee] WHERE [Email]='" + _email +
                    "' AND [Password]='" + password + "'", conn);
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
                flag2 = Convert.ToBoolean(cmd2.ExecuteScalar());
                if (flag == true || flag2 == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private string email;
        private string password;

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get => password; set => password = value; }

    }
}