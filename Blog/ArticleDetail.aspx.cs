using Blog.Entities;
using Blog.Repositories;
using System;
using System.Collections.Generic;

/// <summary>
/// Article main page.
/// </summary>
public partial class ArticleDetail : System.Web.UI.Page
{
    /// <summary>
    /// Page load event.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void Page_Load(object sender, System.EventArgs e)
    {
        try
        {
            LoadPage();
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Publish button event click.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void BtnPublish_Click(object sender, System.EventArgs e)
    {
        try
        {
            Comment comment = new Comment
            {
                ArticleID = int.Parse(Request.QueryString["ID"]),
                Name = TxtName.Text,
                Contents = TxtComment.Text,
                CreationDate = DateTime.Now
            };

            CommentRepository crpComment = new CommentRepository();

            crpComment.Add(comment);

            Clean();
            LoadPage();
            PnlMessage.Visible = true;
            LblMessage.Text = "The comment was published correctly.";
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Clean button event click.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void BtnClean_Click(object sender, System.EventArgs e)
    {
        try
        {
            Clean();
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Close link event click.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void LnkClose_Click(object sender, System.EventArgs e)
    {
        try
        {
            PnlMessage.Visible = false;
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Method to load the page.
    /// </summary>
    private void LoadPage()
    {
        try
        {
            ArticleRepository arpArticle = new ArticleRepository();
            List<ArticleGroup> lstArticleGroups = new List<ArticleGroup>();
            CategoryRepository crpCategory = new CategoryRepository();
            List<Category> lstCategories = new List<Category>();
            int commentsNumber = 0;

            lstArticleGroups = arpArticle.RetrieveArticleGroups();

            foreach (ArticleGroup ag in lstArticleGroups)
            {
                if (int.Parse(ag.ID.ToString()) == int.Parse(Request.QueryString["ID"]))
                {
                    LblContent.Text = "<h2>" + ag.UpdateDate.ToShortDateString() + " " + ag.Title.ToString() + "</h2><hr /><h3>By: " + ag.Name.ToString() + ".</h3><h4>Categories: ";
                    lstCategories = crpCategory.RetrieveByArticleID(int.Parse(ag.ID.ToString()));

                    foreach (Category a in lstCategories)
                        LblContent.Text += a.Name + ". ";

                    LblContent.Text += "</h4><div>" + ag.Contents.ToString() + "</div>";
                    commentsNumber = int.Parse(ag.CommentsNumber.ToString());

                    break;
                }
            }

            CommentRepository crpComment = new CommentRepository();
            List<Comment> lstComments = new List<Comment>();

            lstComments = crpComment.RetrieveByArticleID(int.Parse(Request.QueryString["ID"]));

            if (commentsNumber > 0)
            {
                LblComments.Text = "<h2>Comments (" + commentsNumber.ToString() + ")</h2><hr />";

                foreach (Comment dr in lstComments)
                    LblComments.Text += "<h3>" + dr.CreationDate.ToShortDateString() + " " + dr.Name + "</h3><h4>" + dr.Contents.ToString() + "</h4>";
            }

            LblComments.Text += "<h2>Write a Comment</h2><hr />";
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Method to clean the page.
    /// </summary>
    private void Clean()
    {
        try
        {
            TxtName.Text = string.Empty;
            TxtComment.Text = string.Empty;
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }
}