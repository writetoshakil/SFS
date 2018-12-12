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

public partial class query : System.Web.UI.Page
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
                    this.getUsers();

                    int queryId = Convert.ToInt32(Request.QueryString["TId"]);
                    MyQuery objQuery = new MyQuery();

                    DataTable dtQueryDetail = objQuery.getQueryDetail(queryId);

                    Boolean flag = false;

                    // Access for query Initializer
                    string queryOwner = dtQueryDetail.Rows[0]["CreatedBy_Id"].ToString();
                    if (queryOwner.ToUpper() == (Session["id"].ToString()).ToUpper())
                        flag = true;


                    // Access for employees having initial category assigned
                    int QCategoryId = Convert.ToInt32(dtQueryDetail.Rows[0]["CategoryId"].ToString());
                    DataTable dtAllowedRoles = objQuery.getCategory_Roles(QCategoryId);
                    List<string> Roles = (List<string>)Session["Roles"];
                    foreach (DataRow row in dtAllowedRoles.Rows)
                        if (Roles.Contains(row[0].ToString()))
                            flag = true;
                    
                    // Access for employees having queries forward out of original category
                    DataTable dtIConversation_Recipients = this.getIConversation_Recipients(queryId);
                    foreach(DataRow row in dtIConversation_Recipients.Rows)
                        if (row["userId"].ToString().ToUpper() == (Session["id"].ToString()).ToUpper())
                            flag = true;

                    if (flag)
                    {
                        setQueryDetail(dtQueryDetail);

                        getConversation();
                    }
                    else
                        lblMessage.Text = "This is beyond your permission settings. Please contact webmaster@ciitlahore.edu.pk if it seems unfair to you.";
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

    private void setQueryDetail(DataTable dtQueryDetail)
    {
        fvQueryDetail.DataSource = dtQueryDetail;
        fvQueryDetail.DataBind();

        List<string> Roles = (List<string>)Session["Roles"];

        if (!Roles.Contains("Student"))
        {
            ((Button)fvQueryDetail.FindControl("btnForward")).Visible = true;
            ((HyperLink)fvQueryDetail.FindControl("hlGetSPF")).Visible = true;
            ((DropDownList)fvQueryDetail.FindControl("ddlQStatus")).Enabled = true;
            ((Button)fvQueryDetail.FindControl("btnUpdateQStatus")).Visible = true;
        }
    }

    protected void btnReply_Click(object sender, EventArgs e)
    {
        try
        {
            pnlAddConversation.Visible = true;

            lblIndication.Text = "Reply:";
            lblIndication.ForeColor = System.Drawing.Color.Blue;

            getConversation();
            ((Button)fvQueryDetail.FindControl("btnReply")).Visible = false;
            ((Button)fvQueryDetail.FindControl("btnForward")).Visible = false;

            btnSave_Reply.Visible = true;
            btnSave_Forward.Visible = false;
            ddlUsers.Visible = false;

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnForward_Click(object sender, EventArgs e)
    {
        try
        {
            pnlAddConversation.Visible = true;

            lblIndication.Text = "Forward for response:";
            lblIndication.ForeColor = System.Drawing.Color.Maroon;

            getConversation();
            ((Button)fvQueryDetail.FindControl("btnReply")).Visible = false;
            ((Button)fvQueryDetail.FindControl("btnForward")).Visible = false;

            btnSave_Reply.Visible = false;
            btnSave_Forward.Visible = true;
            ddlUsers.Visible = true;            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnUpdateQStatus_Click(object sender, EventArgs e)
    {
        try
        {
            // Allow Update Status to be updated for users other than students
            // Status can only be set as completed if reply has been sent
            List<string> Roles = (List<string>)Session["Roles"];

            int queryId = Convert.ToInt32(Request.QueryString["TId"]);
            MyQuery objQuery = new MyQuery();

            // Get Replies Detail
            DataTable dtConversation = objQuery.getQueryConversation(queryId);
            // Get Original Query Detail
            DataTable dtQueryDetail = objQuery.getQueryDetail(queryId);
            
            Boolean flagupdate = false;
            if (dtConversation.Rows.Count > 0 && !Roles.Contains("Student"))
            {
               
                for (int i = 0; i < dtConversation.Rows.Count; i++)
                {
                    if (dtConversation.Rows[i]["CFrom"].ToString() != dtQueryDetail.Rows[0]["CreatedBy_Id"].ToString())
                    {                      
                        flagupdate = true;

                        if (flagupdate)
                            break;
                    }

                }                                
            }

            int QStatusId = Convert.ToInt32(((DropDownList)fvQueryDetail.FindControl("ddlQStatus")).SelectedValue);
            if (QStatusId == 3 && flagupdate == false) // 3 = Completed 
            {
                lblException.Text = "Status couldn't be set as completed because it has not been replied yet.";
                lblMessage.Text = "You can set the query staus 'On hold' if you want to forward the query to some one else.";

                //Set Status as original
                setQueryDetail(dtQueryDetail);
            }
            else
            {
                string UpdatedBy = Session["id"].ToString().ToUpper();
                int rowsAffected = objQuery.updateQStatus(queryId, QStatusId, UpdatedBy);

                if (rowsAffected > 0)
                    lblMessage.Text = "Status has been updated";
            }
               

            getConversation();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
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

                    ((Button)fvQueryDetail.FindControl("btnReply")).Visible = true;

                    List<string> Roles = (List<string>)Session["Roles"];
                    if (!Roles.Contains("Student"))
                        ((Button)fvQueryDetail.FindControl("btnForward")).Visible = true;
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
    protected void btnSave_Forward_Click(object sender, EventArgs e)
    {
        try
        {   
            int queryId = Convert.ToInt32(Request.QueryString["TId"]);
            string CFrom = Session["id"].ToString();
            string CDescription = txtDescription.Text;
            // Start - Attachment
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

                    // Add Conversation
                    MyQuery objQuery = new MyQuery();
                    int IConversationId_Inserted = objQuery.addIConversation(queryId, CFrom, CDescription, attachmentPath, fileName);

                    // Add Recepients
                    int IConversation_Recipient_Added = 0;
                    if (IConversationId_Inserted > 0) // IConversationId_Inserted is the seed increment id
                    {
                        IConversation_Recipient_Added = objQuery.addIConversation_Recipient(IConversationId_Inserted, ddlUsers.SelectedValue);
                    }

                    
                    if (IConversation_Recipient_Added > 0)
                    {                        
                        // Add SPF documents 
                        foreach (GridViewRow row in gvDocuments.Rows)
                        {
                            if (((CheckBox)row.FindControl("chkDocument")).Checked)
                            {
                                string temp = row.Cells[1].Text;
                                int documentId = Convert.ToInt32(((Label)row.FindControl("lblDocumentId")).Text);

                                int Conversation_Documents_Attached = objQuery.addConversation_Document(IConversationId_Inserted, documentId);
                            }
                        }

                        lblMessage.Text = "This has been forwarded.";
                    }
                    getConversation();
                    pnlAddConversation.Visible = false;

                    ((Button)fvQueryDetail.FindControl("btnReply")).Visible = true;

                    List<string> Roles = (List<string>)Session["Roles"];
                    if (!Roles.Contains("Student"))
                        ((Button)fvQueryDetail.FindControl("btnForward")).Visible = true;                    
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
            ddlUsers.SelectedIndex = 0;
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
            DataTable dtConversation = objQuery.getQueryConversation_All(queryId);
            //Get Internal Conversation Reciepients
            DataTable dtIConversation_Recipients = this.getIConversation_Recipients(queryId);

            foreach (DataRow row in dtConversation.Rows)
            {
                string conversationId = row["conversationId"].ToString();
                int conversationType = Convert.ToInt32(row["ConversationType"].ToString());
                Label lblConversationHeader = new Label();

                lblConversationHeader.Text = "<br/> <font color='blue'>On " + row["CreatedOn"].ToString() + ", " + row["CFrom"].ToString().ToUpper();
                if (row["SName"].ToString() != "")
                    lblConversationHeader.Text += " (" + row["SName"].ToString() +")";

                if (conversationType == 1)
                    lblConversationHeader.Text += " wrote:</font> <br/>";
                if (conversationType == 0)
                {
                    lblConversationHeader.Text += " forwarded to ";

                    foreach (DataRow row_IC in dtIConversation_Recipients.Rows)
                        if (row_IC["IconversationId"].ToString() == conversationId)
                            lblConversationHeader.Text += row_IC["userName"].ToString() + ": ";
                    
                    lblConversationHeader.Text += ":</font> <br/>";
                }
                
                pnlQueryConversation.Controls.Add(lblConversationHeader);

                // Check if student then whether to show or not
                if (row["IsVisibletoStudent"].ToString() == "1" || !((List<string>)Session["Roles"]).Contains("Student"))
                {
                    Label lblConversationDetail = new Label();
                    lblConversationDetail.Text = row["CDescription"].ToString() + "<br/>";
                    pnlQueryConversation.Controls.Add(lblConversationDetail);
                }

                // Show SPF Document(s) links
                if (conversationType == 0)
                {
                    DataTable dtDocuments = objQuery.getIConversation_Documents(conversationId.Remove(0,2));
                    
                    Panel pnlDocuments = new Panel();

                    if (dtDocuments.Rows.Count > 0)
                    {
                        Label lblHead = new Label();
                        lblHead.Text = "Attached SPF Documents: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ";
                        lblHead.Font.Size = FontUnit.Smaller;
                        pnlDocuments.Controls.Add(lblHead);

                        foreach (DataRow rowDocument in dtDocuments.Rows)
                        {
                            HyperLink hlDocument = new HyperLink();
                            hlDocument.Text = rowDocument["Description"].ToString();
                            hlDocument.NavigateUrl = "SPFDocument.aspx?id=" + rowDocument["Location"].ToString();
                            hlDocument.Target = "_Blank";

                            pnlDocuments.Controls.Add(hlDocument);

                            Label lblSeperator = new Label();
                            lblSeperator.Text = "&nbsp;&nbsp; | &nbsp;&nbsp;";
                            pnlDocuments.Controls.Add(lblSeperator);
                        }


                        Label lblNote = new Label();
                        lblNote.Text = "<br/>Note: Complete file of student can be accessed from the link at top right corner with reply button.";
                        lblNote.Font.Size = FontUnit.Smaller;
                        pnlDocuments.Controls.Add(lblNote);

                        pnlQueryConversation.Controls.Add(pnlDocuments);
                    }
                }

                // Show Attachment(s)
                HyperLink hlAttachment = new HyperLink();
                hlAttachment.Target = "_Blank";
                hlAttachment.NavigateUrl = row["CAttachmentPath"].ToString();
                hlAttachment.Text = row["CAttachmentTitle"].ToString();
                pnlQueryConversation.Controls.Add(hlAttachment);

                Label lblSeparator = new Label();
                if(hlAttachment.Text != "")
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

           


            //Setting Link of SPF
            if ( !Page.IsPostBack && CreatedBy_Id.Contains("CIIT"))
            {
                ((HyperLink)fvQueryDetail.FindControl("hlGetSPF")).NavigateUrl += "?id=" + CreatedBy_Id;
                getSPF(CreatedBy_Id);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    private void getSPF(string regNo)
    {
        try
        {
            SPF objSPF = new SPF();
            DataTable dtDocuments = objSPF.getDocumentDetail(regNo);

            if (dtDocuments.Rows.Count > 0)
            {
                gvDocuments.DataSource = dtDocuments;
                gvDocuments.DataBind();
            }
            else
            {
                dtDocuments.Rows.Add(dtDocuments.NewRow());

                gvDocuments.DataSource = dtDocuments;
                gvDocuments.DataBind();

                gvDocuments.Rows[0].Cells.Clear();
                gvDocuments.Rows[0].Cells.Add(new TableCell());
                gvDocuments.Rows[0].Cells[0].ColumnSpan = 3;
                gvDocuments.Rows[0].Cells[0].Text = "No Documents found.";
                gvDocuments.Rows[0].Cells[0].Width = 500;

            }
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }

    private void getUsers()
    {
        sec_users_SFS objUsers = new sec_users_SFS();
        DataTable dtUsers = objUsers.GetUsers();

        ddlUsers.DataSource = dtUsers;
        ddlUsers.DataTextField = "userName";
        ddlUsers.DataValueField = "userId";        

        ddlUsers.DataBind();

        ListItem liUsers = new ListItem("-- Select Recipient --", "0");
        ddlUsers.Items.Insert(0, liUsers);
    }

    private DataTable getIConversation_Recipients(int queryId)
    {
        MyQuery objQuery = new MyQuery();
        DataTable dtIConversation_Recipients = objQuery.getIConversation_Recipients(queryId);

        return dtIConversation_Recipients;
    }

}
