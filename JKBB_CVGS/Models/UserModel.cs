using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JKBB_CVGS.Models
{
    public class UserModel
    {
        private CVGS_Context db = new CVGS_Context();
        public List<User> userList = new List<User>();

        public UserModel()
        {
            userList = db.Users.ToList();
        }

        public void addUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User getUser(string email) {
            User user = db.Users.Find(email);
            return user;
        }

        public User login(string email, string password)
        {
            return userList.Where(user => user.Email.Equals(email) && 
                user.Password.Equals(password)).FirstOrDefault();
        }

        public List<User> getAllUsers()
        {
            List<User> userList = new List<User>();
            
            return userList;
        }
        /*public int updateUser(User user)
        {
            return db.update(TABLE_USER, values, USER_EMAIL + " = ?",
                    new String[] { String.valueOf(user.getEmail()) });
        }*/
    }

    
}