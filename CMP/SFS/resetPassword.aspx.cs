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

using System.Collections.Generic;

public partial class resetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            lblMessage.Text = "";
            lblException.Text = "";

            List<string> Roles = (List<string>)Session["Roles"];

            if (Roles.Contains("Student") || Roles.Contains("Administration"))
                Server.Transfer("Access_Limited.aspx");
        }
        else
            Server.Transfer("../CMP/index.aspx");
    }
    protected void btnGetData_Click(object sender, EventArgs e)
    {
        try
        {
            sec_users_SFS objUsers = new sec_users_SFS();
            string registrationNo = lblRegistrationNo_Prefix.Text + txtRegistrationNo.Text + lblRegistrationNo_Postfix.Text;
            DataTable dtStudentData = objUsers.GetStudentData(registrationNo);

            if (dtStudentData.Rows.Count > 0)
            {
                pnlResetPassword.Visible = true;
                lblRegistrationNo.Text = dtStudentData.Rows[0]["studentId"].ToString();
                lblStudentName.Text = dtStudentData.Rows[0]["SName"].ToString();
                lblGuardianName.Text = dtStudentData.Rows[0]["FatherName"].ToString();
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
            else
            {
                lblMessage.Text = "Registration No. couldn't be found. Please contact SFS administrator";
                pnlResetPassword.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }
    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        try
        {
            sec_users_SFS objUser = new sec_users_SFS();
            int flag = objUser.resetPass_Admin(lblRegistrationNo.Text, txtNewPassword.Text);

            if (flag > 0)
            {
                lblException.Text = "Your password has been changed.";
            }
            else
                lblException.Text = "Password couldn't be changed. Please contact SFS administrator.";
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }
}
