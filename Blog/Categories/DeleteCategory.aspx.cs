using Blog.Entities;
using Blog.Repositories;
using System;

/// <summary>
/// Categories deletion page.
/// </summary>
public partial class DeleteCategory : System.Web.UI.Page
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
                Category category = crpCategory.RetrieveByKey(int.Parse(Request.QueryString["ID"]));

                LblCategory.Text = category.Name;
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
            CategoryRepository crpCategory = new CategoryRepository();

            crpCategory.Delete(int.Parse(Request.QueryString["ID"]));
            PnlMessage.Visible = true;
            LblMessage.Text = "The category was deleted correctly.";
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