namespace Blog.Entities
{
    /// <summary>
    /// Comment class.
    /// </summary>
    public partial class Comment
    {
        /// <summary>
        /// Comment ID.
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Article ID.
        /// </summary>
        public long ArticleID { get; set; }

        /// <summary>
        /// Comment author's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Comment contents.
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// Comment creation date.
        /// </summary>
        public System.DateTime CreationDate { get; set; }
    
        /// <summary>
        /// Article associated to the comment.
        /// </summary>
        public virtual Article Article { get; set; }
    }
}