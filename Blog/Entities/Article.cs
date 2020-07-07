using System.Collections.Generic;

namespace Blog.Entities
{
    /// <summary>
    /// Article class.
    /// </summary>
    public partial class Article
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            Comment = new HashSet<Comment>();
            Category = new HashSet<Category>();
        }
    
        /// <summary>
        /// Article ID.
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// User ID.
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Article title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Article contents.
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// Article update date.
        /// </summary>
        public System.DateTime UpdateDate { get; set; }
    
        /// <summary>
        /// User that creates the article.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Collection of comments.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        /// <summary>
        /// Collection of categories.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Category { get; set; }
    }
}