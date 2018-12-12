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

public class bulkEmailSender
{
    public bulkEmailSender(string _senderTitle, string _senderEmail, System.Net.NetworkCredential _senderCredential, int _quota_Used_Today)
    {        
        SenderTitle = _senderTitle;
        SenderEmail = _senderEmail;
        SenderCredential = _senderCredential;
        quota_Used_Today = _quota_Used_Today;
        RecipientsLimitPerDay = 2000;
        RecipientsLimitPerMail = 500;
    }

    private string senderTitle;
    public string SenderTitle
    {
        get { return senderTitle; }
        set { senderTitle = value; }
    }

    private string senderEmail;
    public string SenderEmail
    {
        get { return senderEmail; }
        set { senderEmail = value; }
    }

    private System.Net.NetworkCredential senderCredential;
    public System.Net.NetworkCredential SenderCredential
    {
        get { return senderCredential; }
        set { senderCredential = value; }
    }
    
    private int quota_Used_Today;
    public int Quota_Used_Today
    {
        get { return quota_Used_Today; }
        set { quota_Used_Today = value; }
    }

    private int recipientsLimitPerDay;
    public int RecipientsLimitPerDay
    {
        get { return recipientsLimitPerDay; }
        set { recipientsLimitPerDay = value; }
    }

    private int recipientsLimitPerMail;
    public int RecipientsLimitPerMail
    {
        get { return recipientsLimitPerMail; }
        set { recipientsLimitPerMail = value; }
    }    
	
    // Gmail Limits http://www.google.com/support/a/bin/answer.py?hl=en&answer=166852
    // For Gmail Limit is 500 external recipients per day. 
    // For Premium / Educational users limit is 2000 external recipients per day    
    // An individual message can be sent to a maximum of 500 external recipients at one time (In all editions of Google Apps)
    // Limits is not separate for To, CC and BCC. Total of these 3 must less than limit

    public Boolean sendEmail(String ReplyTo, String MsgTo, String CC, String BCC, String MsgSubject, String MsgBody, String attachmentPath)
    {
        try
        {
            System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage(this.SenderEmail, MsgTo, MsgSubject, MsgBody);

            if(attachmentPath !="")
                MyMailMessage.Attachments.Add(new System.Net.Mail.Attachment(attachmentPath));

            MyMailMessage.IsBodyHtml = false;

            if (CC != "")
                MyMailMessage.CC.Add(CC);
            if (BCC != "")
                MyMailMessage.Bcc.Add(BCC);

            MyMailMessage.Headers.Add("Precedence", "bulk");
            MyMailMessage.Headers.Add("List-Unsubscribe", "webmaster@ciitlahore.edu.pk");

            //Setting Reply-To Address
            System.Net.Mail.MailAddress objAddress = new System.Net.Mail.MailAddress(ReplyTo);
            MyMailMessage.ReplyTo = objAddress;

            //Smtp Mail server of Gmail is "smpt.gmail.com" and it uses port no. 587 
            //For different server like yahoo this details changes and you can get it from respective server. 
            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

            //Enable SSL 
            mailClient.EnableSsl = true;
            mailClient.UseDefaultCredentials = false;
            mailClient.Credentials = this.SenderCredential;
            mailClient.Send(MyMailMessage);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

}

public class myEmail
{
    private List<bulkEmailSender> bulkEmailSenders;
    public List<bulkEmailSender> BulkEmailSenders
    {
        get { return bulkEmailSenders; }
        set { bulkEmailSenders = value; }
    }

	public myEmail()
	{

        this.BulkEmailSenders = new List<bulkEmailSender>();

        DataTable dtBulkEmailSenders = getBulkEmailSendersDetail();
        foreach (DataRow row in dtBulkEmailSenders.Rows)
        {
            string senderTitle = row["senderTitle"].ToString();
            string senderEmail = row["senderEmail"].ToString();
            string senderPass = "";
            int quota_Used_Today = Convert.ToInt32(row["quota_Used_Today"].ToString());

            bulkEmailSender objBulkEmailSender = new bulkEmailSender(senderTitle + "<" + senderEmail + ">", senderEmail, new System.Net.NetworkCredential(senderEmail, senderPass), quota_Used_Today);

            BulkEmailSenders.Add(objBulkEmailSender);
        } 

        
	}

    public Boolean sendEmail(String MsgTo, String CC, String BCC, String MsgSubject, String MsgBody, String attachmentPath)
    {
        try
        {
            // Check sender limits before 
            bulkEmailSender objBulkEmailSender = this.BulkEmailSenders[0];

            return objBulkEmailSender.sendEmail("webmaster@ciitlahore.edu.pk", MsgTo, CC, BCC, MsgSubject, MsgBody, attachmentPath);

        }
        catch (Exception ex)
        {
            return false;
        }
    }

    private DataTable getBulkEmailSendersDetail()
    {
        DataTable dt = new DataTable();
        return dt;
    }
}
