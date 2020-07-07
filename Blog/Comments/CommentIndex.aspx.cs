using Blog.Entities;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

/// <summary>
/// Comments index page.
/// </summary>
public partial class CommentIndex : System.Web.UI.Page
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
                List<Comment> lstComments = crpComment.Retrieve();

                if (lstComments.Count > 0 && lstComments != null)
                {
                    GrvComments.DataSource = lstComments;
                    GrvComments.DataBind();
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
                Response.Redirect("DeleteComment.aspx?ID=" + e.CommandArgument.ToString());
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