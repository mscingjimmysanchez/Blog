using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Blog.Repositories
{
    /// <summary>
    /// Class managing the artícles created by the user.
    /// </summary>
    public class ArticleRepository
    {
        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public ArticleRepository(){ }

        /// <summary>
        /// Retrieves a list of articles.
        /// </summary>
        /// <returns>List of articles.</returns>
        public List<Article> Retrieve()
        {
            List<Article> lstArticles = null;

            try
            {
                using (var db = new BlogEntities())            
                    lstArticles = db.Article.ToList();
               
                return lstArticles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves an article by ID.
        /// </summary>
        /// <param name="ID">Article ID.</param>      
        /// <returns>Article.</returns>
        public Article RetrieveByKey(long ID)
        {
            Article article = null;

            try
            {
                using (var db = new BlogEntities())
                    article = (from a in db.Article
                               where a.ID == ID
                               select a).FirstOrDefault();
                
                return article;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new article.
        /// </summary>
        /// <param name="article">Article.</param>
        /// <param name="lstCategories">List of categories.</param>
        public Article Add(Article article, List<Category> lstCategories)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    foreach (Category category in lstCategories)
                        article.Category.Add(db.Category.FirstOrDefault(c => c.ID == category.ID));

                    db.Article.Add(article);
                    db.SaveChanges();

                    return article;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the article.
        /// </summary>
        /// <param name="article">Article.</param>
        /// <param name="lstCategoriesIDs">List of categories IDs.</param>
        public Article Update(Article article, List<int> lstCategoriesIDs)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();

                    article = db.Article.Include(c => c.Category).ToList().Find(ac => ac.ID == article.ID);
                    article.Category.Clear();

                    foreach (int id in lstCategoriesIDs)
                    {
                        Category c = db.Category.Find(id);

                        article.Category.Add(c);
                    }

                    db.SaveChanges();

                    return article;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the article.
        /// </summary>
        /// <param name="ID">Article ID.</param>     
        /// <returns>True if deleted, else false.</returns>
        public bool Delete(long ID)
        {
            try
            {
                using (var db = new BlogEntities())
                {
                    Article article = db.Article.Include("Category").Include("Comment").SingleOrDefault(t => t.ID == ID);

                    if (article == null) 
                        return false;
                    
                    var comments = article.Comment.ToList();

                    foreach (var comment in comments)
                    {
                        article.Comment.Remove(comment);
                        db.Comment.Remove(comment);
                    }

                    db.Article.Remove(article);
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
        /// Retrievea a list of article groups.
        /// </summary>
        /// <returns>List of article groups.</returns>
        public List<ArticleGroup> RetrieveArticleGroups()
        {
            try
            {
                List<ArticleGroup> lstArticleGroups = null;

                using (var db = new BlogEntities())
                    lstArticleGroups = (from a in db.Article
                                        join u in db.User on a.UserID equals u.ID
                                        join c in db.Comment on a.ID equals c.ArticleID into co
                                        from com in co.DefaultIfEmpty()
                                        group a by new { a.ID, a.UpdateDate, a.Title, u.Name, a.Contents, a.Comment.Count } into ag
                                        orderby ag.Key.UpdateDate descending
                                        select new ArticleGroup
                                        {
                                            ID = ag.Key.ID,
                                            UpdateDate = ag.Key.UpdateDate,
                                            Title = ag.Key.Title,
                                            CommentsNumber = ag.Key.Count,
                                            Name = ag.Key.Name,
                                            Contents = ag.Key.Contents
                                        }).ToList();

                return lstArticleGroups;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}