using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_mpCMP_Public : System.Web.UI.MasterPage
{

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            pnlLoginAlternative.Visible = true;
            pnlLogin.Visible = false;

            lbLoginStatus.Text = "Logout";
            lblUserId.Text = "Welcome: " + Session["id"].ToString() + "  ";


            if (Session["Roles"] != null)
            {
                List<string> roles = (List<string>)Session["Roles"];

                if (!roles.Contains("Student"))
                {
                    ListItem liItem = new ListItem();
                    liItem.Text = "ERMS - Electronic Record Management System";
                    liItem.Value = "ERMS";
                    ddlQuickLinks.Items.Add(liItem);

                    hlFormsRepository.Visible = true;
                }
            }
            else
            {
                ListItem liItem = new ListItem();
                liItem.Text = "ERMS - Electronic Record Management System";
                liItem.Value = "ERMS";
                ddlQuickLinks.Items.Add(liItem);

                hlFormsRepository.Visible = true;
            }
        }
        else
        {
            lbLoginStatus.Text = "Login";
            //Server.Transfer("../CMP/index.aspx");
        }
    }

    protected void lbLoginStatus_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            pnlLoginAlternative.Visible = true;
            pnlLogin.Visible = false;

            Session.Clear();
            Session.Abandon();
            lbLoginStatus.Text = "Login";
            Server.Transfer("../CMP/index.aspx");
        }
        else
        {
            pnlLogin.Visible = true;
            pnlLoginAlternative.Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblException.Text = "";
        lblMessage.Text = "";
    }

    protected void ddlQuickLinks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlQuickLinks.SelectedValue == "SFS")
            Response.Redirect("../SFS/sfs.aspx");
        else if(ddlQuickLinks.SelectedValue == "ERMS")
            Response.Redirect("../ERMS/erms.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {

            string userId = txtUserId.Text.Trim().ToUpper();
            string password = txtPassword.Text.Trim();

            if (rbAuthentication.Items[1].Selected) //Domain Authentication
            {
                AuthenticateUser cls = new AuthenticateUser("LDAP://172.16.17.19"); //Set Active Directory Path

                //Check from Active Directory if user id and password is authenticated
                bool flag = cls.IsAuthenticated("CIITLahore", userId, password); // we can check cls.path as it has been got and set

                // If authenticated from AD then get user Roles
                if (!flag)
                    lblException.Text = "Wrong User ID / Password";
                else
                {
                    sec_users_CMP u1;

                    u1 = new sec_users_CMP(userId, password);

                    if (u1.Roles.Count == 0)
                    {
                        Session["id"] = u1.UserId;
                        lblException.Text = "User authenticated but no Role assigned";
                    }
                    else
                    {
                        // Going on leaves so bit hurry
                        // Send complete u1 in session later on as code provided to qasim by irfan for UMIS
                        // Category Ids must be entered dynamically and multiple -- Change Structure

                        Session["id"] = u1.UserId;
                        Session["Roles"] = u1.Roles;
                        Session["catId"] = 0;
                    }

                    Server.Transfer("../SFS/sfs.aspx");
                }
            }
            else if (rbAuthentication.Items[0].Selected) //SFS Authentication
            {
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
                        Session["catId"] = 0;

                        //if (u1.QuestionId == 0)
                        //{
                        //    Session["isReVerified"] = "true";
                        //    Server.Transfer("settings_SFS.aspx");
                        //}
                        //else
                            Server.Transfer("../SFS/sfs.aspx");
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
