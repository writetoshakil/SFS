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

public partial class frmDisplayNotification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string document = Request.QueryString["fileName"].ToString();
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "Application/pdf";
            string FilePath = DAL.DocumentRootDirectory + @"\" + Session["Department"].ToString() + @"\" + Session["BoxFileName"]+ @"\" + document; ;
            string fileName = document;//.Remove(0, 17);
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.WriteFile(FilePath);
            Response.End();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
