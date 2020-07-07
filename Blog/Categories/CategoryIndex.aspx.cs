using Blog.Entities;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

/// <summary>
/// Categories index page.
/// </summary>
public partial class CategoryIndex : System.Web.UI.Page
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

                if (lstCategories.Count > 0 && lstCategories != null)
                {
                    GrvCategories.DataSource = lstCategories;
                    GrvCategories.DataBind();
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
                Response.Redirect("EditCategory.aspx?ID=" + e.CommandArgument.ToString());
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
                Response.Redirect("DeleteCategory.aspx?ID=" + e.CommandArgument.ToString());
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