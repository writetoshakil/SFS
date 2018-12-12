using System;
using System.Collections.Generic;
using System.Web;

using System.Data;
using ReflectionIT.Common.Data.SqlClient;

public class SPF
{
	public SPF()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable getDocumentDetail(string StudentId)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.SPF_sp_getDocuments", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("StudentId", SqlDbType.VarChar, 50, ParameterDirection.Input, StudentId);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}