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

public partial class settings_SFS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblException.Text = "";
            lblMessage.Text = "";
            if (Session["id"] != null)
            {
                pnlVerification.Visible = true;
                pnlSecurity.Visible = false;
                txtUserId.Text = Session["id"].ToString();
                
                if (Session["isReVerified"] != null)
                {
                    string temp = Session["isReVerified"].ToString();
                    if (Session["isReVerified"].ToString() == "true")
                    {
                        pnlVerification.Visible = false;
                        pnlSecurity.Visible = true;

                        lblMessage.Text = "";
                    }
                }
            }
            else
                Response.Redirect("../CMP/index.aspx");
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }

    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        try
        {
            string userId = txtUserId.Text.Trim().ToUpper();
            string password = txtPassword.Text.Trim();

            sec_users_SFS u1;

            if (userId.Contains("CIIT/"))
                u1 = new sec_users_SFS(userId, password, true);
            else
                u1 = new sec_users_SFS(userId, password, false);
            
            if (u1.Roles.Count > 0)
            {
                Session["isReVerified"] = "true";

                pnlVerification.Visible = false;
                pnlSecurity.Visible = true;
                ddlssapQuestionId.SelectedValue = u1.QuestionId.ToString();
                txtssapAnswer.Text = u1.SecAnswer;

                lblMessage.Text = "";
            }
            else
                lblException.Text = "Wrong User ID / Password";
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            sec_users_SFS objUsers = new sec_users_SFS();
            int isUpdated = objUsers.changeSecuritySettings(Session["id"].ToString(), ddlssapQuestionId.SelectedValue, txtssapAnswer.Text.Trim());

            if (isUpdated > 0)
            {
                Session["isReVerified"] = "false";
                lblMessage.Text = "Your security question and answer have been saved. You can reset your password through these.";
            }
            else
                lblException.Text = "Question and Answer couldn't be updated.";
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }

    }
}
