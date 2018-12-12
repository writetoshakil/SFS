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

public partial class announcements : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["id"] != null)
            {
                lblException.Text = "";
                lblMessage.Text = "";

                MyAnnouncement objAnnouncement = new MyAnnouncement();

                List<string> Roles = (List<string>)Session["Roles"];

                DataTable dtAnnouncements = new DataTable();

                int catId = Convert.ToInt32(Session["catId"]);
                if (Roles.Contains("Student"))
                    dtAnnouncements = objAnnouncement.getAnnouncements(1, catId);
                else
                    dtAnnouncements = objAnnouncement.getAnnouncements(0, catId);

                if (dtAnnouncements.Rows.Count > 0)
                {
                    gvAnnouncements.DataSource = dtAnnouncements;
                    gvAnnouncements.DataBind();

                    if (Roles.Contains("Student"))
                    {
                        gvAnnouncements.Columns[2].Visible = false;
                        gvAnnouncements.Columns[3].Visible = false;
                        gvAnnouncements.Columns[4].Visible = false;
                        gvAnnouncements.Columns[5].Visible = false;

                        gvAnnouncements.Columns[1].ItemStyle.Width = 800;
                        gvAnnouncements.ShowHeader = false;
                        gvAnnouncements.HeaderRow.Visible = false;
                    }
                }
                else
                    lblMessage.Text = "No announcements currently.";
                
            }
            else
                Server.Transfer("../CMP/index.aspx");
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }
}
