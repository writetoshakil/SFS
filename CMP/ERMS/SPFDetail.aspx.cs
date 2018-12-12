using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ReflectionIT.Common.Data.SqlClient;


public partial class SPFDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblException.Text = "";
        lblMessage.Text = "";

        List<string> Roles = (List<string>)Session["Roles"];
        if (Roles != null)
        {
            //if (!Roles.Contains("Student") && !Roles.Contains("DCOs") && !Roles.Contains("Asst_DCOs"))
            if (Roles.Contains("Facilitator_Reg") || Roles.Contains("Admin"))
            {
                pnlDocuments.Visible = true;
                if (!IsPostBack)
                {
                    if (this.ClientQueryString.Contains("id"))
                    {
                        string studentId = Request.QueryString["id"];
                        studentId = studentId.ToUpper();
                        studentId = studentId.Replace("CIIT/", "");
                        studentId = studentId.Replace("/LHR", "");

                        txtRegistrationNo.Text = studentId;

                        btnGetData_Click(sender, e);
                    }
                }
            }
            else
            {
                pnlDocuments.Visible = false;
                lblMessage.Text = "This is beyond your permission settings. Please contact webmaster@ciitlahore.edu.pk if it seems unfair to you.";

                Server.Transfer("../SFS/Access_Limited.aspx");
            }
        }
        else
            Response.Redirect("../CMP/index.aspx");
    }
    protected void btnGetData_Click(object sender, EventArgs e)
    {
        try
        {
            SPF objSPF = new SPF();
            string regNo = lblRegistrationNo_Prefix.Text + txtRegistrationNo.Text + lblRegistrationNo_Postfix.Text;
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
                gvDocuments.Rows[0].Cells[0].ColumnSpan = gvDocuments.Rows[0].Cells.Count;
                gvDocuments.Rows[0].Cells[0].Text = "No Documents found.";
                gvDocuments.Rows[0].Cells[0].Width = 500;

            }
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }

    }
}