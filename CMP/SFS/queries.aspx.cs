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

public partial class queries : System.Web.UI.Page
{
    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    List<string> roles = (List<string>)Session["Roles"];
    //    if (roles.Contains("Admin"))
    //        this.Page.MasterPageFile = "../MasterPages/MP_CMP.master";
       
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["id"] != null)
            {
                if (!Page.IsPostBack)
                {
                    Session["isReVerified"] = "false";

                    MyQuery objQuery = new MyQuery();
                    DataTable dtStatus = objQuery.getStatus_Query();
                    ddlQueryStatus.DataSource = dtStatus;
                    ddlQueryStatus.DataTextField = "QStatus";
                    ddlQueryStatus.DataValueField = "QStatusId";
                    ddlQueryStatus.DataBind();

                    ListItem li = new ListItem("All Queries", "-1");

                    ddlQueryStatus.Items.Insert(ddlQueryStatus.Items.Count, li);

                    List<string> Roles = (List<string>)Session["Roles"];

                    if (Roles.Contains("Admin"))
                    {
                        gvSummary.Columns[0].Visible = true;
                        getQueriesNSummary("Admin", 1, -1);
                    }
                    else if (Roles.Contains("Student"))
                    {
                        getQueriesNSummary("Student", -1, -1);
                        gvSummary.Columns[0].Visible = true;

                        ddlQueryStatus.SelectedIndex = ddlQueryStatus.Items.Count - 1;
                    }
                    else if (Roles.Contains("Facilitator_Reg"))
                        getQueriesNSummary("Facilitator_Reg", 1, 2);

                    else if (Roles.Contains("Facilitator_Acc"))
                        getQueriesNSummary("Facilitator_Acc", 1, 1);

                    else if (Roles.Contains("Facilitator_Exam"))
                        getQueriesNSummary("Facilitator_Exam", 1, 3);

                    else if (Roles.Contains("Administration"))
                        getQueriesNSummary("Facilitator_Exam", 1, 5);
                    else
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

    protected void ddlQueryStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<string> Roles = (List<string>)Session["Roles"];

            if (Roles.Contains("Student"))
                getQueriesNSummary("Student", Convert.ToInt32(ddlQueryStatus.SelectedValue), -1);

            if (Roles.Contains("Facilitator_Reg"))
                getQueriesNSummary("Facilitator_Reg", Convert.ToInt32(ddlQueryStatus.SelectedValue), 2);

            if (Roles.Contains("Facilitator_Acc"))
                getQueriesNSummary("Facilitator_Acc", Convert.ToInt32(ddlQueryStatus.SelectedValue), 1);

            if (Roles.Contains("Facilitator_Exam"))
                getQueriesNSummary("Facilitator_Exam", Convert.ToInt32(ddlQueryStatus.SelectedValue), 3);

            if (Roles.Contains("Admin"))
                getQueriesNSummary("Admin", Convert.ToInt32(ddlQueryStatus.SelectedValue), -1);

            if (ddlQueryStatus.SelectedItem.Text == "All Queries")
                gvQueries.Columns[2].Visible = true;
            else
                gvQueries.Columns[2].Visible = false;

            if (Roles.Contains("Student") || Roles.Contains("Admin"))
                gvQueries.Columns[3].Visible = true;
            else
                gvQueries.Columns[3].Visible = false;

            if (Request.QueryString["myQ"].ToString() == "1")
                gvQueries.Columns[3].Visible = true;
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }

    private void getQueriesNSummary(string Roles, int Status, int categoryId)
    {
        try
        {
            lblMessage_Summary.Text = "";
            lblMessage_Records.Text = "";

            DataTable dtSummary = new DataTable();
            DataTable dtQueries = new DataTable();

            MyQuery objQuery = new MyQuery();
            Boolean MyQueries = true;

            if (Request.QueryString["myQ"].ToString() == "1")
                MyQueries = true;
            else if (Request.QueryString["myQ"].ToString() == "0")
                MyQueries = false;

            if (MyQueries)
            {
                dtQueries = objQuery.getQueries(-1, Status, Session["id"].ToString(), "-1");
                dtSummary = objQuery.getSummary(-1, Session["id"].ToString());
            }
            else // -1, -1 too
            {
                dtQueries = objQuery.getQueries(categoryId, Status, "-1", Session["id"].ToString());
                dtSummary = objQuery.getSummary(categoryId, "-1");
            }

            gvSummary.DataSource = dtSummary;
            gvSummary.DataBind();

            if (dtSummary.Rows.Count == 0)
                lblMessage_Summary.Text = "No query / feedback / suggestion yet.";

            gvQueries.DataSource = dtQueries;
            gvQueries.DataBind();

            if (dtQueries.Rows.Count == 0)
                lblMessage_Records.Text = "No record found. Please check records count in summary above.";

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
