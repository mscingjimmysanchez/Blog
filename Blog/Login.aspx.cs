using Blog.Entities;
using Blog.Repositories;
using System;

/// <summary>
/// Login page.
/// </summary>
public partial class Login : System.Web.UI.Page
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
    /// Login button event click.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void BtnLogin_Click(object sender, System.EventArgs e)
    {
        try
        {
            UserRepository urpUser = new UserRepository();
            User user = urpUser.Validate(TxtLogin.Text, TxtPassword.Text);

            if (user != null)
            {
                Session["login"] = user.Login;
                Response.Redirect("Home.aspx", false);
            }
            else
            {
                TxtLogin.Text = string.Empty;
                PnlMessage.Visible = true;
                LblMessage.Text = "Login or password are invalid.";
            }
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
            TxtLogin.Text = string.Empty;
            TxtPassword.Text = string.Empty;
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }
}