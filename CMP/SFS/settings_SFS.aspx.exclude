<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="settings_SFS.aspx.cs" Inherits="settings_SFS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="page">    
    <div class="pageHeading" >Security Question for password reset</div>
    
    In case you forget your password, you can reset your password after verifying your security question and answer if provided as follows. <br /><br />
    <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
    <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:Panel ID="pnlVerification" runat="server" Width="552px">
        Please provide your credentials again for verification.
        <table style="width: 503px">
            <tr>
                <td style="width: 89px">
                </td>
                <td style="width: 103px">User Id:</td>
                <td style="width: 250px"><asp:TextBox ID="txtUserId" runat="server" Width="220px" Enabled="False"></asp:TextBox></td>
                <td style="width: 66px">&nbsp;</td>
            </tr>
            <tr>
               <td style="width: 89px">
               </td>
                <td style="width: 103px">Password:</td>
                <td style="width: 250px">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="220px"></asp:TextBox></td>
                <td style="width: 66px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="Please enter password" ValidationGroup="Verification">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 89px">
                </td>
                <td style="width: 103px">
                </td>
                <td style="width: 250px">
                    <asp:Button ID="btnVerify" runat="server" OnClick="btnVerify_Click" Text="Submit"
                        ValidationGroup="Verification" /></td>
                <td style="width: 66px">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 89px">
                </td>
                <td colspan="3">
                    <asp:ValidationSummary ID="Verification" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Verification" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlSecurity" runat="server" Width="730px">    
        <table>
            <tr>
                <td colspan="4" style="text-align: center">
                    &nbsp;</td>
            </tr>           
            <tr>
                <td style="width: 85px">
                </td>
                <td style="width: 143px">
                    Security Question:</td>
                <td style="width: 358px">
                    <asp:DropDownList ID="ddlssapQuestionId" runat="server" Width="282px">
                        <asp:ListItem Value="0">-- Select Question --</asp:ListItem>
                        <asp:ListItem Value="1">What is your favourite thing?</asp:ListItem>
                        <asp:ListItem Value="2">Who is your childhood best friend?</asp:ListItem>
                        <asp:ListItem Value="3">Who is your favourite author / poet?</asp:ListItem>
                        <asp:ListItem Value="4">Which is your favourite book?</asp:ListItem>
                        <asp:ListItem Value="5">Which is your best rated university?</asp:ListItem>
                        <asp:ListItem Value="6">Who is your best teacher?</asp:ListItem>
                        <asp:ListItem Value="7">Which is your facourite picnic place?</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 167px">
                    <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="ddlssapQuestionId"
                        ErrorMessage="Select security question" Operator="NotEqual" ValueToCompare="-- Select Question --" ValidationGroup="settings">*</asp:CompareValidator></td>
            </tr>
            <tr>
                <td style="width: 85px">
                </td>
                <td style="width: 143px">
                    Answer:</td>
                <td style="width: 358px">
                    <asp:TextBox ID="txtssapAnswer" runat="server" Width="276px"></asp:TextBox></td>
                <td style="width: 167px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtssapAnswer"
                        ErrorMessage="Enter answer of security question" ValidationGroup="settings">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 85px">
                </td>
                <td style="width: 143px">
                </td>
                <td style="width: 358px">
                    <asp:Button ID="btnEditSecurity" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="settings" /></td>
                <td style="width: 167px">
                </td>
            </tr>
            <tr>
                <td style="width: 85px">
                </td>
                <td style="width: 143px">
                </td>
                <td style="width: 358px">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="settings" />
                </td>
                <td style="width: 167px">
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
</asp:Content>

