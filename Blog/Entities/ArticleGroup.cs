using System;

namespace Blog.Entities
{
    /// <summary>
    /// Class managing the artícles created by the user.
    /// </summary>
    public class ArticleGroup
    {
        /// <summary>
        /// Article ID.
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Article update date.
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Article title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Article number of comments.
        /// </summary>
        public long CommentsNumber { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Article contents.
        /// </summary>
        public string Contents { get; set; }
    }
}