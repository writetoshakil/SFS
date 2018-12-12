using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class SFS_Tasks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblException.Text = "";
            lblMessage.Text = "";
            lblMessage_Records.Text = "";

            if (Session["id"] != null)
            {
                if (!Page.IsPostBack)
                {
                    List<string> Roles = (List<string>)Session["Roles"];

                    MyQuery objQuery = new MyQuery();

                    // Fill Task Status Drop Down List
                    DataTable dtStatus = objQuery.getStatus_Query();
                    ddlTaskStatus.DataSource = dtStatus;
                    ddlTaskStatus.DataTextField = "QStatus";
                    ddlTaskStatus.DataValueField = "QStatusId";
                    ddlTaskStatus.DataBind();

                    ListItem liStatus = new ListItem("All", "-1");
                    ddlTaskStatus.Items.Insert(ddlTaskStatus.Items.Count, liStatus);

                    // Fill Task Type Drop Down List
                    DataTable dtT_Type = objQuery.getTask_Type();
                    ddlTaskType.DataSource = dtT_Type;
                    ddlTaskType.DataTextField = "TT_Title";
                    ddlTaskType.DataValueField = "TT_Id";
                    ddlTaskType.DataBind();

                    ListItem liT_Type = new ListItem("All", "-1");
                    ddlTaskType.Items.Insert(0, liT_Type);

                    // Fill Dept Drop Down List
                    DataTable dtDept = objQuery.getDepartments();
                    ddlDept.DataSource = dtDept;
                    ddlDept.DataTextField = "Dept";
                    ddlDept.DataValueField = "Dept";
                    ddlDept.DataBind();

                    ListItem liDept = new ListItem("All Departments", "-1");
                    ddlDept.Items.Insert(0, liDept);

                    
                    int categoryId = getCategory();

                    string From = cpuFrom.SelectedDate.ToShortDateString();
                    string To = cpuTo.SelectedDate.AddDays(1).ToShortDateString();

                    if (Roles.Contains("Student"))
                    {

                        ddlTaskStatus.SelectedIndex = ddlTaskStatus.Items.Count - 1;

                        getTasks(categoryId, -1, "All", "-1", "", "", Session["id"].ToString(), "2000-01-01", To);

                    }
                    else
                    {
                        pnlFilters.Visible = true;
                        
                        getTasks(categoryId, 1, "All", "-1", "", "", "-1", From, To);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }

    private int getCategory()
    {

        List<string> Roles = (List<string>)Session["Roles"];

        int categoryId = 0;
        if (Roles.Contains("Admin"))
        {
            categoryId = -1;
        }
        else if (Roles.Contains("Student"))
        {
            categoryId = -1;
        }
        else if (Roles.Contains("Facilitator_Reg"))
            categoryId = 2;

        else if (Roles.Contains("Facilitator_Acc"))
            categoryId = 1;

        else if (Roles.Contains("Facilitator_Exam"))
            categoryId = 3;

        else if (Roles.Contains("Administration"))
            categoryId = 5;

        else
        {
            foreach (string role in Roles)
            {
                if (role.Contains("C_S_"))
                    categoryId = 100;
            }
        }
        return categoryId;
    }

    private void getTasks(int categoryId, int status, string TaskType, string Dept, string refNo, string Subject, string CreatedBy, string From, string To)
    {
        DataTable dtQueries = new DataTable();
        DataTable dtApplications = new DataTable();

        MyQuery objQuery = new MyQuery();
        applications objApp = new applications();

        List<string> Roles = (List<string>)Session["Roles"];

        if(Roles.Contains("Student"))
        {
            dtQueries = objQuery.getQueries_Tasks(categoryId, status, Dept, CreatedBy, "-1", refNo, Subject, From, To);
            dtApplications = objApp.getApplications(status, Dept, CreatedBy, refNo, Subject, From, To);
        }
        else       
        {
            //Queries
            if (TaskType == "Query" || TaskType == "All")
                dtQueries = objQuery.getQueries_Tasks(categoryId, status, Dept, CreatedBy == String.Empty ? "-1" : CreatedBy, Session["id"].ToString(), refNo, Subject, From, To);
            // Applications
            if (TaskType == "Application" || TaskType == "All")
                if (categoryId == 2 || categoryId == -1 || categoryId == 100)
                {
                    dtApplications = objApp.getApplications(status, Dept, CreatedBy == String.Empty ? "-1" : CreatedBy, refNo, Subject, From, To);


                    // Following is not the optimized code and must be changed when time
                    // Applications Type - Clearance, Bonafide, Duplicate Card
                    // Access only to
                    // 1. Initialiazer
                    // 2. Authorized roles (View, Edit)

                    //for (int i = 0; i < dtApplications.Rows.Count; i++)
                    //{
                    //    DataRow row = dtApplications.Rows[i];
                    //    if (row["T_Title"].ToString() != "Clearance (Students)")
                    //    {
                    //        row.Delete();
                    //        dtApplications.AcceptChanges();
                    //    }
                    //}
                }
        }

        


        DataTable dtTasks = new DataTable();

        dtTasks = dtQueries;

        if (dtTasks.Columns.Count == 0)
        {
            
            dtTasks.Columns.Add("T_Id");
            dtTasks.Columns.Add("T_Ref");
            dtTasks.Columns.Add("TT_Title");
            dtTasks.Columns.Add("TStatus");
            dtTasks.Columns.Add("T_Title");
            dtTasks.Columns.Add("CreatedBy_Id");
            dtTasks.Columns.Add("createdOn");
            dtTasks.Columns.Add("CreatedOn1", System.Type.GetType("System.DateTime"));
            dtTasks.Columns.Add("TT_URL");
        }

        if (dtApplications.Rows.Count > 0)
        {
            foreach (DataRow row in dtApplications.Rows)
            {
                dtTasks.Rows.Add(row.ItemArray);
            }

           
        }

        dtTasks.DefaultView.Sort = "CreatedOn1 DESC";

        gvTasks.DataSource = dtTasks;
        gvTasks.DataBind();

    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        int status = Convert.ToInt32(ddlTaskStatus.SelectedValue);
        string TaskType = ddlTaskType.SelectedItem.Text;
        string Dept = ddlDept.SelectedValue;
        int categoryId = getCategory();

        string refNo = txtRefNo.Text.Trim();
        string Subject = txtSubject.Text.Trim();
        string CreatedBy = txtCreatedBy.Text.Trim();
        string From = cpuFrom.SelectedDate.ToShortDateString();
        string To = cpuTo.SelectedDate.AddDays(1).ToShortDateString();

        getTasks(categoryId, status, TaskType, Dept, refNo, Subject, CreatedBy, From, To);

    }
    protected void btnUnFilter_Click(object sender, EventArgs e)
    {
        txtRefNo.Text = "";
        ddlTaskStatus.SelectedIndex = ddlTaskStatus.Items.Count-1;
        ddlTaskType.SelectedIndex = -1;
        txtSubject.Text = "";

        ddlDept.SelectedIndex = -1;
        txtCreatedBy.Text = "";
        
        cpuFrom.SelectedDate = Convert.ToDateTime("2000-02-01");
        cpuTo.SelectedDate = DateTime.Now;

        gvTasks.DataSource = null;
        gvTasks.DataBind();
    }

    protected void btnDefault_Click(object sender, EventArgs e)
    {
        txtRefNo.Text = "";
        ddlTaskStatus.SelectedIndex = -1;
        ddlTaskType.SelectedIndex = -1;
        txtSubject.Text = "";

        ddlDept.SelectedIndex = -1;
        txtCreatedBy.Text = "";
        
        cpuFrom.SelectedDate = Convert.ToDateTime("2013-02-01");
        cpuTo.SelectedDate = DateTime.Now;

        gvTasks.DataSource = null;
        gvTasks.DataBind();
    }
    protected void gvTasks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTasks.PageIndex = e.NewPageIndex;
        btnFilter_Click(sender, e);
    }
}
