<%@ Page Language="C#" MasterPageFile="../MasterPages/mpCMP.master" AutoEventWireup="true" CodeFile="changePassword.aspx.cs" Inherits="changePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCMP" Runat="Server">
<div class="page">
    <div class="pageHeading">Change Password</div>
    
    
    Please select from following:-<br /><br />
    <div style="text-align:center;" align="center">
    <asp:Panel ID="pnlCardsType" runat="server" Width="500px">
        <asp:RadioButton ID="rbDomain" GroupName="rbPassword" runat="server" Text="Domain Authentication" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="rbSFS" GroupName="rbPassword" runat="server" Text="SFS Authentication"/>        
    </asp:Panel>
    </div>
    <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
    <br /><br />
    <div style="display:none; visibility: hidden; height:0px;" id="rhbox_SFS">
        <div class="pageSubHeading">SFS Authentication</div>
        SFS Password will be changed only. Password of domain / Active Directory will not be changed.

        <table >
            <tr><td colspan="3" style="height:33px;"></td></tr>
            <tr>
                <td style="width: 80px">
                </td>
                <td>
                    Old Password:</td>
                <td>
                    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" Width="225px" ValidationGroup="ChangePassword"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                        ErrorMessage="Please enter old password" ValidationGroup="ChangePassword">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 80px">
                </td>
                <td>
                    New Password:</td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Width="225px" ValidationGroup="ChangePassword"></asp:TextBox>                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNewPassword"
                        ErrorMessage="Please enter new password" ValidationGroup="ChangePassword">*</asp:RequiredFieldValidator>
                </td>
            </tr>        
            <tr>
                <td style="width: 80px">
                </td>
                <td>
                    Confirm New Password:</td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" 
                        Width="225px" ValidationGroup="ChangePassword"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please confirm your new password" ValidationGroup="ChangePassword">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirmPassword"
                        ControlToValidate="txtNewPassword" ErrorMessage="Passwords don't match" ValidationGroup="ChangePassword"></asp:CompareValidator></td>
            </tr>        
            <tr>
                <td style="width: 80px">
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="ChangePassword" /></td>
            </tr>
            <tr><td></td>
                <td colspan="2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ValidationGroup="ChangePassword"
                        runat="server" ControlToValidate="txtNewPassword" 
                        ErrorMessage="Password length must be 8 - 15 characters. <br/>Password must have at least one Capital letter, one lower case letter and one number.<br/>(Note: Special character is optional. Special characters &quot; , ; &amp; |' are not allowed.)" 
                        ValidationExpression="(?=^.{8,15}$)((?!.*\s)(?=.*[A-Z])(?=.*[a-z])(?=(.*\d){1,}))((?!.*[&quot;,;&amp;|'])|(?=(.*\W){1,}))(?!.*[&quot;,;&amp;|'])^.*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr><td>&nbsp;</td>
                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="false" ValidationGroup="ChangePassword" />
                </td>
            </tr>                
        </table>
    </div>
    
    <div style="display:none; visibility: hidden; height:0px;" id="rhbox_Domain">
        <div class="pageSubHeading">Domain / Active Directory Authentication</div>
        Domain / Active Directory Password will be changed.

        <table >
            <tr><td colspan="3" style="height:33px;"></td></tr>
            <tr>
                <td style="width: 80px">
                </td>
                <td>
                    Old Password:</td>
                <td>
                    <asp:TextBox ID="txtOldPassword_Domain" runat="server" TextMode="Password" Width="225px" ValidationGroup="ChangePassword_Domain"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1_Domain" runat="server" ControlToValidate="txtOldPassword_Domain"
                        ErrorMessage="Please enter old password" ValidationGroup="ChangePassword_Domain">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 80px">
                </td>
                <td>
                    New Password:</td>
                <td>
                    <asp:TextBox ID="txtNewPassword_Domain" runat="server" TextMode="Password" Width="225px" ValidationGroup="ChangePassword_Domain"></asp:TextBox>                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7_Domain" runat="server" ControlToValidate="txtNewPassword_Domain"
                        ErrorMessage="Please enter new password" ValidationGroup="ChangePassword_Domain">*</asp:RequiredFieldValidator>
                </td>
            </tr>        
            <tr>
                <td style="width: 80px">
                </td>
                <td>
                    Confirm New Password:</td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword_Domain" runat="server" TextMode="Password" 
                        Width="225px" ValidationGroup="ChangePassword_Domain"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4_Domain" runat="server" ControlToValidate="txtConfirmPassword_Domain" ErrorMessage="Please confirm your new password" ValidationGroup="ChangePassword_Domain">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1_Domain" runat="server" ControlToCompare="txtConfirmPassword_Domain"
                        ControlToValidate="txtNewPassword_Domain" ErrorMessage="Passwords don't match" ValidationGroup="ChangePassword_Domain"></asp:CompareValidator></td>
            </tr>        
            <tr>
                <td style="width: 80px">
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit_Domain" runat="server" OnClick="btnSubmit_Domain_Click" Text="Submit" ValidationGroup="ChangePassword_Domain" /></td>
            </tr>
            <tr><td></td>
                <td colspan="2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1_Domain"  ValidationGroup="ChangePassword_Domain"
                        runat="server" ControlToValidate="txtNewPassword_Domain" 
                        ErrorMessage="Password length must be 8 - 15 characters. <br/>Password must have at least one Capital letter, one lower case letter and one number.<br/>(Note: Special character is optional. Special characters &quot; , ; &amp; |' are not allowed.)" 
                        ValidationExpression="(?=^.{8,15}$)((?!.*\s)(?=.*[A-Z])(?=.*[a-z])(?=(.*\d){1,}))((?!.*[&quot;,;&amp;|'])|(?=(.*\W){1,}))(?!.*[&quot;,;&amp;|'])^.*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr><td>&nbsp;</td>
                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1_Domain" runat="server" ShowMessageBox="True" ShowSummary="false" ValidationGroup="ChangePassword_Domain" />
                </td>
            </tr>                
        </table>
    </div>
    
    <%--<br /><br />
    <div class="pageSubHeading">Password Policy for new password:</div>
    <ul>
        <li>Password length must be 8 - 15 characters.</li>
        <li>Password must have at least one each of following</li>
        <ul>
            <li>at least one Capital letter</li>
            <li>at least one Lower case letter</li>
            <li>at least one Number</li>
        </ul>
        <li>Note:</li>
        <ul>
            <li>Special character is optional.</li>
            <li>Special characters &quot; , ; &amp; |' are not allowed.</li>
        </ul>
    </ul>--%>
</div>
</asp:Content>

