using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MyAnnouncement objAnnouncement = new MyAnnouncement();
        DataTable dtAnnouncements = new DataTable();
        dtAnnouncements = objAnnouncement.getAnnouncements_index(0);

        if (dtAnnouncements != null)
            if (dtAnnouncements.Rows.Count > 0)
            {
                foreach (DataRow row in dtAnnouncements.Rows)
                {
                    HyperLink hlAnnouncement = new HyperLink();
                    hlAnnouncement.Text = row["ASubject"].ToString() + "<br/>";
                    hlAnnouncement.NavigateUrl = "../SFS/announcement.aspx?AId=" + row["AnnouncementId"].ToString();
                    hlAnnouncement.CssClass = "index_Links_text";

                    Label lblSeperator = new Label();
                    lblSeperator.Text = "<br/>";

                    Image imgSeparator = new Image();
                    imgSeparator.ImageUrl = "Images/separator.jpg";
                    imgSeparator.CssClass = "separator_h";
                    imgSeparator.AlternateText = "Separator ";
                    imgSeparator.BorderStyle = BorderStyle.NotSet;
                    imgSeparator.BorderColor = System.Drawing.Color.White;

                    pnlAnnouncements.Controls.Add(hlAnnouncement);
                    pnlAnnouncements.Controls.Add(imgSeparator);
                    pnlAnnouncements.Controls.Add(lblSeperator);

                }
            }
    }
}