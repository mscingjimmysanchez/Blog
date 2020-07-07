using Blog.Entities;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

/// <summary>
/// Articles edition page.
/// </summary>
public partial class EditArticle : System.Web.UI.Page
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
                CategoryRepository crpCategory = new CategoryRepository();
                List<Category> lstCategories = crpCategory.Retrieve();

                foreach (Category c in lstCategories)
                    LbxCategories.Items.Add(new ListItem(c.Name, c.ID.ToString()));

                ArticleRepository arpArticle = new ArticleRepository();
                Article article = arpArticle.RetrieveByKey(int.Parse(Request.QueryString["ID"]));

                TxtTitle.Text = article.Title;
                TxtContents.Text = article.Contents;
                lstCategories = crpCategory.RetrieveByArticleID(article.ID);

                foreach (ListItem lit in LbxCategories.Items)
                    foreach (Category c in lstCategories)
                        if (int.Parse(lit.Value) == c.ID)
                            lit.Selected = true;
            }
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Edit button event click.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void BtnEdit_Click(object sender, System.EventArgs e)
    {
        try
        {
            UserRepository urpUser = new UserRepository();
            User user = urpUser.RetrieveByLogin(Session["login"].ToString());
            Article article = new Article
            {
                ID = int.Parse(Request.QueryString["ID"]),
                UserID = user.ID,
                Title = TxtTitle.Text,
                Contents = TxtContents.Text,
                UpdateDate = DateTime.Now
            };
            ArticleRepository arpArticle = new ArticleRepository();
            List<int> lstCategoriesIDs = new List<int>();

            foreach (ListItem a in LbxCategories.Items)
                if (a.Selected)
                    lstCategoriesIDs.Add(int.Parse(a.Value));

            arpArticle.Update(article, lstCategoriesIDs);
            Clean();
            PnlMessage.Visible = true;
            LblMessage.Text = "The artícle was edited correctly.";
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
    /// Method to clean the page.
    /// </summary>
    private void Clean()
    {
        try
        {
            TxtTitle.Text = string.Empty;
            TxtContents.Text = string.Empty;

            foreach (ListItem lit in LbxCategories.Items)
                lit.Selected = false;
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }
}