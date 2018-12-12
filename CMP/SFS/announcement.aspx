<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS_Public.master" AutoEventWireup="true" CodeFile="announcement.aspx.cs" Inherits="announcement" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.5.2356, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPublicSFS" Runat="Server">
    <div class="page">
        <div class="pageHeading">Announcement Detail</div>
        <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
        
        <asp:FormView DefaultMode="ReadOnly" ID="fvAnnouncementDetail" runat="server">
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width:900px;"><asp:Label CssClass="pageSubHeading" ID="lblSubject" runat="server" Text='<%# Bind("ASubject") %>'></asp:Label><br /><br /></td>
                    </tr>
                    <tr>
                        <td> 
                            <asp:Label ID="txtDescription" runat="server"  Text='<%# Bind("ADescription") %>'></asp:Label><br /><br />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
        <asp:Panel ID="pnlAttachments" runat="server" ></asp:Panel>
        <div style="text-align:right;"><asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" Visible="false" /></div>
    </div>
</asp:Content>

