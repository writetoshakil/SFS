using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SFS_app_DuplicateCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.rbDuplicateCard.Attributes.Add("onclick", "javascript:toggleBoxTab('rhboxtab_', '1', '#000000', '#BDD4FD'); showBoxDiv('rhbox_', 'rhbox_DuplicateCard')");
        this.rbChangedDiscipline.Attributes.Add("onclick", "javascript:toggleBoxTab('rhboxtab_', '2', '#000000', '#BDD4FD'); showBoxDiv('rhbox_', 'rhbox_ChangedDiscipline')");
        
    }
    protected void btnChangedDiscipline_Click(object sender, EventArgs e)
    {
        try
        {
            string ProgramFrom = ddlProgramFrom.SelectedValue;
            string ProgramTo = ddlProgramTo.SelectedValue;

            applications obj_app = new applications();
            int rowsAdded = obj_app.app_DuplicateCard_add(2, Session["id"].ToString(), "", "", "", "", 1, null, null, 1, ProgramFrom, ProgramTo);

            if (rowsAdded > 0)
                Server.Transfer("app_index.aspx");
            else
                lblMessage.Text = "Application couldn't be submitted.";
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }

    protected void btnDuplicateCard_Click(object sender, EventArgs e)
    {
        try
        {
            string challanNo = txtChallanNo.Text;
            string challanSubmissionDate = cpuChallanSubmissionDate.SelectedDate.Year + "-" + cpuChallanSubmissionDate.SelectedDate.Month + "-" + cpuChallanSubmissionDate.SelectedDate.Day;

            applications obj_app = new applications();
            int rowsAdded = obj_app.app_DuplicateCard_add(2, Session["id"].ToString(), "", "", "", "", 1, challanNo, challanSubmissionDate, 0, null, null);

            if (rowsAdded > 0)
                Server.Transfer("tasks.aspx");
            else
                lblMessage.Text = "Application couldn't be submitted.";
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }
}