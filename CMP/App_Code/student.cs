using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using ReflectionIT.Common.Data.SqlClient;

public class student
{
    private string reg_No;
    public string Reg_No
    {
        get { return reg_No; }
        set { reg_No = value; }
    }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string dept;
    public string Dept
    {
        get { return dept; }
        set { dept = value; }
    }

    private string gender;
    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    private string email1;
    public string Email1
    {
        get { return email1; }
        set { email1 = value; }
    }

    private string email2;
    public string Email2
    {
        get { return email2; }
        set { email2 = value; }
    }

    private string email_Parent;
    public string Email_Parent
    {
        get { return email_Parent; }
        set { email_Parent = value; }
    }

    private string cellNo1;
    public string CellNo1
    {
        get { return cellNo1; }
        set { cellNo1 = value; }
    }

    private string cellNo2;
    public string CellNo2
    {
        get { return cellNo2; }
        set { cellNo2 = value; }
    }

    private string cellNo_Parent;
    public string CellNo_Parent
    {
        get { return cellNo_Parent; }
        set { cellNo_Parent = value; }
    }

    private string landLineNo;
    public string LandLineNo
    {
        get { return landLineNo; }
        set { landLineNo = value; }
    }

    public student() { }

	public student(string _reg_No)
	{
        reg_No = _reg_No;
	}

    public int addQuery(int QCategoryId, string QSubject, string QDescription, string QAttachmentPath, string QAttachmentTitle)
    {             
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_addQuery", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("QFrom", SqlDbType.VarChar, 50, ParameterDirection.Input, this.reg_No);
                sp.AddParameterWithValue("QCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, QCategoryId);
                sp.AddParameterWithValue("QSubject", SqlDbType.VarChar, 500, ParameterDirection.Input, QSubject);
                sp.AddParameterWithValue("QDescription", SqlDbType.VarChar, 8000, ParameterDirection.Input, QDescription);
                sp.AddParameterWithValue("QAttachmentPath", SqlDbType.VarChar, 500, ParameterDirection.Input, QAttachmentPath);
                sp.AddParameterWithValue("QAttachmentTitle", SqlDbType.VarChar, 500, ParameterDirection.Input, QAttachmentTitle);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static DataTable sp_getBatches_Registered()
    {
        try
        {
            SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getBatches_Registered", ConfigManager.GetNewSqlConnection_SFS);

            DataTable dt = sp.ExecuteDataTable();

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void getRegistered_Current()
    {
        try
        {
            SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getRegistered_Current", ConfigManager.GetNewSqlConnection);

            DataTable dtStudents = sp.ExecuteDataTable();

            student objStudent = new student();
            foreach (DataRow row in dtStudents.Rows)
            {
                objStudent.reg_No = row["Reg_No"].ToString();
                objStudent.name = row["Name"].ToString();
                objStudent.gender = row["Gender"].ToString();
                objStudent.email1 = row["Email1"].ToString();
                objStudent.email2 = row["Email2"].ToString();
                objStudent.email_Parent = row["Email_Parent"].ToString();
                objStudent.cellNo1 = row["CellNo1"].ToString();
                objStudent.cellNo2 = row["CellNo2"].ToString();
                objStudent.cellNo_Parent = row["CellNo_Parent"].ToString();
                objStudent.landLineNo = row["LandLineNo"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
