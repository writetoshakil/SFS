using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class SFMS_FeeConfirmation : System.Web.UI.Page
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
                    getChallans();

                    List<string> Roles = (List<string>)Session["Roles"];
                    if (Roles.Contains("Facilitator_Acc"))
                    {
                        gvChallans.Columns[0].Visible = true;
                        gvChallans.Columns[6].Visible = false;

                        pnlFilter.Visible = true;
                    }
                    if (Roles.Contains("Student"))
                    {
                        gvChallans.Columns[6].Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }

    private void getChallans()
    {
        SFMS objSFMS = new SFMS();
        List<string> Roles = (List<string>)Session["Roles"];
        DataTable dtChallans = null;

        if (Roles.Contains("Student"))
            dtChallans = objSFMS.getChallans(Session["id"].ToString(), "");
        else if (Roles.Contains("Facilitator_Acc"))
            dtChallans = objSFMS.getChallans("-1", "-1");

        gvChallans.DataSource = dtChallans;
        gvChallans.DataBind();
    }

    private void getChallans_Date()
    {
        SFMS objSFMS = new SFMS();
        List<string> Roles = (List<string>)Session["Roles"];
        DataTable dtChallans = null;

        if (Roles.Contains("Student"))
            dtChallans = objSFMS.getChallans(Session["id"].ToString(), "");
        else if (Roles.Contains("Facilitator_Acc"))
        {
            String UpdatedOn = cpuUpdatedOn.SelectedDate.Year + "-" + cpuUpdatedOn.SelectedDate.Month + "-" + cpuUpdatedOn.SelectedDate.Day;
            dtChallans = objSFMS.getChallans("-1", UpdatedOn);
        }
        gvChallans.DataSource = dtChallans;
        gvChallans.DataBind();
    }

   
    protected void gvChallans_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvChallans.EditIndex = e.NewEditIndex;
        getChallans();
    }
    protected void gvChallans_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        String ChallanNo = ((Label)gvChallans.Rows[e.RowIndex].FindControl("lblChallanNo")).Text;
        String Bank_Branch = ((TextBox)gvChallans.Rows[e.RowIndex].FindControl("txtBank_Branch")).Text;
        eWorld.UI.CalendarPopup cpuDeposit_Date = ((eWorld.UI.CalendarPopup)gvChallans.Rows[e.RowIndex].FindControl("cpuDeposit_Date"));
        String Deposit_Date = cpuDeposit_Date.SelectedDate.Year + "-" + cpuDeposit_Date.SelectedDate.Month + "-" + cpuDeposit_Date.SelectedDate.Day;
       
        SFMS objSFMS = new SFMS();
        int RowsAdded = objSFMS.updateChallan(ChallanNo, Bank_Branch, Deposit_Date);
        
        if (RowsAdded > 0)
        {
            lblMessage.Text = "Detail has been updated.";
            gvChallans.EditIndex = -1;
            getChallans();
        }
        else
            lblMessage.Text = "Detail could not be updated.";

    }
    protected void gvChallans_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvChallans.EditIndex = -1;
        getChallans();
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        try
        {
            getChallans_Date();
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }
}