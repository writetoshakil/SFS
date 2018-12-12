using System;
using System.Collections.Generic;
using System.Web;


public class bcPreviligedPages : System.Web.UI.Page

{
    public bcPreviligedPages()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    protected void Page_PreInit(object sender, EventArgs e)
    {        
        if (Session["id"] == null)
            Server.Transfer("../CMP/index.aspx");
    }
   
}