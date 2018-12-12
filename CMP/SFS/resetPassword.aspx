<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="resetPassword.aspx.cs" Inherits="resetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="page">
    <div class="pageHeading">Reset Students' Password</div>
    <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
    <table >
        <tr>
            <td colspan="1" style="width: 123px; text-align: center">
            </td>
            <td colspan="2" style="text-align: center">                
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="GetData" />
            </td>
            <td colspan="1" style="text-align: center">
            </td>
        </tr>
        <tr>
            <td style="width: 123px">
                Registration No:</td>
            <td>
                <asp:Label ID="lblRegistrationNo_Prefix" runat="server" Font-Bold="False" ForeColor="Blue"
                    Text="CIIT/"></asp:Label>
                <asp:TextBox ID="txtRegistrationNo" runat="server"></asp:TextBox>
                <asp:Label ID="lblRegistrationNo_Postfix" runat="server" Font-Bold="False" ForeColor="Blue"
                    Text="/LHR"></asp:Label></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRegistrationNo"
                    ErrorMessage="Please Enter Registration No" ValidationGroup="GetData">*</asp:RequiredFieldValidator></td>
            <td>
                <asp:Button ID="btnGetData" runat="server" OnClick="btnGetData_Click" Text="Confirm Student Name"
                    ValidationGroup="GetData" /></td>
        </tr>
    </table>
</div>
    <br />
    <asp:Panel ID="pnlResetPassword" runat="server" Width="573px" Visible="false">
        <table>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="width: 124px">Registration No:</td>
                <td style="width: 241px"><asp:Label ID="lblRegistrationNo" runat="server"></asp:Label></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 16px"></td>
                <td style="width: 124px">Student Name:</td>
                <td style="width: 241px"><asp:Label ID="lblStudentName" runat="server"></asp:Label></td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 16px"></td>
                <td style="width: 124px">Guardian Name:</td>
                <td style="width: 241px"><asp:Label ID="lblGuardianName" runat="server"></asp:Label></td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 16px"></td>
                <td style="width: 124px">
                    New Password:</td>
                <td style="width: 241px">
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                        ErrorMessage="Please Enter New Password" ValidationGroup="ResetPassword">*</asp:RequiredFieldValidator></td>                
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="width: 124px">
                    Confirm Password:</td>
                <td style="width: 241px">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword"
                        ErrorMessage="Please confirm new password" ValidationGroup="ResetPassword">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirmPassword"
                        ControlToValidate="txtNewPassword" ErrorMessage="Passwords don't match" ValidationGroup="ResetPassword"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="width: 124px">
                </td>
                <td style="width: 241px">
                    <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" ValidationGroup="ResetPassword" OnClick="btnResetPassword_Click" /></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="width: 124px">
                </td>
                <td style="width: 241px">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="ResetPassword" />
                </td>
                <td>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

