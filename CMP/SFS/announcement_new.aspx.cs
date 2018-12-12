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

public partial class announcement_new : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblException.Text = "";
            lblMessage.Text = "";

            List<string> Roles = (List<string>)Session["Roles"];
            if (!Roles.Contains("Student") && !Roles.Contains("Administration"))
                pnlAnnouncement_New.Visible = true;
            else
            {
                pnlAnnouncement_New.Visible = false;
                lblMessage.Text = "This is beyond your permission settings. Please contact webmaster@ciitlahore.edu.pk if it seems unfair to you.";

                Server.Transfer("Access_Limited.aspx");
            }

            //createDynamicTable();
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }

    private List<SessionPrograms> getBatches()
    {
        List<SessionPrograms> lstSessionPrograms = new List<SessionPrograms>();

        DataTable dtBatches = student.sp_getBatches_Registered();

        SessionPrograms.LstAllPrograms = new List<string>();

        foreach (DataRow row in dtBatches.Rows)
        {
            Boolean isSessionAdded = false;

            if (!SessionPrograms.LstAllPrograms.Contains(row["Program"].ToString()))
                SessionPrograms.LstAllPrograms.Add(row["Program"].ToString());

            foreach (SessionPrograms obj in lstSessionPrograms) // Go through all Session Programs  
            {
                if (obj.Session == row["Session"].ToString()) // Check if session altready added                
                {
                    isSessionAdded = true;

                    if (obj.LstPrograms.Count == 0) // If no program added to this session then add program 
                        obj.LstPrograms.Add(row["Program"].ToString());
                    else
                    {
                        Boolean isProgramAdded = false;
                        for (int i = 0; i < obj.LstPrograms.Count; i++) // Go through all Programs in this session
                        {
                            if (obj.LstPrograms[i] == row["Program"].ToString()) // Check if program already added to this session yet
                            {
                                isProgramAdded = true;
                                break;
                            }
                        }

                        if (!isProgramAdded) // Add Program when not added to that session yet
                            obj.LstPrograms.Add(row["Program"].ToString());
                    }

                    if (isSessionAdded) // End of loop if session already added
                        break;
                }
            }

            if (!isSessionAdded) // Add session when not added yet and also add program to that session
            {
                string p = row["Program"].ToString();
                SessionPrograms objSessionProgram = new SessionPrograms();
                objSessionProgram.Session = row["Session"].ToString();
                objSessionProgram.LstPrograms.Add(row["Program"].ToString());

                lstSessionPrograms.Add(objSessionProgram);
            }
        }

        return lstSessionPrograms;
    }

    private void createDynamicTable()
    {
        List<SessionPrograms> lstSessionPrograms = getBatches();

        // Dynamic HTMLTable
        HtmlTable objTable = new HtmlTable();
        objTable.Border = 1;

        pnlBatches.Controls.Clear();
        pnlBatches.Controls.Add(objTable);

        // Create Columns Headers 
        HtmlTableRow th = new HtmlTableRow();
        objTable.Rows.Add(th);

        for (int i = 0; i < SessionPrograms.LstAllPrograms.Count; i++)
        {
            if (i == 0)
            {
                HtmlTableCell rh = new HtmlTableCell();
                th.Cells.Add(rh);
            }

            HtmlTableCell td = new HtmlTableCell();
            th.Cells.Add(td);

            Label lblProgram = new Label();
            lblProgram.Text = SessionPrograms.LstAllPrograms[i].ToString(); ;
            lblProgram.Width = 35;

            td.Controls.Add(lblProgram);
        }

        for (int i = 0; i < lstSessionPrograms.Count; i++)
        {
            HtmlTableRow tr = new HtmlTableRow();
            objTable.Rows.Add(tr);

            HtmlTableCell rh = new HtmlTableCell();
            tr.Cells.Add(rh);

            Label lblSession = new Label();
            lblSession.Text = lstSessionPrograms[i].Session;

            objTable.Rows[i + 1].Cells[0].Controls.Add(lblSession);

            for (int j = 0; j < SessionPrograms.LstAllPrograms.Count; j++)
            {
                HtmlTableCell td = new HtmlTableCell();
                tr.Cells.Add(td);

                for (int k = 0; k < lstSessionPrograms[i].LstPrograms.Count; k++)
                {
                    if (SessionPrograms.LstAllPrograms[j] == lstSessionPrograms[i].LstPrograms[k])
                    {
                        CheckBox chkBatch = new CheckBox();
                        chkBatch.ID = lstSessionPrograms[i].Session + '-' + lstSessionPrograms[i].LstPrograms[k];

                        objTable.Rows[i + 1].Cells[j + 1].Controls.Add(chkBatch);
                    }
                }
            }
        }
    }
    
    protected void btnAddAnnouncement_Click(object sender, EventArgs e)
    {
        // Start - Check if extensions of attachments are allowed
        Boolean isExtensionsAllowed = true;
        HttpPostedFile postedFile = fuAttachment.PostedFile;
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
            // Start - Add Announcement Detail
            MyAnnouncement objAnnouncement = new MyAnnouncement();
            string AFrom = Session["id"].ToString();
            int ACategoryId = (int)Session["catId"];
            string ASubject = txtSubject.Text;
            string ADescription = txtDescription.Text;
            DateTime VisibilityStartDate = cpuVisibilityStart.SelectedDate;
            DateTime VisibilityEndDate = cpuVisibilityEnd.SelectedDate;
            int isPublic = 0;
            int ForSpecificStudents = 0;

            int announcementId = objAnnouncement.addAnnouncement(AFrom, ACategoryId, ASubject, ADescription, VisibilityStartDate, VisibilityEndDate, isPublic, ForSpecificStudents);
            // End - Add Announcement Detail

            if (announcementId > -1)
                lblMessage.Text = "Announcement has been uploaded. ";

            if (attachments.Count > 0)
            {
                // Add Attachments
                Boolean isAttachmentsUploaded = AddAttachments(announcementId, attachments);

                // Messages
                if (!isAttachmentsUploaded)
                    lblMessage.Text = "Attachment couldn't be uploaded.";
            }
        }
        else
            lblMessage.Text = "Please select attachment with (.pdf / .doc / .docx / .xls / .xlsx / .txt) or (.jpg / .bmp / .png) extension only";
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
