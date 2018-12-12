using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_mpERMS_Public : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        this.pnlPage_n_Menu.Visible = true;
        this.lblPage.Text = "Electronic Record Management System";
        if (mnuMain.Items.Count < 1)
            createMenu_ERMS();
        
    }

    private void createMenu_ERMS()
    {
        try
        {
            if (Session["id"] != null)
            {
                if (Session["Roles"] != null)
                {
                    List<string> roles = (List<string>)Session["Roles"];

                    if (!roles.Contains("Student"))
                    {
                        mnuMain.Items.Add(new MenuItem("SFS-Home", "SFS-Home", "", "../SFS/sfs.aspx"));
                        mnuMain.Items.Add(new MenuItem("Notifications", "Notifications", "", "../ERMS/frmViewNotification.aspx"));
                        mnuMain.Items.Add(new MenuItem("Documents", "Documents", "", "../ERMS/frmOverAllDocuments.aspx"));
                        if (roles.Contains("Facilitator_Reg") || roles.Contains("Admin"))
                            mnuMain.Items.Add(new MenuItem("Student Personal File", "SPF", "", "../ERMS/SPFDetail.aspx"));
                        mnuMain.Items.Add(new MenuItem("CUOnline", "CUOnline", "", "http://cuonline.ciitlahore.edu.pk", "_blank"));
                        mnuMain.Items.Add(new MenuItem("DDP-CUOnline", "DDP-CUOnline", "", "http://ddpcuonline.ciitlahore.edu.pk", "_blank"));
                    }
                }
                else
                {
                    mnuMain.Items.Add(new MenuItem("Notifications", "Notifications", "", "../ERMS/frmViewNotification.aspx"));
                    mnuMain.Items.Add(new MenuItem("Documents", "Documents", "", "../ERMS/frmOverAllDocuments.aspx"));
                }
            }

        }
        catch (Exception ex)
        {
            
            throw;
        }


    }

}
