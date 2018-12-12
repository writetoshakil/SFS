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

public partial class query_new : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            if (!Page.IsPostBack)
            {
                MyQuery objQuery = new MyQuery();
                DataTable dtCategories = objQuery.getCategories_Query();
                ddlCategories.DataSource = dtCategories;
                ddlCategories.DataTextField = "CTitle";
                ddlCategories.DataValueField = "CategoryId";
                ddlCategories.DataBind();

                ListItem item = new ListItem("-- Select Category --", "0");
                ddlCategories.Items.Insert(0, item);

                int categoryId = Convert.ToInt32(Request.QueryString["CId"]);
                if (categoryId == 1)
                    ddlCategories.SelectedValue = "1";
                else if (categoryId == 2)
                    ddlCategories.SelectedValue = "2";
                else if (categoryId == 3)
                    ddlCategories.SelectedValue = "3";
            }
        }
        else
            Server.Transfer("../CMP/index.aspx");
    }
    protected void btnAddQuery_Click(object sender, EventArgs e)
    {
        try
        {
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

                    // Update in DB
                    student objStudent = new student(Session["id"].ToString());
                    int rowsAdded = objStudent.addQuery(Convert.ToInt32(ddlCategories.SelectedValue), txtSubject.Text, txtDescription.Text, attachmentPath, fileName);

                    if (rowsAdded > 0)
                    {
                        lblMessage.Text = "Your query has been sent. It will be replied soon through this system. Please access the system for further conversation.";
                        Response.Redirect("tasks.aspx");
                    }
                    else
                        lblMessage.Text = "Your query couldn't be saved.";
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
    }
}
