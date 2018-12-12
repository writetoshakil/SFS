using System.Data.SqlClient;

public class ConfigManager
{
    public static SqlConnection GetNewSqlConnection_CMP
    {
        get { return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conStrCMP"].ConnectionString); }
    }
    public static SqlConnection GetNewSqlConnection
    {
        get { return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conStrLocal"].ConnectionString); }
        //get { return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CIITWebsiteConnectionString"].ConnectionString); }
    }
    public static SqlConnection GetNewSqlConnection_SMS
    {
        get { return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conStrSMS"].ConnectionString); }
    }
    public static SqlConnection GetNewSqlConnection_SFS
    {
        get { return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conStrSFS"].ConnectionString); }
    }
    public static SqlConnection GetNewSqlConnection_Cmail
    {
        get { return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conStrCMail"].ConnectionString); }
    }
    public static SqlConnection GetNewSqlConnection_31
    {
        get { return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conStr31"].ConnectionString); }
    }
}
