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

public partial class SFS_app_Bonafide_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["id"] != null)
            {
                lblException.Text = "";
                lblMessage.Text = "";

                if (!Page.IsPostBack)
                {
                    getApplicationDetail();

                   
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

    private void getApplicationDetail()
    {
        int TId = Convert.ToInt32(Request.QueryString["TId"]);
        applications objApplication = new applications();
        DataTable dtApplicationDetail = objApplication.getApplication_Detail(TId);

        fvApplicationDetail.DataSource = dtApplicationDetail;
        fvApplicationDetail.DataBind();

        List<string> Roles = (List<string>)Session["Roles"];
        if (!Roles.Contains("Student"))
        {
            if(dtApplicationDetail.Rows[0]["isDoc_Created"].ToString() == "0")
                ((HyperLink)fvApplicationDetail.FindControl("hlUpdateStatus_Creation")).Visible = true;
            else
                ((HyperLink)fvApplicationDetail.FindControl("hlUpdateStatus_Creation")).Visible = false;

            if (dtApplicationDetail.Rows[0]["isDoc_Issued"].ToString() == "0")
                ((HyperLink)fvApplicationDetail.FindControl("hlIssue_Document")).Visible = true;
            else
                ((HyperLink)fvApplicationDetail.FindControl("hlIssue_Document")).Visible = false;
        }        
    }

    protected void btnUpdateStatus_Creation_Click(object sender, EventArgs e)
    {
        List<string> Roles = (List<string>)Session["Roles"];
        if (!Roles.Contains("Student"))
        {
            int TId = Convert.ToInt32(Request.QueryString["TId"]);
            string userId = Session["id"].ToString();

            applications objApplicaiton = new applications();
            int RowsUpdated = objApplicaiton.updateStatus_Doc_Creation(TId, userId);

            if (RowsUpdated > 0)
                getApplicationDetail();
        }
        else
            lblMessage.Text = "You are not allowed. This must not be seen to you. Please inform SFS administrator";
    }

    protected void btnIssue_Document_Click(object sender, EventArgs e)
    {
        List<string> Roles = (List<string>)Session["Roles"];
        if (!Roles.Contains("Student"))
        {
            int TId = Convert.ToInt32(Request.QueryString["TId"]);
            string userId = Session["id"].ToString();

            applications objApplicaiton = new applications();
            int RowsUpdated = objApplicaiton.updateStatus_Doc_Issuance(TId, userId);

            if (RowsUpdated > 0)
                getApplicationDetail();
        }
        else
            lblMessage.Text = "You are not allowed. This must not be seen to you. Please inform SFS administrator";
    }

    protected void btnSave_Reply_Click(object sender, EventArgs e)
    {
        try
        {
            int queryId = Convert.ToInt32(Request.QueryString["TId"]);
            string CFrom = Session["id"].ToString();
            string CDescription = txtDescription.Text;
            // Start - Attachmentl
            string attachmentPath = "";
            string fileName = System.IO.Path.GetFileName(fuAttachment.PostedFile.FileName);
            if (fuAttachment.PostedFile != null)
            {
                string filePath = "";
                string fileExtension = System.IO.Path.GetExtension(fileName);

                if (fileExtension == "" || fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx" || fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".bmp" || fileExtension == ".png")
                {
                    filePath = DateTime.Now.Millisecond.ToString() + DateTime.Now.ToBinary().ToString() + fileExtension;
                    attachmentPath = "Attachments/" + filePath;
                    fuAttachment.PostedFile.SaveAs(Server.MapPath(attachmentPath));

                    MyQuery objQuery = new MyQuery();
                    int rowsAdded = objQuery.addConversation(queryId, CFrom, CDescription, attachmentPath, fileName);

                    if (rowsAdded > 0)
                        lblMessage.Text = "Your reply has been saved.";

                    getConversation();
                    pnlAddConversation.Visible = false;

                    ((Button)fvApplicationDetail.FindControl("btnReply")).Visible = true;

                    List<string> Roles = (List<string>)Session["Roles"];
                }
                else
                {
                    lblMessage.Text = "Please select file with (.pdf / .doc / .docx / .xls / .xlsx) or (.jpg / .bmp / .png) extension only for abstract";
                }
            }
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
        finally
        {
            txtDescription.Text = "";
        }
    }

    private void getConversation()
    {
        try
        {
            pnlQueryConversation.Controls.Clear();

            int queryId = Convert.ToInt32(Request.QueryString["TId"]);
            MyQuery objQuery = new MyQuery();

            // Start - All Conversation including replies and internal conversation
            DataTable dtConversation = objQuery.getQueryConversation(queryId);

            foreach (DataRow row in dtConversation.Rows)
            {
                string conversationId = row["conversationId"].ToString();
                //int conversationType = Convert.ToInt32(row["ConversationType"].ToString());
                Label lblConversationHeader = new Label();

                lblConversationHeader.Text = "<br/> <font color='blue'>On " + row["CreatedOn"].ToString() + ", " + row["CFrom"].ToString().ToUpper();
                if (row["SName"].ToString() != "")
                    lblConversationHeader.Text += " (" + row["SName"].ToString() + ")";

                //if (conversationType == 1)
                lblConversationHeader.Text += " wrote:</font> <br/>";

                pnlQueryConversation.Controls.Add(lblConversationHeader);

                
                Label lblConversationDetail = new Label();
                lblConversationDetail.Text = row["CDescription"].ToString() + "<br/>";
                pnlQueryConversation.Controls.Add(lblConversationDetail);
                


                // Show Attachment(s)
                HyperLink hlAttachment = new HyperLink();
                hlAttachment.Target = "_Blank";
                hlAttachment.NavigateUrl = row["CAttachmentPath"].ToString();
                hlAttachment.Text = row["CAttachmentTitle"].ToString();
                pnlQueryConversation.Controls.Add(hlAttachment);

                Label lblSeparator = new Label();
                if (hlAttachment.Text != "")
                    lblSeparator.Text = "<Br/>";


                lblSeparator.Text += "---------------------------------------------------------------------------<br/>";
                pnlQueryConversation.Controls.Add(lblSeparator);
            }

            // End - All Conversation

            // Start - Original Query Detail
            DataTable dtQueryDetail = objQuery.getQueryDetail(queryId);
            Label conversationHeader = new Label();

            string CreatedBy_Id = dtQueryDetail.Rows[0]["CreatedBy_Id"].ToString().ToUpper();
            //conversationHeader.Text = "<br/> <font color='blue'>On " + dtQueryDetail.Rows[0]["CreatedOn"].ToString() + ", " + dtQueryDetail.Rows[0]["CreatedBy_Id"].ToString() + " wrote:</font> <br/>";
            conversationHeader.Text = "<br/> <font color='blue'>On " + dtQueryDetail.Rows[0]["CreatedOn"].ToString() + ", " + CreatedBy_Id;
            if (CreatedBy_Id != "")
                conversationHeader.Text += " (" + dtQueryDetail.Rows[0]["SName"].ToString() + ")";
            conversationHeader.Text += " wrote:</font> <br/>";

            pnlQueryConversation.Controls.Add(conversationHeader);

            Label conversationDetail = new Label();
            conversationDetail.Text = dtQueryDetail.Rows[0]["QDescription"].ToString() + "<br/><br/>";
            pnlQueryConversation.Controls.Add(conversationDetail);

            HyperLink hlAttachment_Query = new HyperLink();
            hlAttachment_Query.Target = "_Blank";
            hlAttachment_Query.NavigateUrl = dtQueryDetail.Rows[0]["QAttachmentPath"].ToString();
            hlAttachment_Query.Text = dtQueryDetail.Rows[0]["QAttachmentTitle"].ToString();
            pnlQueryConversation.Controls.Add(hlAttachment_Query);
            // End - Original Query Detail

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnReply_Click(object sender, EventArgs e)
    {
        pnlAddConversation.Visible = true;

        lblIndication.Text = "Reply:";
        lblIndication.ForeColor = System.Drawing.Color.Blue;

        getConversation();
        ((Button)fvApplicationDetail.FindControl("btnReply")).Visible = false;

        btnSave_Reply.Visible = true;
    }
}