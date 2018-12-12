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

public partial class Announcement_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["id"] != null)
            {
                lblException.Text = "";
                lblMessage.Text = "";

                List<string> Roles = (List<string>)Session["Roles"];
                if (!Roles.Contains("Student") && !Roles.Contains("Administration"))
                {
                    fvAnnouncementDetail.Visible = true;
                    if (!Page.IsPostBack)
                    {

                        int AId = Convert.ToInt32(Request.QueryString["AId"]);

                        MyAnnouncement objAnnouncement = new MyAnnouncement();
                        DataTable dtAnnouncement = objAnnouncement.getAnnouncement_Edit(AId);

                        //Start - Check Announcement access previliges 


                        //End - Check Announcement access previliges 

                        fvAnnouncementDetail.DataSource = dtAnnouncement;
                        fvAnnouncementDetail.DataBind();
                    }
                }
                else
                {
                    fvAnnouncementDetail.Visible = false;
                    lblMessage.Text = "This is beyond your permission settings. Please contact webmaster@ciitlahore.edu.pk if it seems unfair to you.";

                    Server.Transfer("Access_Limited.aspx");
                }
            }
            else
                Server.Transfer("../CMP/index.aspx");
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }

    }
    protected void btnEditAnnouncement_Click(object sender, EventArgs e)
    {
        try
        {
            // Start - Check if extensions of attachments are allowed
            Boolean isExtensionsAllowed = true;
            HttpPostedFile postedFile = ((FileUpload)fvAnnouncementDetail.FindControl("fuAttachment")).PostedFile;
            string fileName = System.IO.Path.GetFileName(postedFile.FileName);
            string fileExtension = System.IO.Path.GetExtension(fileName);
            MyAttachment objAttachment = new MyAttachment();
            List<HttpPostedFile> attachments = new List<HttpPostedFile>();
            if (objAttachment.isPermittedExtension(fileExtension))
                attachments.Add(postedFile);
            else
                isExtensionsAllowed = false;
            // End - Check if extensions of attachments are allowed

            if (isExtensionsAllowed || fileExtension == "")
            {
                // Start - Edit Announcement Detail
                MyAnnouncement objAnnouncement = new MyAnnouncement();
                int AnnouncementId = Convert.ToInt32(Request.QueryString["AId"].ToString());
                string ASubject = ((TextBox)fvAnnouncementDetail.FindControl("txtSubject")).Text;
                string ADescription = ((TextBox)fvAnnouncementDetail.FindControl("txtDescription")).Text;
                DateTime VisibilityStartDate = ((eWorld.UI.CalendarPopup)fvAnnouncementDetail.FindControl("cpuVisibilityStart")).SelectedDate;
                DateTime VisibilityEndDate = ((eWorld.UI.CalendarPopup)fvAnnouncementDetail.FindControl("cpuVisibilityEnd")).SelectedDate;
                int isPublic = 0;
                int ForSpecificStudents = 0;
                string lastUpdatedBy = Session["id"].ToString();

                int rowsAffected = objAnnouncement.UpdateAnnouncementDetail(AnnouncementId, ASubject, ADescription, VisibilityStartDate, VisibilityEndDate, isPublic, ForSpecificStudents, lastUpdatedBy);
                // End - Edit Announcement Detail

                if (rowsAffected > 0)
                    lblMessage.Text = "Announcement has been updated. ";

                if (attachments.Count > 0)
                {
                    // Add Attachments
                    Boolean isAttachmentsUploaded = AddAttachments(AnnouncementId, attachments);

                    // Messages
                    if (!isAttachmentsUploaded)
                        lblMessage.Text = "Attachment couldn't be uploaded.";
                }
            }
            else
                lblMessage.Text = "Please select attachment with (.pdf / .doc / .docx / .xls / .xlsx / .txt) or (.jpg / .bmp / .png) extension only";
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }

    private Boolean AddAttachments(int AnnouncementId, List<HttpPostedFile> attachments)
    {
        
            int attachmentCount = attachments.Count;
            int attachmentUploaded_Total = 0;
            for (int i = 0; i < attachmentCount; i++)
            {
                HttpPostedFile fuAttachment = attachments[i];
                string fileName = System.IO.Path.GetFileName(fuAttachment.FileName);

                string fileExtension = System.IO.Path.GetExtension(fileName);
                string filePath = DateTime.Now.Millisecond.ToString() + DateTime.Now.ToBinary().ToString() + fileExtension;
                string attachmentPath = "Attachments/Announcements/" + filePath;

                // Save Attachment to disk
                fuAttachment.SaveAs(Server.MapPath(attachmentPath));

                MyAnnouncement objAnnouncement = new MyAnnouncement();
                int attachmentUploaded = objAnnouncement.addAttachments(AnnouncementId, fileName, attachmentPath);

                if (attachmentUploaded > 0)
                    attachmentUploaded_Total++;
            }

            if (attachmentCount == attachmentUploaded_Total)
                return true;
            else
                return false;
        
    }
}
