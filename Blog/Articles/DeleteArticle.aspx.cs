using Blog.Entities;
using Blog.Repositories;
using System;

/// <summary>
/// Articles deletion page.
/// </summary>
public partial class DeleteArticle : System.Web.UI.Page
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
                ArticleRepository arpArticle = new ArticleRepository();
                Article article = arpArticle.RetrieveByKey(int.Parse(Request.QueryString["ID"]));

                LblArticle.Text = article.Title;
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
            ArticleRepository arpArticle = new ArticleRepository();

            arpArticle.Delete(int.Parse(Request.QueryString["ID"]));
            PnlMessage.Visible = true;
            LblMessage.Text = "The artícle was deleted correctly.";
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