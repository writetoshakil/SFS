using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Security.Cryptography; //For RNGCryptoServiceProvider
using System.Text; //For StringBuilder

public class Cryptology
{
	public Cryptology()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public string getHexaDecimalCharacters(int length_EvenNo)
    {
        //1 Byte = 2 Hexadecimal Characters (Each byte is represented by two hexadecimal characters)
        //Therefore, to request 64 Hexdecimal characters '32-byte key should be passed.

        int requiredHDChar = length_EvenNo / 2;
        byte[] buff = new byte[requiredHDChar];
        RNGCryptoServiceProvider rng = new
                                RNGCryptoServiceProvider();
        rng.GetBytes(buff);
        StringBuilder sb = new StringBuilder(requiredHDChar);
        for (int i = 0; i < buff.Length; i++)
            sb.Append(string.Format("{0:X2}", buff[i]));

        return Convert.ToString(sb);
    }
}
