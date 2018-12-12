using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

using ReflectionIT.Common.Data.SqlClient;

public class applications
{
	public applications()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int app_Bonafide_add(int AH_Id, string AppliedBy_RegNo, string AppliedBy_Name, string AppliedBy_HostName, string AppliedBy_IP, string AppliedBy_MAC, int AStatusId, string AddressedTo, int EnglishProficiency, int CharacterCertificate, int PassOut_ExpectedPassOut ,int CGPA)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_app_Add_Bonafide", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("AH_Id", SqlDbType.Int, 4, ParameterDirection.Input, AH_Id);
                sp.AddParameterWithValue("AppliedBy_RegNo", SqlDbType.VarChar, 30, ParameterDirection.Input, AppliedBy_RegNo);
                sp.AddParameterWithValue("AppliedBy_Name", SqlDbType.VarChar, 500, ParameterDirection.Input, AppliedBy_Name);
                sp.AddParameterWithValue("AppliedBy_HostName", SqlDbType.VarChar, 100, ParameterDirection.Input, AppliedBy_HostName);
                sp.AddParameterWithValue("AppliedBy_IP", SqlDbType.VarChar, 100, ParameterDirection.Input, AppliedBy_IP);
                sp.AddParameterWithValue("AppliedBy_MAC", SqlDbType.VarChar, 100, ParameterDirection.Input, AppliedBy_MAC);
                sp.AddParameterWithValue("AStatusId", SqlDbType.Int, 4, ParameterDirection.Input, AStatusId);
                sp.AddParameterWithValue("AddressedTo", SqlDbType.VarChar, 500, ParameterDirection.Input, AddressedTo);
                sp.AddParameterWithValue("EnglishProficiency", SqlDbType.Int, 4, ParameterDirection.Input, EnglishProficiency);
                sp.AddParameterWithValue("CharacterCertificate", SqlDbType.Int, 4, ParameterDirection.Input, CharacterCertificate);
                sp.AddParameterWithValue("PassOut_ExpectedPassOut", SqlDbType.Int, 4, ParameterDirection.Input, PassOut_ExpectedPassOut);
                sp.AddParameterWithValue("CGPA", SqlDbType.Int, 4, ParameterDirection.Input, CGPA);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public int app_DuplicateCard_add(int AH_Id, string AppliedBy_RegNo, string AppliedBy_Name, string AppliedBy_HostName, string AppliedBy_IP, string AppliedBy_MAC, int AStatusId, string ChallanNo, string ChallanSubmissionDate, int isDisciplineChanged, string ProgramFrom, string ProgramTo)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_app_Add_DuplicateCard", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("AH_Id", SqlDbType.Int, 4, ParameterDirection.Input, AH_Id);
                sp.AddParameterWithValue("AppliedBy_RegNo", SqlDbType.VarChar, 30, ParameterDirection.Input, AppliedBy_RegNo);
                sp.AddParameterWithValue("AppliedBy_Name", SqlDbType.VarChar, 500, ParameterDirection.Input, AppliedBy_Name);
                sp.AddParameterWithValue("AppliedBy_HostName", SqlDbType.VarChar, 100, ParameterDirection.Input, AppliedBy_HostName);
                sp.AddParameterWithValue("AppliedBy_IP", SqlDbType.VarChar, 100, ParameterDirection.Input, AppliedBy_IP);
                sp.AddParameterWithValue("AppliedBy_MAC", SqlDbType.VarChar, 100, ParameterDirection.Input, AppliedBy_MAC);
                sp.AddParameterWithValue("AStatusId", SqlDbType.Int, 4, ParameterDirection.Input, AStatusId);
                sp.AddParameterWithValue("ChallanNo", SqlDbType.VarChar, 64, ParameterDirection.Input, ChallanNo);
                sp.AddParameterWithValue("ChallanSubmissionDate", SqlDbType.VarChar, 64, ParameterDirection.Input, ChallanSubmissionDate);
                sp.AddParameterWithValue("isDisciplineChanged", SqlDbType.Int, 4, ParameterDirection.Input, isDisciplineChanged);
                sp.AddParameterWithValue("ProgramFrom", SqlDbType.VarChar, 64, ParameterDirection.Input, ProgramFrom);
                sp.AddParameterWithValue("ProgramTo", SqlDbType.VarChar, 64, ParameterDirection.Input, ProgramTo);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getStatus_Application()
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_app_getStatus_Application", ConfigManager.GetNewSqlConnection_SFS))
            {
                return sp.ExecuteDataTable();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable getApplications(int TStatusId, string Dept, string CreatedBy_Id, string refNo, string Subject, string From, string To)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_app_getApplications1", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("TStatusId", SqlDbType.Int, 4, ParameterDirection.Input, TStatusId);
                sp.AddParameterWithValue("Dept", SqlDbType.VarChar, 500, ParameterDirection.Input, Dept);
                sp.AddParameterWithValue("CreatedBy_Id", SqlDbType.VarChar, 50, ParameterDirection.Input, CreatedBy_Id);

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

    public DataTable getApplication_Detail(int T_Id)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_app_getApplicationDetail", ConfigManager.GetNewSqlConnection_SFS))
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

    public int updateStatus_Doc_Creation(int AId, string UpdatedBy)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_app_Document_Create", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("A_Id", SqlDbType.Int, 4, ParameterDirection.Input, AId);
                sp.AddParameterWithValue("Doc_Created_By", SqlDbType.VarChar, 50, ParameterDirection.Input, UpdatedBy);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int updateStatus_Doc_Issuance(int AId, string issuedBy)
    {
        try
        {
            using (SqlStoredProcedure sp = new SqlStoredProcedure("dbo.sp_app_Document_Issue", ConfigManager.GetNewSqlConnection_SFS))
            {
                sp.AddParameterWithValue("A_Id", SqlDbType.Int, 4, ParameterDirection.Input, AId);
                sp.AddParameterWithValue("Doc_Issued_By", SqlDbType.VarChar, 50, ParameterDirection.Input, issuedBy);

                return sp.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}