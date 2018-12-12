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
using ReflectionIT.Common.Data.SqlClient;

public class MyAnnouncement
{
    public MyAnnouncement()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int addAnnouncement(string AFrom, int ACategoryId, string ASubject, string ADescription, DateTime VisibilityStartTime, DateTime VisibilityEndTime, int IsPublic, int ForSpecificStudents)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_addAnnouncement", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("AFrom", SqlDbType.VarChar, 50, ParameterDirection.Input, AFrom);
                sp.AddParameterWithValue("ACategoryId", SqlDbType.Int, 4, ParameterDirection.Input, ACategoryId);
                sp.AddParameterWithValue("ASubject", SqlDbType.VarChar, 500, ParameterDirection.Input, ASubject);
                sp.AddParameterWithValue("ADescription", SqlDbType.VarChar, 8000, ParameterDirection.Input, ADescription);
                sp.AddParameterWithValue("VisibilityStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, VisibilityStartTime);
                sp.AddParameterWithValue("VisibilityEndTime", SqlDbType.DateTime, 8, ParameterDirection.Input, VisibilityEndTime);
                sp.AddParameterWithValue("isPublic", SqlDbType.Int, 4, ParameterDirection.Input, IsPublic);
                sp.AddParameterWithValue("ForSpecificStudents", SqlDbType.Int, 4, ParameterDirection.Input, ForSpecificStudents);

                DataTable dtResult = sp.ExecuteDataTable();
                return Convert.ToInt32(dtResult.Rows[0]["announcementId"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int addAttachments(int AnnouncementId, string fileName, string attachmentPath)
    {
        using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_addAttachment", ConfigManager.GetNewSqlConnection_SFS))
        {
            sp.AddParameterWithValue("AnnouncementId", SqlDbType.Int, 4, ParameterDirection.Input, AnnouncementId);                
            sp.AddParameterWithValue("AttachmentTitle", SqlDbType.VarChar, 500, ParameterDirection.Input, fileName);
            sp.AddParameterWithValue("AttachmentPath", SqlDbType.VarChar, 500, ParameterDirection.Input, attachmentPath);

            return sp.ExecuteNonQuery();
        }    
    }

    public DataTable getAnnouncementDetail(int AId)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getAnnouncementDetail", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("announcementId", SqlDbType.Int, 4, ParameterDirection.Input, AId);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getAnnouncements(int isStudent, int CategoryId)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getAnnouncements", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("isStudent", SqlDbType.Int, 4, ParameterDirection.Input, isStudent);
                sp.AddParameterWithValue("CategoryId", SqlDbType.Int, 4, ParameterDirection.Input, CategoryId);
                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getAnnouncements_index(int AVId)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getAnnouncements_index", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("AVId", SqlDbType.Int, 4, ParameterDirection.Input, AVId);
                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getAnnouncement_Edit(int AId)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_getAnnouncement_Edit", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("announcementId", SqlDbType.Int, 4, ParameterDirection.Input, AId);
                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateAnnouncementDetail(int AnnouncementId, string ASubject, string ADescription, DateTime VisibilityStartTime, DateTime VisibilityEndTime, int IsPublic, int ForSpecificStudents, string lastEditedBy)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_EditAnnouncement", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("AnnouncementId", SqlDbType.Int, 4, ParameterDirection.Input, AnnouncementId);
                sp.AddParameterWithValue("ASubject", SqlDbType.VarChar, 500, ParameterDirection.Input, ASubject);
                sp.AddParameterWithValue("ADescription", SqlDbType.VarChar, 8000, ParameterDirection.Input, ADescription);
                sp.AddParameterWithValue("VisibilityStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, VisibilityStartTime);
                sp.AddParameterWithValue("VisibilityEndTime", SqlDbType.DateTime, 8, ParameterDirection.Input, VisibilityEndTime);
                sp.AddParameterWithValue("isPublic", SqlDbType.Int, 4, ParameterDirection.Input, IsPublic);
                sp.AddParameterWithValue("ForSpecificStudents", SqlDbType.Int, 4, ParameterDirection.Input, ForSpecificStudents);
                sp.AddParameterWithValue("lastEditedBy", SqlDbType.VarChar, 50, ParameterDirection.Input, lastEditedBy);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
