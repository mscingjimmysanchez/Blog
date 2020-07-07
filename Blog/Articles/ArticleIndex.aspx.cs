using Blog.Entities;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

/// <summary>
/// Articles index page.
/// </summary>
public partial class ArticleIndex : System.Web.UI.Page
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
                List<Article> lstArticles = arpArticle.Retrieve();

                if (lstArticles.Count > 0 && lstArticles != null)
                {
                    GrvArticles.DataSource = lstArticles;
                    GrvArticles.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Edit link event click.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void LnkEdit_Click(Object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect("EditArticle.aspx?ID=" + e.CommandArgument.ToString());
            }
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }        
    }

    /// <summary>
    /// Delete link event click.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void LnkDelete_Click(Object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect("DeleteArticle.aspx?ID=" + e.CommandArgument.ToString());
            }
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