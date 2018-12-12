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

public partial class announcement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
                lblException.Text = "";
                lblMessage.Text = "";

                if (!Page.IsPostBack)
                {
                    Boolean isPublic = getAnnouncementData();

                    if (Session["id"] != null)
                    {
                        List<string> Roles = (List<string>)Session["Roles"];
                        if (!Roles.Contains("Student") && !Roles.Contains("Administration"))
                            btnEdit.Visible = true;
                    }
                    else if (!isPublic)
                    {
                        Server.Transfer("../CMP/index.aspx");
                    }
                }
            
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            int AId = Convert.ToInt32(Request.QueryString["AId"]);
            Server.Transfer("Announcement_Edit.aspx?AId=" + AId.ToString());            
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }

    private Boolean getAnnouncementData()
    {
        int AId = Convert.ToInt32(Request.QueryString["AId"]);

        MyAnnouncement objAnnouncement = new MyAnnouncement();
        DataTable dtAnnouncement = objAnnouncement.getAnnouncementDetail(AId);

        int AVId = Convert.ToInt32(dtAnnouncement.Rows[0]["AVId"].ToString());

        //Start - Check Announcement access previliges 


        //End - Check Announcement access previliges 

        fvAnnouncementDetail.DataSource = dtAnnouncement;
        fvAnnouncementDetail.DataBind();

        //Get Attachments

        foreach (DataRow row in dtAnnouncement.Rows)
        {
            HyperLink hlAttachment = new HyperLink();
            hlAttachment.Target = "_Blank";
            hlAttachment.NavigateUrl = row["AttachmentPath"].ToString();
            hlAttachment.Text = row["AttachmentTitle"].ToString() + "</br>";

            pnlAttachments.Controls.Add(hlAttachment);
        }

        if (AVId == 0)
            return true;
        else
            return false;

    }
}
