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
using System.Data.SqlClient;
using ReflectionIT.Common.Data.SqlClient;

/// <summary>
/// Summary description for users
/// </summary>
public class sec_users_CMP
{
    private string userId;
    public string UserId
    {
        get { return userId; }
        set { userId = value; }
    }

    private List<string> roles;
    public List<string> Roles
    {
        get { return roles; }
        set { roles = value; }
    }

    private Boolean isApproved;
    public Boolean IsApproved
    {
        get { return isApproved; }
        set { isApproved = value; }
    }

    private Boolean isLockedOut;
    public Boolean IsLockedOut
    {
        get { return isLockedOut; }
        set { isLockedOut = value; }
    }

    private int questionId;
    public int QuestionId
    {
        get { return questionId; }
        set { questionId = value; }
    }

    private string secAnswer;
    public string SecAnswer
    {
        get { return secAnswer; }
        set { secAnswer = value; }
    }

    public sec_users_CMP()
    {
        //assigning directly to private fields
        this.userId = String.Empty;
        this.roles = null;
    }

    public sec_users_CMP(string id, string pass)
    {
        try
        {
            //assigning directly to private field 
            //Not used in this procedure
            this.userId = id;
            this.Roles = new List<string>();

            DataTable dt = GetUserRoles(id);

            if (dt.Rows.Count > 0)
            {
                isApproved = Convert.ToBoolean(dt.Rows[0]["isApproved"].ToString());
                isLockedOut = Convert.ToBoolean(dt.Rows[0]["isLockedOut"].ToString());
                questionId = Convert.ToInt32(dt.Rows[0]["questionId"].ToString());
                secAnswer = dt.Rows[0]["answer"].ToString();

                foreach (DataRow row in dt.Rows)
                    this.roles.Add(row["Role"].ToString());
            }
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetUserRoles(string id)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getUserRoles_new", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("userId", SqlDbType.VarChar, 50, ParameterDirection.Input, id);

                DataTable tblUserRoles = sp.ExecuteDataTable();
                return tblUserRoles;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
 
    public int changePassword(string userId, string oldPassword, string newPassword)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_changePass", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("userId", SqlDbType.VarChar, 50, ParameterDirection.Input, userId);
                sp.AddParameterWithValue("oldPassword", SqlDbType.VarChar, 50, ParameterDirection.Input, oldPassword);
                sp.AddParameterWithValue("newPassword", SqlDbType.VarChar, 50, ParameterDirection.Input, newPassword);

                int flag = sp.ExecuteNonQuery();
                return flag;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int resetPass_Forgot(string userId, string questionId, string answer, string tempCode)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_resetPass_Forgot", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("userId", SqlDbType.VarChar, 50, ParameterDirection.Input, userId);
                sp.AddParameterWithValue("QuestionId", SqlDbType.TinyInt, 1, ParameterDirection.Input, questionId);
                sp.AddParameterWithValue("Answer", SqlDbType.VarChar, 256, ParameterDirection.Input, answer);
                sp.AddParameterWithValue("tempCode", SqlDbType.VarChar, 256, ParameterDirection.Input, tempCode);

                int flag = sp.ExecuteNonQuery();
                return flag;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int changeSecuritySettings(string userId, string questionId, string answer)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_changeSecuritySettings", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("userId", SqlDbType.VarChar, 50, ParameterDirection.Input, userId);
                sp.AddParameterWithValue("questionId", SqlDbType.TinyInt, 1, ParameterDirection.Input, questionId);
                sp.AddParameterWithValue("answer", SqlDbType.VarChar, 255, ParameterDirection.Input, answer);

                int flag = sp.ExecuteNonQuery();
                return flag;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetStudentData(string id)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getStudentData", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("Reg_No", SqlDbType.VarChar, 50, ParameterDirection.Input, id);

                DataTable tblUserRoles = sp.ExecuteDataTable();
                return tblUserRoles;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
