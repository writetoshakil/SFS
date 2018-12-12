<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="announcements.aspx.cs" Inherits="announcements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page">
        <div class="pageHeading">Announcements</div>
        <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
        <asp:GridView ID="gvAnnouncements" runat="server" AutoGenerateColumns="false"
            BackColor="White" BorderColor="#B6C9E7" BorderStyle="Ridge" BorderWidth="1px"
            CellPadding="3" GridLines="Both" ShowHeader="true" AllowSorting="true">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblAnnouncementId" runat="server" Text='<%# Bind("AnnouncementId") %>' ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="0%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject">
                    <ItemTemplate>                        
                        <asp:HyperLink ID="hlASubject" runat="server" Text='<%# Bind("ASubject") %>' NavigateUrl='<%# "announcement.aspx?AId=" + DataBinder.Eval(Container.DataItem , "AnnouncementId") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="430px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visibility Start">
                    <ItemTemplate>
                        <asp:Label ID="lblVisibilityStartTime" runat="server" Text='<%# Bind("VisibilityStartTime") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visibility End">
                    <ItemTemplate>
                        <asp:Label ID="lblVisibilityEndTime" runat="server" Text='<%# Bind("VisibilityEndTime") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Edited By">
                    <ItemTemplate>
                        <asp:Label ID="lblLastEditedBy" runat="server" Text='<%# Bind("lastEditedBy") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Edited  On">
                    <ItemTemplate>
                        <asp:Label ID="lblLastEditedOn" runat="server" Text='<%# Bind("lastEditedOn") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" VerticalAlign="Top" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
    </div>
</asp:Content>

