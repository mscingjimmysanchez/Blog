using Blog.Entities;
using Blog.Repositories;
using System;
using System.Collections.Generic;

/// <summary>
/// Home page.
/// </summary>
public partial class Home : System.Web.UI.Page
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
                LoadPage();
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

    /// <summary>
    /// Method to load the page.
    /// </summary>
    private void LoadPage()
    {
        try
        {
            ArticleRepository arpArticle = new ArticleRepository();
            List<ArticleGroup> lstArticlesGroup = new List<ArticleGroup>();
            CategoryRepository crpCategory = new CategoryRepository();
            List<Category> lstCategories = new List<Category>();

            lstArticlesGroup = arpArticle.RetrieveArticleGroups();

            foreach (ArticleGroup ag in lstArticlesGroup)
            {
                if (ag.CommentsNumber == 1)
                    LblContent.Text += "<h2>" + ag.UpdateDate.ToShortDateString() + " <a href=\"ArticleDetail.aspx?ID=" + ag.ID.ToString() + "\" rel=\"bookmark\" title=\"" + ag.Title.ToString() + "\">" + ag.Title.ToString() + "</a></h2><hr />" + "<h3>By: " + ag.Name.ToString() + ". " + ag.CommentsNumber.ToString() + " Comment.</h3><h4>Categories: ";
                else
                    LblContent.Text += "<h2>" + ag.UpdateDate.ToShortDateString() + " <a href=\"ArticleDetail.aspx?ID=" + ag.ID.ToString() + "\" rel=\"bookmark\" title=\"" + ag.Title.ToString() + "\">" + ag.Title.ToString() + "</a></h2><hr />" + "<h3>By: " + ag.Name.ToString() + ". " + ag.CommentsNumber.ToString() + " Comments.</h3><h4>Categories: ";

                lstCategories = crpCategory.RetrieveByArticleID(int.Parse(ag.ID.ToString()));

                foreach (Category a in lstCategories)
                    LblContent.Text += a.Name + ". ";

                LblContent.Text += "</h4><div>" + ag.Contents.ToString() + "</div>";
            }
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }
}