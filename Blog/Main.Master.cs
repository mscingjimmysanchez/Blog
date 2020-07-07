using System;

/// <summary>
/// Master page.
/// </summary>
public partial class Main : System.Web.UI.MasterPage
{
    /// <summary>
    /// Page load event.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["login"] == null)
            {
                LnkLogin.Visible = true;
                LnkUser.Visible = false;
                LnkLogout.Visible = false;
            }
            else
            {
                LnkLogin.Visible = false;
                LnkUser.Visible = true;
                LnkUser.Text = Session["login"].ToString();
                LnkLogout.Visible = true;
            }
        }
    }

    /// <summary>
    /// Logout link event click.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    protected void LnkLogout_Click(object sender, EventArgs e)
    {
        LnkUser.Visible = false;
        LnkLogout.Visible = false;
        Session.Remove("login");
        Response.Redirect("~/Home.aspx", false);
    }
}