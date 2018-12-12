<%@ Page Language="C#" MasterPageFile="MasterPage_Public.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="PL_login"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="page">
    <div class="pageHeading">Login</div>
    <br />
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td colspan="3" style="text-align: left">
                <asp:Label ID="lblException" runat="server" ForeColor="Red" ></asp:Label><br />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 103px">User Id:</td>
            <td style="width: 250px">
                <asp:TextBox ID="txtUserId" runat="server" Width="220px"></asp:TextBox></td>
            <td style="width: 532px; text-align: left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserId"
                    ErrorMessage="Please enter User Id" ValidationGroup="Login">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 103px">Password:</td>
            <td style="width: 250px">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="220px"></asp:TextBox></td>
            <td style="width: 532px; text-align: left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Please enter password" ValidationGroup="Login">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" ValidationGroup="Login" />
                <asp:HyperLink ID="hlForgotPassword" runat="server" Font-Size="Smaller" NavigateUrl="forgotPassword.aspx">Forgot Password</asp:HyperLink></td>
            <td colspan="1" style="width: 532px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 16px; text-align: left">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="Login" />
                <br />
            </td>
        </tr>
    </table>
</div>
    
    
    
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    
</asp:Content>

