using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Blog.Repositories
{
    /// <summary>
    /// Class managing the comments added to each article.
    /// </summary>
    public class CommentRepository
    {
        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public CommentRepository() { }

        /// <summary>
        /// Retrieves a list of commnets.
        /// </summary>
        /// <returns>List of comments.</returns>
        public List<Comment> Retrieve()
        {
            List<Comment> lstComments = null;

            try
            {
                using (var db = new BlogEntities())
                    lstComments = db.Comment.Include("Article").ToList();

                return lstComments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a comment by ID.
        /// </summary>
        /// <param name="ID">Comment ID.</param>      
        /// <returns>Comment.</returns>
        public Comment RetrieveByKey(long ID)
        {
            Comment comment = null;

            try
            {
                using (var db = new BlogEntities())
                    comment = (from c in db.Comment.Include("Article")
                               where c.ID == ID
                               select c).FirstOrDefault();

                return comment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new comment.
        /// </summary>
        /// <param name="comment">Comment.</param>
        public Comment Add(Comment comment)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    db.Comment.Add(comment);
                    db.SaveChanges();

                    return comment;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="comment">Comment.</param>
        public Comment Update(Comment comment)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    db.Entry(comment).State = EntityState.Modified;
                    db.SaveChanges();

                    return comment;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the comment.
        /// </summary>
        /// <param name="ID">Comment ID.</param>     
        /// <returns>True if deleted, else false.</returns>
        public bool Delete(long ID)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    Comment comment = db.Comment.SingleOrDefault(t => t.ID == ID);

                    if (comment == null) 
                        return false;

                    db.Comment.Remove(comment);
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
        /// Retrieves a list of comments by article ID.
        /// </summary>
        /// <param name="articleID">Article ID.</param>
        /// <returns>List of comments by article ID.</returns>
        public List<Comment> RetrieveByArticleID(long articleID)
        {
            List<Comment> lstComments = null;

            try
            {
                using (var db = new BlogEntities())
                    lstComments = (from c in db.Comment
                                   where c.ArticleID == articleID
                                   orderby c.CreationDate descending
                                   select c).ToList();

                return lstComments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}