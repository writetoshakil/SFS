using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DAL
/// </summary>
public static class DAL
{
    public static SqlConnection getConnection()
    {
        return new SqlConnection("data source=172.16.17.6; initial catalog=StudentPersonalFile; user id=sa; password=howcool");
    }
}
