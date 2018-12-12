<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="Announcement_Edit.aspx.cs" Inherits="Announcement_Edit" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.5.2356, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page">
        <div class="pageHeading">Edit Announcement Detail</div>
        <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
        <asp:FormView DefaultMode="Edit" ID="fvAnnouncementDetail" runat="server" Visible="false">
            <EditItemTemplate>
                <table>
                    <tr>
                        <td>Subject:</td>
                        <td><asp:TextBox Width="800px" ID="txtSubject" runat="server" Text='<%# Bind("ASubject") %>'></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter the subject" ControlToValidate="txtSubject" ValidationGroup="EditAnnouncement">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>Description:</td>
                        <td><asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("ADescription") %>' TextMode="MultiLine"  Height="200px"  Width="800px" ></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter the Description" ControlToValidate="txtDescription" ValidationGroup="EditAnnouncement">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            Visibility:</td>
                        <td colspan="2">
                            <ew:CalendarPopup ID="cpuVisibilityStart" SelectedDate='<%# Bind("VisibilityStartTime") %>'  runat="server">
                            </ew:CalendarPopup>
                            &nbsp; to&nbsp; 
                            <ew:CalendarPopup ID="cpuVisibilityEnd" SelectedDate='<%# Bind("VisibilityEndTime") %>' runat="server">
                            </ew:CalendarPopup>
                        </td>
                    </tr>
                     <tr>
                        <td>Attachment</td>
                        <td colspan="2">
                            <asp:HyperLink ID="hlAttachment" Text='<%# Bind("AttachmentTitle") %>' NavigateUrl='<%# Bind("AttachmentPath") %>' runat="server"></asp:HyperLink>
                            <asp:FileUpload ID="fuAttachment"  runat="server"  Width="400px" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2"><asp:Button ID="btnEditAnnouncement" runat="server" Text="Save" ValidationGroup="EditAnnouncement" OnClick="btnEditAnnouncement_Click" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
        &nbsp;
    </div>
</asp:Content>



