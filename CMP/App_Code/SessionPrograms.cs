using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;

public class SessionPrograms
{
    public SessionPrograms()
    {
        lstPrograms = new List<string>();
    }

    private string session;
    public string Session
    {
        get { return session; }
        set { session = value; }
    }

    private List<string> lstPrograms;
    public List<string> LstPrograms
    {
        get { return lstPrograms; }
        set { lstPrograms = value; }
    }

    private static List<string> lstAllPrograms;
    public static List<string> LstAllPrograms
    {
        get { return lstAllPrograms; }
        set { lstAllPrograms = value; }
    }
}
