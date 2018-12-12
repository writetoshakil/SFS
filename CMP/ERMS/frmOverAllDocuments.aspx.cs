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
using System.Data.SqlClient;

public partial class frmViewNotification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            lblError.Visible = false;
            BindGrid();
        }
    }

    protected void BindGrid()
    {
        SqlConnection con = DAL.getEDMSConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select documentid, containingdepartment, boxfilename, documentdescription, filename from vw_BoxFileDocument where documentstatus = 1 AND containingdepartment not like '%administration%' order by containingdepartment";
        DataTable dt = new DataTable();
        try
        {
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvDocument.DataSource = dt;
                gvDocument.DataBind();
                foreach (GridViewRow row in gvDocument.Rows)
                {
                    Label lbl = (Label)row.FindControl("lblSr");
                    lbl.Text = Convert.ToString(row.RowIndex + 1);
                }
            }
        }
        catch (Exception)
        {
           
        }
    }

    protected void BindGrid(string key, string value)
    {
        SqlConnection con = DAL.getEDMSConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select documentid, containingdepartment, boxfilename, documentdescription, filename from vw_boxfiledocument where documentstatus = 1 and " + key + " like '%" + value + "%'" + " ";
        DataTable dt = new DataTable();
        try
        {
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblError.Visible = false;
                gvDocument.DataSource = dt;
                gvDocument.DataBind();
                foreach (GridViewRow row in gvDocument.Rows)
                {
                    Label lbl = (Label)row.FindControl("lblSr");
                    lbl.Text = Convert.ToString(row.RowIndex + 1);
                    //HyperLink hl = (HyperLink)row.FindControl("hlFilePath");
                    //hl.NavigateUrl = @"\\172.16.17.6\StudentPersonalFile\Notification\" + hl.Text;
                }
            }
            else
            {
                gvDocument.DataSource = null;
                gvDocument.DataBind();
                lblError.Visible = true;
            }
        }
        
        catch (Exception)
        {

        }
    }

    protected void gvNotification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = Convert.ToInt16(e.CommandArgument);
        if (e.CommandName == "View")
        {
            Session["Department"] = gvDocument.Rows[rowIndex].Cells[2].Text;
            Session["BoxFileName"] = gvDocument.Rows[rowIndex].Cells[3].Text;
            Response.Redirect("frmDisplayDocument.aspx?fileName=" + gvDocument.Rows[rowIndex].Cells[5].Text);
        }
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        if (!txtFilter.Text.ToUpper().Contains("ADMINISTRATION"))
        {
            BindGrid(ddlFilter.SelectedValue, txtFilter.Text);
        }
    }
}
