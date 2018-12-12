using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mpSFS : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
            
        
        if (Session["id"] == null)
            Server.Transfer("../CMP/index.aspx");

    }

}
