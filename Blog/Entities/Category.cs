using System.Collections.Generic;

namespace Blog.Entities
{
    /// <summary>
    /// Category class.
    /// </summary>
    public partial class Category
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Article = new HashSet<Article>();
        }
    
        /// <summary>
        /// Category ID.
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Category name.
        /// </summary>
        public string Name { get; set; }
    
        /// <summary>
        /// Collection of articles.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Article { get; set; }
    }
}