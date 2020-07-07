using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Blog.Repositories
{
    /// <summary>
    /// Class managing the different users inside the blog.
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public UserRepository() { }

        /// <summary>
        /// Retrieves a list of users.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<User> Retrieve()
        {
            List<User> lstUsers = null;

            try
            {
                using (var db = new BlogEntities())
                    lstUsers = db.User.ToList();

                return lstUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves an user.
        /// </summary>
        /// <param name="ID">User ID.</param>      
        /// <returns>User.</returns>
        public User RetrieveByKey(long ID)
        {
            User user = null;

            try
            {
                using (var db = new BlogEntities())
                    user = (from u in db.User
                            where u.ID == ID
                            select u).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">User.</param>
        public User Add(User user)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    db.User.Add(user);
                    db.SaveChanges();

                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">User.</param>
        public User Update(User user)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="ID">User ID.</param>     
        /// <returns>True if deleted, else false.</returns>
        public bool Delete(long ID)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    User user = db.User.SingleOrDefault(t => t.ID == ID);

                    if (user == null) 
                        return false;

                    db.User.Remove(user);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Validates user's login and password.
        /// </summary>
        /// <returns>True if valid, elss false.</returns>
        public User Validate(string login, string password)
        {
            User user = null;

            try
            {
                using (var db = new BlogEntities())
                {
                    user = (from u in db.User
                            where u.Login == login && u.Password == password
                            select u).FirstOrDefault();
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves an user by login.
        /// </summary>
        /// <param name="login">User login.</param>      
        /// <returns>User.</returns>
        public User RetrieveByLogin(string login)
        {
            User user = null;

            try
            {
                using (var db = new BlogEntities())
                    user = (from u in db.User
                            where u.Login == login
                            select u).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}