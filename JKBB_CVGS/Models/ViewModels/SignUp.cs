﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JKBB_CVGS.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace JKBB_CVGS.Models.ViewModels
{
    public class SignUp
    {
        public SignUp()
        {
            Members = new HashSet<Member>();
        }
        //public bool IsValid(string password, string _password)
        //{
        //    //bool flag = false;
        //    //string connString = ConfigurationManager.ConnectionStrings["CVGS_Context"].ConnectionString;
        //    //using (SqlConnection conn = new SqlConnection(connString))
        //    //{
        //    //    conn.Open();
        //    //    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[User] WHERE [Email]='" + _email +
        //    //        "' AND [Password]='" + password + "'", conn);
        //    //    flag = Convert.ToBoolean(cmd.ExecuteScalar());
        //    //    return flag;
        //    //}
        //}
        public int MemberID { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        //[Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public virtual ICollection<Member> Members { get; set; }

    }
}