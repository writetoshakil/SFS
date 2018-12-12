using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SFS_app_bonafide : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        try
        {
            string AddressedTo = "To Whom It may Concern";
            int EnglishProficiency = 0;
            int CharacterCertificate = 0;
            int PassOut_ExpectedPassOut = 0;
            int CGPA = 0;

            if (rbAddressedTo.Items[1].Selected)
                AddressedTo = txtAddressedTo.Text;

            if (chkOptionalDetail.Items[0].Selected)
                EnglishProficiency = 1;
            if (chkOptionalDetail.Items[1].Selected)
                CharacterCertificate = 1;
            if (chkOptionalDetail.Items[2].Selected)
                PassOut_ExpectedPassOut = 1;
            if (chkOptionalDetail.Items[3].Selected)
                CGPA = 1;

            applications obj_app = new applications();
            int rowsAdded = obj_app.app_Bonafide_add(1, Session["id"].ToString(), "", "", "", "", 1, AddressedTo, EnglishProficiency, CharacterCertificate, PassOut_ExpectedPassOut, CGPA);

            if (rowsAdded > 0)
                //lblMessage.Text = "Application for Bonafide certificate has been submitted.";
                Server.Transfer("tasks.aspx");
        }
        catch (Exception ex)
        {
            lblException.Text = ex.Message;
        }
    }
}