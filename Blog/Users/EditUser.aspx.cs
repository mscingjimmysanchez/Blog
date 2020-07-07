using Blog.Entities;
using Blog.Repositories;
using System;

/// <summary>
/// Users edition page.
/// </summary>
public partial class EditUser : System.Web.UI.Page
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

                TxtName.Text = user.Name;
                TxtLogin.Text = user.Login;
                TxtPassword.Attributes.Add("value", user.Password);
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
            User user = new User
            {
                ID = int.Parse(Request.QueryString["ID"]),
                Name = TxtName.Text,
                Login = TxtLogin.Text,
                Password = TxtPassword.Text
            };

            UserRepository urpUser = new UserRepository();

            urpUser.Update(user);

            Clean();
            PnlMessage.Visible = true;
            LblMessage.Text = "The user was edited correctly.";
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
            TxtLogin.Text = string.Empty;
            TxtPassword.Attributes.Add("value", string.Empty);
        }
        catch (Exception ex)
        {
            PnlMessage.Visible = true;
            LblMessage.Text = ex.Message;
        }
    }
}