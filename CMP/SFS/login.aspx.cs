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

public partial class PL_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblException.Text = "";
        lblMessage.Text = "";
    }
    protected void btnLogin_Click(object sender, EventArgs e)
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
            
            if (u1.Roles.Count == 0)
                lblException.Text = "Wrong User ID / Password";
            else
            {
                Boolean flag = true;

                if (!u1.IsApproved) { lblException.Text = "Your login has not yet been approved."; flag = false; }
                if (u1.IsLockedOut) { lblException.Text = "Your login has been locked."; flag = false; }

                if (flag)
                {
                    // Going on leaves so bit hurry
                    // Send complete u1 in session later on as code provided to qasim by irfan for UMIS
                    // Category Ids must be entered dynamically and multiple -- Change Structure

                    Session["id"] = u1.UserId;
                    Session["Roles"] = u1.Roles;

                    if (u1.QuestionId == 0)
                    {
                        Session["isReVerified"] = "true";
                        Server.Transfer("settings_SFS.aspx");
                    }
                    else
                    {
                        List<string> roles = (List<string>)Session["Roles"];

                        if (roles.Contains("Student"))
                        {
                            Session["catId"] = -1;
                            string url = "queries.aspx?myQ=1";
                            Response.Redirect(url);
                        }
                        if (roles.Contains("Facilitator_Reg"))
                        {
                            Session["catId"] = 2;
                            string url = "queries.aspx?myQ=0";
                            Response.Redirect(url);
                        }
                        if (roles.Contains("Facilitator_Acc"))
                        {
                            Session["catId"] = 1;
                            string url = "queries.aspx?myQ=0";
                            Response.Redirect(url);
                        }
                        if (roles.Contains("Facilitator_Exam"))
                        {
                            Session["catId"] = 3;
                            string url = "queries.aspx?myQ=0";
                            Response.Redirect(url);
                        }
                        if (roles.Contains("Admin") || roles.Contains("Admin_IT"))
                        {
                            Session["catId"] = -1;
                            string url = "queries.aspx?myQ=0";
                            Response.Redirect(url);
                        }
                        if (roles.Contains("DCOs") || roles.Contains("Asst_DCOs"))
                        {
                            string url = "KnowledgeBase.aspx";
                            Response.Redirect(url);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {            
            lblException.Text = ex.Message;
        }
    }
}
