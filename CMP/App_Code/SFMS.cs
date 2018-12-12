using System;
using System.Collections.Generic;
using System.Web;

using System.Data;
using ReflectionIT.Common.Data.SqlClient;

public class SFMS
{
	public SFMS()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable getChallans(string StudentId, string UpdatedOn)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.SFMS_sp_getChallan", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("Student_Id", SqlDbType.VarChar, 64, ParameterDirection.Input, StudentId);
                sp.AddParameterWithValue("UpdatedOn", SqlDbType.VarChar, 64, ParameterDirection.Input, UpdatedOn);

                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int updateChallan(string ChallanNo, string Bank_Branch, string Deposit_Date)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.SFMS_sp_UpdateChallan", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("ChallanNo", SqlDbType.VarChar, 500, ParameterDirection.Input, ChallanNo);
                sp.AddParameterWithValue("Bank_Branch", SqlDbType.VarChar, 500, ParameterDirection.Input, Bank_Branch);
                sp.AddParameterWithValue("Deposit_Date", SqlDbType.VarChar, 500, ParameterDirection.Input, Deposit_Date);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}