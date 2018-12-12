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

public partial class SFS_app_DuplicateCard_View : System.Web.UI.Page
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

        fvDocumentStatus.DataSource = dtApplicationDetail;
        fvDocumentStatus.DataBind();

        if (dtApplicationDetail.Rows[0]["isDisciplineChanged"].ToString() == "1")
        {
            fvDisciplineChanged.DataSource = dtApplicationDetail;
            fvDisciplineChanged.DataBind();
        }
        else
        {
            fvCardLost.DataSource = dtApplicationDetail;
            fvCardLost.DataBind();
        }

        List<string> Roles = (List<string>)Session["Roles"];
        if (!Roles.Contains("Student"))
        {
            if (dtApplicationDetail.Rows[0]["isDoc_Created"].ToString() == "0")
                ((HyperLink)fvDocumentStatus.FindControl("hlUpdateStatus_Creation")).Visible = true;
            else
                ((HyperLink)fvDocumentStatus.FindControl("hlUpdateStatus_Creation")).Visible = false;

            if (dtApplicationDetail.Rows[0]["isDoc_Issued"].ToString() == "0")
                ((HyperLink)fvDocumentStatus.FindControl("hlIssue_Document")).Visible = true;
            else
                ((HyperLink)fvDocumentStatus.FindControl("hlIssue_Document")).Visible = false;
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
}