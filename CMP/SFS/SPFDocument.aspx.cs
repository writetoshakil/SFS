using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SPFDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
             List<string> Roles = (List<string>)Session["Roles"];
             if (!Roles.Contains("Student"))
             {
                 string document = Request.QueryString["id"].ToString();
                 //Server.Transfer("StudentPersonalFile/" + document);
                 //Response.Redirect("StudentPersonalFile/" + document);


                 Response.Clear();
                 Response.ClearContent();
                 Response.ClearHeaders();

                 Response.ContentType = "Application/pdf";

                 //string FilePath = MapPath("StudentPersonalFile/" + document);
                 string FilePath = DAL.SPF_Path + document;
                 string fileName = document.Remove(0, 17);
                 Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

                 Response.WriteFile(FilePath);
                 Response.End();
             }
             else
             {
                 lblMessage.Text = "This is beyond your permission settings. Please contact webmaster@ciitlahore.edu.pk if it seems unfair to you.";

                 Server.Transfer("Access_Limited.aspx");
             }
        }
        catch (Exception ex)
        {
            lblException.Text = "Document couldn't be found";
        }
    }
}