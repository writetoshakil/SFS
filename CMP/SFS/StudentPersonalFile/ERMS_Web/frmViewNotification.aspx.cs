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
        SqlConnection con = DAL.getConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select notificationtype, programtype, batch, program, remarks, filename from vw_AssignedNotification order by notificationtype, programtype, batch, program";
        DataTable dt = new DataTable();
        try
        {
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvNotification.DataSource = dt;
                gvNotification.DataBind();
                foreach (GridViewRow row in gvNotification.Rows)
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
        SqlConnection con = DAL.getConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select notificationtype, programtype, batch, program, remarks, filename from vw_AssignedNotification where "+ key + " like '%" + value + "%'" + " order by notificationtype, programtype, batch, program";
        DataTable dt = new DataTable();
        try
        {
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblError.Visible = false;
                gvNotification.DataSource = dt;
                gvNotification.DataBind();
                foreach (GridViewRow row in gvNotification.Rows)
                {
                    Label lbl = (Label)row.FindControl("lblSr");
                    lbl.Text = Convert.ToString(row.RowIndex + 1);
                    HyperLink hl = (HyperLink)row.FindControl("hlFilePath");
                    //hl.NavigateUrl = @"\\172.16.17.6\StudentPersonalFile\Notification\" + hl.Text;
                }
            }
            else
            {
                gvNotification.DataSource = null;
                gvNotification.DataBind();
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
            Response.Redirect("frmDisplayNotification.aspx?fileName=" + gvNotification.Rows[rowIndex].Cells[6].Text);
        }
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        BindGrid(ddlFilter.SelectedValue, txtFilter.Text);
    }
}
