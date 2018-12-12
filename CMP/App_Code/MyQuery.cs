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

public class MyQuery
{
	public MyQuery()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable getCategories_Query()
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getCategory_Query", ConfigManager.GetNewSqlConnection_SFS))
            {
                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable getStatus_Query()
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getStatus_Query", ConfigManager.GetNewSqlConnection_SFS))
            {
                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable getTask_Type()
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getTask_Type", ConfigManager.GetNewSqlConnection_SFS))
            {
                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable getDepartments()
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getDepartments", ConfigManager.GetNewSqlConnection_SFS))
            {
                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getSummary(int CategoryId, string QFrom)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getSummary", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("CategoryId", SqlDbType.Int, 4, ParameterDirection.Input, CategoryId);
                sp.AddParameterWithValue("QFrom", SqlDbType.VarChar, 50, ParameterDirection.Input, QFrom);
                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //public DataTable getSummary_Student(string studentId)
    //{
    //    try
    //    {
    //        using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getSummary_Student", ConfigManager.GetNewSqlConnection_SFS))
    //        {
    //            sp.AddParameterWithValue("QFrom", SqlDbType.VarChar, 50, ParameterDirection.Input, studentId);

    //            return sp.ExecuteDataTable();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //public DataTable getSummary_Category(string CategoryId)
    //{
    //    try
    //    {
    //        using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getSummary_Category", ConfigManager.GetNewSqlConnection_SFS))
    //        {
    //            sp.AddParameterWithValue("CategoryId", SqlDbType.Int, 4, ParameterDirection.Input, CategoryId);

    //            return sp.ExecuteDataTable();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //public DataTable getSummary_Admin()
    //{
    //    try
    //    {
    //        using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getSummary_Admin", ConfigManager.GetNewSqlConnection_SFS))
    //        {
    //            return sp.ExecuteDataTable();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    public DataTable getQueries_Tasks(int QCategoryId, int TStatusId, string Dept, string CreatedBy_Id, string IConversation_RecipientId, string refNo, string Subject, string From, string To)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getQueries_Tasks1", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("QCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, QCategoryId);
                sp.AddParameterWithValue("TStatusId", SqlDbType.Int, 4, ParameterDirection.Input, TStatusId);
                sp.AddParameterWithValue("Dept", SqlDbType.VarChar, 500, ParameterDirection.Input, Dept);
                sp.AddParameterWithValue("CreatedBy_Id", SqlDbType.VarChar, 50, ParameterDirection.Input, CreatedBy_Id);
                sp.AddParameterWithValue("IConversation_RecipientId", SqlDbType.VarChar, 50, ParameterDirection.Input, IConversation_RecipientId);

                sp.AddParameterWithValue("refNo", SqlDbType.Int, 4, ParameterDirection.Input, refNo == String.Empty ? -1 : Convert.ToInt32(refNo));
                sp.AddParameterWithValue("Subject", SqlDbType.VarChar, 500, ParameterDirection.Input, Subject);
                sp.AddParameterWithValue("From", SqlDbType.VarChar, 500, ParameterDirection.Input, From);
                sp.AddParameterWithValue("To", SqlDbType.VarChar, 500, ParameterDirection.Input, To);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getQueries(int QCategoryId, int QStatusId, string QFrom, string IConversation_RecipientId)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getQueries", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("QCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, QCategoryId);
                sp.AddParameterWithValue("QStatusId", SqlDbType.Int, 4, ParameterDirection.Input, QStatusId);
                sp.AddParameterWithValue("QFrom", SqlDbType.VarChar, 50, ParameterDirection.Input, QFrom);
                sp.AddParameterWithValue("IConversation_RecipientId", SqlDbType.VarChar, 50, ParameterDirection.Input, IConversation_RecipientId);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable getQueryDetail(int T_Id)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getQueryDetail", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("T_Id", SqlDbType.Int, 4, ParameterDirection.Input, T_Id);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable getQueryConversation(int T_Id)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getConversation", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("T_Id", SqlDbType.Int, 4, ParameterDirection.Input, T_Id);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable getQueryConversation_All(int T_Id)
    {
        //All conversation Including internal forwarding / communication along with replies
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getIConversation", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("T_Id", SqlDbType.Int, 4, ParameterDirection.Input, T_Id);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getIConversation_Documents(string IConversationId)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.SPF_sp_getDocuments_IConversation", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("IConversationId", SqlDbType.VarChar, 50, ParameterDirection.Input, IConversationId);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getIConversation_Recipients(int T_Id)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getIConversation_Recipients", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("T_Id", SqlDbType.Int, 4, ParameterDirection.Input, T_Id);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getCategory_Roles(int CategoryId)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getCategory_Roles", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("CategoryId", SqlDbType.Int, 4, ParameterDirection.Input, CategoryId);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int addConversation(int T_Id, string CFrom, string CDescription, string CAttachmentPath, string CAttachmentTitle)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_addConversation", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("T_Id", SqlDbType.Int, 4, ParameterDirection.Input, T_Id);
                sp.AddParameterWithValue("CFrom", SqlDbType.VarChar, 50, ParameterDirection.Input, CFrom);
                sp.AddParameterWithValue("CDescription", SqlDbType.VarChar, 8000, ParameterDirection.Input, CDescription);
                sp.AddParameterWithValue("CAttachmentPath", SqlDbType.VarChar, 500, ParameterDirection.Input, CAttachmentPath);
                sp.AddParameterWithValue("CAttachmentTitle", SqlDbType.VarChar, 500, ParameterDirection.Input, CAttachmentTitle);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int addConversation_Document(int IConversationId, int DocumentId)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_addIConversation_Document", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("IConversationId", SqlDbType.Int, 4, ParameterDirection.Input, IConversationId);
                sp.AddParameterWithValue("DocumentId", SqlDbType.Int, 4, ParameterDirection.Input, DocumentId);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int addIConversation(int T_Id, string ICFrom, string ICDescription, string ICAttachmentPath, string ICAttachmentTitle)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_addIConversation", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("T_Id", SqlDbType.Int, 4, ParameterDirection.Input, T_Id);
                sp.AddParameterWithValue("ICFrom", SqlDbType.VarChar, 50, ParameterDirection.Input, ICFrom);
                sp.AddParameterWithValue("ICDescription", SqlDbType.VarChar, 8000, ParameterDirection.Input, ICDescription);
                sp.AddParameterWithValue("ICAttachmentPath", SqlDbType.VarChar, 500, ParameterDirection.Input, ICAttachmentPath);
                sp.AddParameterWithValue("ICAttachmentTitle", SqlDbType.VarChar, 500, ParameterDirection.Input, ICAttachmentTitle);

                int IConversation_Recipient_Added = Convert.ToInt32(sp.ExecuteScalar());

                return IConversation_Recipient_Added;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int addIConversation_Recipient(int IConversationId, string RecipientId)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_addIConversation_Recipient", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("IConversationId", SqlDbType.Int, 4, ParameterDirection.Input, IConversationId);
                sp.AddParameterWithValue("RecipientId", SqlDbType.VarChar, 50, ParameterDirection.Input, RecipientId);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int updateQStatus(int QId, int QStatusId, string UpdatedBy)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_UpdateQStatus", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("queryId", SqlDbType.Int, 4, ParameterDirection.Input, QId);
                sp.AddParameterWithValue("QStatusId", SqlDbType.Int, 4, ParameterDirection.Input, QStatusId);
                sp.AddParameterWithValue("UpdatedBy", SqlDbType.VarChar, 50, ParameterDirection.Input, UpdatedBy);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
