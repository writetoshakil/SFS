using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mpERMS : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["id"] != null)
        {
            if (Session["Roles"] != null)
            {
                List<string> roles = (List<string>)Session["Roles"];

                if(roles.Contains("Student"))
                    Server.Transfer("../ERMS/erms.aspx");
            }
        }
        else
            Server.Transfer("../ERMS/erms.aspx");

    }

}
