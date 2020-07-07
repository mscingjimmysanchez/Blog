using Blog.Entities;
using Blog.Repositories;
using System;

/// <summary>
/// Users deletion page.
/// </summary>
public partial class DeleteUser : System.Web.UI.Page
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
                UserRepository urpUser = new UserRepository();
                User user = urpUser.RetrieveByKey(int.Parse(Request.QueryString["ID"]));

                LblName.Text = user.Name;
                LblLogin.Text = user.Login;
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
            UserRepository urpUser = new UserRepository();

            urpUser.Delete(int.Parse(Request.QueryString["ID"]));
            PnlMessage.Visible = true;
            LblMessage.Text = "The user was deleted correctly.";
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