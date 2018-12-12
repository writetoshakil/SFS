﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_mpSFS_App : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
           
            List<string> Roles = (List<string>)Session["Roles"];

            if (Roles.Contains("Student"))
                pnlStudents.Visible = true;

        }
    }
}
