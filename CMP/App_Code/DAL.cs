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
    public static string RootDirectoryPath = @"\\172.16.17.31\StudentPersonalFile\Notification\";
    public static string DocumentRootDirectory = @"\\172.16.17.31\EDMS";
    public static string SPF_Path = @"\\172.16.17.31\StudentPersonalFile\";
	
    public static SqlConnection getConnection()
    {
        return new SqlConnection(@"data source=172.16.17.6\sqlexpress2k8,49172; initial catalog=StudentPersonalFile; user id=sa; password=howcool");
    }

    public static SqlConnection getEDMSConnection()
    {
        return new SqlConnection(@"data source=172.16.17.31\FILESERVER; initial catalog=StudentPersonalFile; user id=sa; password=exp0nent1");
    }
}
