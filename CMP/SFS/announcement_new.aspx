<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="announcement_new.aspx.cs" Inherits="announcement_new" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.5.2356, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page">
        <div class="pageHeading">New Announcement</div>

        <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
        
        <asp:Panel ID="pnlAnnouncement_New" runat="server" Visible="false">
            <table>
                <tr>
                    <td>Subject:</td>
                    <td><asp:TextBox Width="800px" ID="txtSubject" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter the subject" ControlToValidate="txtSubject" ValidationGroup="AddAnnouncement">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Description:</td>
                    <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"  Height="200px"  Width="800px" ></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter the Description" ControlToValidate="txtDescription" ValidationGroup="AddAnnouncement">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                        Visibility:</td>
                    <td colspan="2">
                        <ew:CalendarPopup ID="cpuVisibilityStart" runat="server">
                        </ew:CalendarPopup>
                        &nbsp; to&nbsp; 
                        <ew:CalendarPopup ID="cpuVisibilityEnd" runat="server">
                        </ew:CalendarPopup>
                    </td>
                </tr>
                <tr>
                    <td>Attachment</td>
                    <td colspan="2"><asp:FileUpload ID="fuAttachment"  runat="server"  Width="804px" /></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <%--Following panel will contain batches which will have current students--%> 
                        <asp:Panel ID="pnlBatches" runat="server">
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2"><asp:Button ID="btnAddAnnouncement" runat="server" Text="Add Announcement" OnClick="btnAddAnnouncement_Click" ValidationGroup="AddAnnouncement" /></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" ValidationGroup="AddAnnouncement" runat="server" />
    </div>
</asp:Content>

