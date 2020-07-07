using Blog.Entities;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

/// <summary>
/// Articles creation page.
/// </summary>
public partial class CreateArticle : System.Web.UI.Page
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
            }
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Create button event click.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void BtnCreate_Click(object sender, System.EventArgs e)
    {
        try
        {
            ArticleRepository arpArticle = new ArticleRepository();
            CategoryRepository crpCategory = new CategoryRepository();
            UserRepository urpUser = new UserRepository();
            User user = urpUser.RetrieveByLogin(Session["login"].ToString());

            Article article = new Article
            {
                UserID = user.ID,
                Title = TxtTitle.Text,
                Contents = TxtContents.Text,
                UpdateDate = DateTime.Now
            };

            List<Category> lstCategories = new List<Category>();
 
            foreach (ListItem lit in LbxCategories.Items)
                if (lit.Selected)
                    lstCategories.Add(crpCategory.RetrieveByKey(int.Parse(lit.Value)));

            arpArticle.Add(article, lstCategories);
            Clean();
            PnlMessage.Visible = true;
            LblMessage.Text = "The artícle was created correctly.";
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