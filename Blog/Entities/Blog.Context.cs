using System.Data.Entity;

namespace Blog.Entities
{
    /// <summary>
    /// Context class.
    /// </summary>
    public partial class BlogEntities : DbContext
    {
        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public BlogEntities() : base("name=BlogEntities") { }
    
        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasMany<Category>(a => a.Category)
                                      .WithMany(c => c.Article)
                                      .Map(ac =>
                                      {
                                          ac.MapLeftKey("CategoryID");
                                          ac.MapRightKey("ArticleID");
                                          ac.ToTable("CategoryArticle");
                                      });

            modelBuilder.Entity<Article>().HasMany<Comment>(a => a.Comment)
                                      .WithRequired(c => c.Article)
                                      .HasForeignKey(c => c.ArticleID).WillCascadeOnDelete(true);
        }
    
        /// <summary>
        /// Collection of articles.
        /// </summary>
        public virtual DbSet<Article> Article { get; set; }

        /// <summary>
        /// Collection of categories.
        /// </summary>
        public virtual DbSet<Category> Category { get; set; }

        /// <summary>
        /// Collection of comments.
        /// </summary>
        public virtual DbSet<Comment> Comment { get; set; }

        /// <summary>
        /// Collection of users.
        /// </summary>
        public virtual DbSet<User> User { get; set; }
    }
}