<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="queries.aspx.cs" Inherits="queries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page" style=" vertical-align:top;">
        <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
        <div class="pageHeading">Summary</div>
        <asp:Label ID="lblMessage_Summary" runat="server" ForeColor="Blue"></asp:Label>
            <asp:GridView Visible="true" ID="gvSummary" runat="server" AutoGenerateColumns="false"
            BackColor="White" BorderColor="#B6C9E7" BorderStyle="Ridge" BorderWidth="1px"
            CellPadding="3" GridLines="Both" ShowHeader="true">
            <Columns>
                <asp:TemplateField HeaderText="" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblCTitle" runat="server" Text='<%# Bind("CTitle") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pending">
                    <ItemTemplate>
                        <asp:Label ID="lblPending" runat="server" Text='<%# Bind("Pending") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="On Hold">
                    <ItemTemplate>
                        <asp:Label ID="lblOn_Hold" runat="server" Text='<%# Bind("On_Hold") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Completed">
                    <ItemTemplate>
                        <asp:Label ID="lblCompleted" runat="server" Text='<%# Bind("Completed") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" VerticalAlign="Top" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        
        <div class="pageHeading">Queries / Feedbacks / Complaints</div>
        <span style="color:Maroon; font-weight:bold;">Query Status: </span><asp:DropDownList ID="ddlQueryStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlQueryStatus_SelectedIndexChanged" Width="246px"></asp:DropDownList><br /><br />
        <asp:Label ID="lblMessage_Records" runat="server" ForeColor="Blue"></asp:Label>
        <asp:GridView ID="gvQueries" runat="server" AutoGenerateColumns="false"
            BackColor="White" BorderColor="#B6C9E7" BorderStyle="Ridge" BorderWidth="1px"
            CellPadding="3" GridLines="Both" ShowHeader="true" AllowSorting="true">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblQueryId" runat="server" Text='<%# Bind("QueryId") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="0%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ref. #">
                    <ItemTemplate>
                        <asp:Label ID="lblQReferenceId" runat="server" Text='<%# Bind("QReferenceId") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblQStatus" runat="server" Text='<%# Bind("QStatus") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblCTitle" runat="server" Text='<%# Bind("CTitle") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject">
                    <ItemTemplate>                        
                        <asp:HyperLink ID="hlPublicationDetail" runat="server" Text='<%# Bind("QSubject") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem , "TT_URL") + "?QId=" + DataBinder.Eval(Container.DataItem , "QueryId") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="220px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Initiated By">
                    <ItemTemplate>
                        <asp:Label ID="lblQFrom" runat="server" Text='<%# Bind("QFrom") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="190px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Created On">
                    <ItemTemplate>
                        <asp:Label ID="lblCreatedOn" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
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

