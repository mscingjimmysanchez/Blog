using Blog.Entities;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Comments deletion page.
/// </summary>
public partial class DeleteComment : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                CommentRepository crpComment = new CommentRepository();
                Comment comment = crpComment.RetrieveByKey(int.Parse(Request.QueryString["ID"]));

                LblArticle.Text = comment.Article.Title;
                LblName.Text = comment.Name;
                LblContents.Text = comment.Contents;
            }
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Delete button event click.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void BtnDelete_Click(object sender, System.EventArgs e)
    {
        try
        {
            CommentRepository crpComment = new CommentRepository();

            crpComment.Delete(int.Parse(Request.QueryString["ID"]));
            PnlMessage.Visible = true;
            LblMessage.Text = "The comment was deleted correctly.";
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
}