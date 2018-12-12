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

public class MyAttachment
{


    public MyAttachment()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Boolean isPermittedExtension(string uploadedExtension)
    {
        List<string> permittedExtension = new List<string>();
        permittedExtension.Add(".pdf");
        permittedExtension.Add(".doc");
        permittedExtension.Add(".docx");
        permittedExtension.Add(".xls");
        permittedExtension.Add(".xlsx");
        permittedExtension.Add(".txt");
        permittedExtension.Add(".jpg");
        permittedExtension.Add(".jpeg");
        permittedExtension.Add(".bmp");
        permittedExtension.Add(".png");

        return permittedExtension.Contains(uploadedExtension);
    }
}
