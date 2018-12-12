using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_mpSFS_Public : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        this.pnlPage_n_Menu.Visible = true;
        this.lblPage.Text = "Students Facilitation System";
        if (mnuMain.Items.Count < 1)
            createMenu_SFS();
    }

    private void createMenu_SFS()
    {
        if (Session["Roles"] != null)
        {
            List<string> roles = (List<string>)Session["Roles"];

            if (roles.Contains("DCOs") || roles.Contains("Asst_DCOs"))
            {
                mnuMain.Items.Add(new MenuItem("SFS-Home", "SFS-Home", "", "../SFS/sfs.aspx"));
                mnuMain.Items.Add(new MenuItem("Knowledge Base", "KnowledgeBase", "", "../SFS/KnowledgeBase.aspx"));
                mnuMain.Items.Add(new MenuItem("Downloads", "Downloads", "", "../SFS/download.aspx"));

                mnuMain.Items.Add(new MenuItem("Reset Student Password", "ResetStudentPassword", "", "../SFS/resetPassword.aspx"));
            }
            else
            {
                mnuMain.Items.Add(new MenuItem("SFS-Home", "SFS-Home", "", "../SFS/sfs.aspx"));
                mnuMain.Items.Add(new MenuItem("Student Services", "Student Services", "", "../SFS/tasks.aspx"));
                mnuMain.Items.Add(new MenuItem("Knowledge Base", "KnowledgeBase", "", "../SFS/KnowledgeBase.aspx"));

                if (!roles.Contains("Administration"))
                    mnuMain.Items.Add(new MenuItem("Announcements", "Announcements", "", "../SFS/#"));
                mnuMain.Items.Add(new MenuItem("Downloads", "Downloads", "", "../SFS/download.aspx"));

                //if (!roles.Contains("Student"))
                   // mnuMain.Items.Add(new MenuItem("SPF", "SPF", "", "../SFS/SPFDetail.aspx"));

                //mnuMain.Items.Add(new MenuItem("Settings", "Settings", "", "../SFS/#"));

                //mnuMain.Items[2].ChildItems.Add(new MenuItem("New Query", "NewQuery", "", "../SFS/query_new.aspx"));
                //mnuMain.Items[2].ChildItems.Add(new MenuItem("My Queries", "MyQueries", "", "../SFS/queries.aspx?myQ=1"));


                //Index not hard coded because SPF link not added for students
                //mnuMain.Items[mnuMain.Items.Count - 1].ChildItems.Add(new MenuItem("Change Password", "ChangePassword", "", "../CMP/changePassword.aspx"));

                if (!roles.Contains("Student"))
                {
                    //mnuMain.Items[2].ChildItems.AddAt(0, new MenuItem("Students Queries", "StudentsQueries", "", "../SFS/queries.aspx?myQ=0"));

                    if (!roles.Contains("Administration"))
                    {
                        mnuMain.Items[3].ChildItems.AddAt(0, new MenuItem("New Announcement", "NewAnnouncement", "", "../SFS/announcement_new.aspx"));
                        mnuMain.Items[3].ChildItems.Add(new MenuItem("Dept. Announcements", "DeptAnnouncements", "", "../SFS/announcements.aspx"));
                    }

                    if (roles.Contains("Admin"))
                        mnuMain.Items.Add(new MenuItem("Reset Student Password", "ResetStudentPassword", "", "../SFS/resetPassword.aspx"));
                        //mnuMain.Items[mnuMain.Items.Count - 1].ChildItems.Add(new MenuItem("Reset Student Password", "ResetStudentPassword", "", "../SFS/resetPassword.aspx"));
                }
                else
                {
                    mnuMain.Items[3].NavigateUrl = "../SFS/announcements.aspx";

                    //mnuMain.Items[2].NavigateUrl = "../SFS/#";
                    //mnuMain.Items[2].ChildItems.Add(new MenuItem("New Application", "NewApplication", "", "../SFS/app_apply.aspx"));
                    //mnuMain.Items[2].ChildItems.Add(new MenuItem("My Applications", "MyApplication", "", "../SFS/app_index.aspx"));
                }
            }

            //if (roles.Contains("Student") || roles.Contains("Facilitator_Acc"))
              //  mnuMain.Items.Add(new MenuItem("Fee Confirmation", "FeeConfirmation", "", "../SFS/SFMS-FeeConfirmation.aspx"));

            //if (roles.Contains("Student"))
              //  mnuMain.Items.Add(new MenuItem("Proposed Registration Card", "Proposed Registration Card","" , "../SFS/Cards/" + Session["id"].ToString().ToUpper().Replace("CIIT/","").Replace("/LHR","") + ".pdf", "_blank"));
        }
    }
}
