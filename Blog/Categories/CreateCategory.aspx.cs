using Blog.Entities;
using Blog.Repositories;
using System;
using System.Web.UI;

/// <summary>
/// Categories creation page.
/// </summary>
public partial class CreateCategory : System.Web.UI.Page
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
            Category category = new Category
            {
                Name = TxtName.Text
            };
            CategoryRepository crpCategory = new CategoryRepository();

            crpCategory.Add(category);
            Clean();
            PnlMessage.Visible = true;
            LblMessage.Text = "The category was created correctly.";
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
            TxtName.Text = string.Empty;
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }
}