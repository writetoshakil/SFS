using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class changePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
            Server.Transfer("../CMP/index.aspx");
        else
        {
            this.rbSFS.Attributes.Add("onclick", "javascript:toggleBoxTab('rhboxtab_', '1', '#000000', '#BDD4FD'); showBoxDiv('rhbox_', 'rhbox_SFS')");
            this.rbDomain.Attributes.Add("onclick", "javascript:toggleBoxTab('rhboxtab_', '2', '#000000', '#BDD4FD'); showBoxDiv('rhbox_', 'rhbox_Domain')");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblException.Text = "";

        try
        {
            if (Session["id"] != null)
            {
                if (rbSFS.Checked)
                {
                    lblException.Text = "";

                    sec_users_SFS objUser = new sec_users_SFS();
                    int flag = objUser.changePassword(Session["id"].ToString(), txtOldPassword.Text, txtNewPassword.Text);

                    if (flag > 0)
                    {
                        lblException.Text = "Your password has been changed.";
                    }
                    else
                        lblException.Text = "Wrong old password.";
                }
            }
            else
                Response.Redirect("../CMP/index.aspx");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
       
    }

    protected void btnSubmit_Domain_Click(object sender, EventArgs e)
    {
        lblException.Text = "";
        string errorMessage;
        Int32 errorCode = 0;

        try
        {
            if (Session["id"] != null)
            {
                if (rbDomain.Checked)
                {
                    AuthenticateUser cls = new AuthenticateUser("LDAP://172.16.17.19"); //Set Active Directory Path

                    string userId = Session["id"].ToString();
                    string oldPassword = txtOldPassword_Domain.Text.Trim();
                    string newPassword = txtNewPassword_Domain.Text.Trim();

                    //Check from Active Directory if user id and password is authenticated
                    bool flag = cls.IsAuthenticated("CIITLahore", userId, oldPassword); // we can check cls.path as it has been got and set

                    // If authenticated from AD then get user Roles
                    if (!flag)
                        lblException.Text = "Wrong User ID / Password";
                    else
                    {
                        cls.changePassword(cls.path, userId, oldPassword, newPassword);

                        lblMessage.Text = "Password has been changed.";
                    }
                }
            }
            else
                Response.Redirect("../CMP/index.aspx");
        }
        catch (Exception ex)
        {
            if (ex is System.Reflection.TargetInvocationException)
            {
                errorMessage = ex.InnerException.ToString();
                try
                {
                    string HResult = errorMessage.Substring(errorMessage.IndexOf("0x") + 2, 8);
                    errorCode = Int32.Parse(HResult, System.Globalization.NumberStyles.HexNumber);
                    lblException.Text = "Error changing password. Reason: " + errorMessage;
                }
                catch
                {
                    errorCode = -1;
                }
            }
            else
                lblMessage.Text = ex.Message;
        }

    }

}
