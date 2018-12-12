<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpSFS_App.master" AutoEventWireup="true" CodeFile="app_bonafide.aspx.cs" Inherits="SFS_app_bonafide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder21" Runat="Server">

    <div class="pageHeading">Bonafide Certificate</div>
    Bonafide certificate is the verification that the applicant is (has been) a student of this university with a specific registration 
    number. It is mentioned in the certificate that it is issued on the request of the applicant. In this certificate, the Course duration of the program is mentioned and 
    if the student is currently enrolled then the semester under study is also mentioned. There are certain other detail which are
    mentioned on applicant's demand i.e. English Proficiency, Character certificate, Pass out / expected pass out status, C.G.P.A etc. 
    (<a href="Forms_Sample/sampleDocument.pdf" target="_blank">View Sample Document</a>)

    <div class="pageSubHeading" style="padding-top:20px; padding-bottom:20px;">Applying for Bonafide Certificate</div>
        
    <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
    
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3">Bonafide certificate must be addressed to:</td>            
        </tr>
        <tr>
            <td width="50px" rowspan="2"></td>
            <td rowspan="2" width="270px">
                <asp:RadioButtonList ID="rbAddressedTo" runat="server">
                    <asp:ListItem Value="0" Selected="True">"To whom it may concern" </asp:ListItem>
                    <asp:ListItem Value="1">A specific person / company named: </asp:ListItem>
                </asp:RadioButtonList></td>
            <td style="height:20px;"></td>
        </tr>
        <tr>
            <td><asp:TextBox ID="txtAddressedTo" runat="server" Width="250px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="3" style="height:30px; vertical-align:bottom;">Select the optional detail to be included in the letter:</td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                    
                <asp:CheckBoxList ID="chkOptionalDetail" runat="server">
                    <asp:ListItem Value="0">English Proficiency</asp:ListItem>
                    <asp:ListItem Value="1">Character Certificate</asp:ListItem>
                    <asp:ListItem Value="2">Pass out / Expected Pass out status</asp:ListItem>
                    <asp:ListItem Value="3">C.G.P.A</asp:ListItem>
                </asp:CheckBoxList>
                    
            </td>
        </tr>
        <tr>
            <td style="height: 45px"></td>
            <td colspan="2" style="text-align: center; height: 45px">
                    
                <asp:Button ID="btnApply" runat="server" onclick="btnApply_Click" Text="Apply" 
                    Width="87px" />
                    
            </td>
        </tr>
    </table>
        


</asp:Content>

