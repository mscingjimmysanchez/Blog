using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Blog.Repositories
{
    /// <summary>
    /// Class managing the categories inside the blog.
    /// </summary>
    public class CategoryRepository
    {
        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public CategoryRepository(){ }

        /// <summary>
        /// Retrieves a list of categories.
        /// </summary>
        /// <returns>List of categories.</returns>
        public List<Category> Retrieve()
        {
            List<Category> lstCategories = null;

            try
            {
                using (var db = new BlogEntities())
                    lstCategories = db.Category.ToList();

                return lstCategories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a category by ID.
        /// </summary>
        /// <param name="ID">Category ID.</param>      
        /// <returns>Category.</returns>
        public Category RetrieveByKey(long ID)
        {
            Category category = null;

            try
            {
                using (var db = new BlogEntities())
                    category = (from c in db.Category
                                where c.ID == ID
                                select c).FirstOrDefault();

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="category">Category.</param>
        public Category Add(Category category)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    db.Category.Add(category);
                    db.SaveChanges();

                    return category;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="category">Category.</param>
        public Category Update(Category category)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();

                    return category;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="ID">Category ID.</param>     
        /// <returns>True if deleted, else false.</returns>
        public bool Delete(long ID)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    Category category = db.Category.SingleOrDefault(t => t.ID == ID);

                    if (category == null) 
                        return false;

                    db.Category.Remove(category);
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
        /// Retrieves a list of categories by article ID.
        /// </summary>
        /// <param name="articleID">Article ID.</param>
        /// <returns>List of categories by article ID.</returns>
        public List<Category> RetrieveByArticleID(long articleID)
        {
            List<Category> lstCategories = null;

            try
            {
                using (var db = new BlogEntities())
                    lstCategories = (from a in db.Article
                                     from c in a.Category
                                     where a.ID == articleID
                                     select c).ToList();

                return lstCategories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}