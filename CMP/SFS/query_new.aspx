<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS_App.master" AutoEventWireup="true" CodeFile="query_new.aspx.cs" Inherits="query_new" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder21" Runat="Server">
    <div class="page">
    <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
    <div class="pageHeading">New Query </div>
        <table>
            <tr><td></td><td style="color:Blue;" colspan="2">Please check that correct category is selected:</td></tr>
            <tr>
                <td style="width:140px;">Category:</td>
                <td>
                    <asp:DropDownList Width="607px" ID="ddlCategories" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="ddlCategories" ErrorMessage="Please Select Category" 
                        Operator="NotEqual" ValidationGroup="AddQuery" ValueToCompare="0">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>Subject:</td>
                <td><asp:TextBox Width="600px" ID="txtSubject" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter the subject" ControlToValidate="txtSubject" ValidationGroup="AddQuery">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Description:</td>
                <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"  Height="300px"  Width="604px" ></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter the Description" ControlToValidate="txtDescription" ValidationGroup="AddQuery">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Attachment</td>
                <td><asp:FileUpload ID="fuAttachment"  runat="server"  Width="607px" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnAddQuery" runat="server" Text="Submit" OnClick="btnAddQuery_Click" ValidationGroup="AddQuery" /></td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" 
            ShowSummary="false" runat="server" ValidationGroup="AddQuery" />
    </div>
    
</asp:Content>

