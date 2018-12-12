<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/mpSFS_App.master" AutoEventWireup="true" CodeFile="Tasks.aspx.cs" Inherits="SFS_Tasks" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.5.2356, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder21" Runat="Server">
    <div class="page" style=" vertical-align:top;">
        <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
        <asp:Label ID="lblMessage_Records" runat="server" ForeColor="Blue"></asp:Label>

        <div class="pageHeading">Tasks</div>
        <asp:Panel ID="pnlFilters" runat="server" Visible="false">
        
        <table>
            <tr>
                <td colspan="5" style="vertical-align:middle;">
                    <ul style="margin-top:0px; margin-bottom:0px;">
                        <li>Before new Search:&nbsp;&nbsp;&nbsp;&nbsp;Press&nbsp;&nbsp;
                            <asp:Button ID="btnUnFilter" runat="server" Text="Un-Filter"  Width="60px"
                        onclick="btnUnFilter_Click" />
                        </li>
                        <li>After Searching:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Press&nbsp;&nbsp;
                       
                    <asp:Button ID="btnDefault" runat="server" Text="Default"  Width="60px" ToolTip="This will set filters "
                        onclick="btnDefault_Click" />

                        </li>
                    </ul>
                       
                    </td>
                <td style="width:120px;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    
                    <asp:DropDownList ID="ddlDept" runat="server" Width="192px"></asp:DropDownList>
                    
                </td>
                <td style="width:120px;">
                    <ew:CalendarPopup ID="cpuFrom" runat="server" Width="70px" SelectedDate="2013-02-01"></ew:CalendarPopup>
                </td>
                <td rowspan="2">
                    <asp:Button ID="btnFilter" runat="server" onclick="btnFilter_Click"  Width="61px"
                        Text="Filter" ForeColor="Blue" Height="66px" /></td>
            </tr>
            <tr>
                <td style="width:50px;">
                    <asp:TextBox ID="txtRefNo" runat="server" Width="45px"></asp:TextBox></td>
                <td style="text-align: center">
                    
                    <asp:DropDownList ID="ddlTaskStatus" runat="server" Width="80px"></asp:DropDownList>
                    
                </td>
                <td style="text-align: center">
                    
                    <asp:DropDownList ID="ddlTaskType" runat="server" Width="80px"></asp:DropDownList>
                    
                </td>
                <td style="text-align: center">
                    
                    <asp:TextBox ID="txtSubject" runat="server" Width="200px"></asp:TextBox>
                    
                </td>
                <td style="text-align: center">
                    <asp:TextBox ID="txtCreatedBy" runat="server" Width="190px"></asp:TextBox>
                    </td>
                <td ><ew:CalendarPopup ID="cpuTo" runat="server" Width="70px"></ew:CalendarPopup></td>
            </tr>
        </table>
        </asp:Panel>
        <asp:GridView ID="gvTasks" runat="server" AutoGenerateColumns="false"
            BackColor="White" BorderColor="#B6C9E7" BorderStyle="Ridge" BorderWidth="1px"
            CellPadding="3" GridLines="Both" ShowHeader="true"  
            AllowPaging="true" onpageindexchanging="gvTasks_PageIndexChanging" PageSize="100">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblT_Id" runat="server" Text='<%# Bind("T_Id") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="0%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ref. #">
                    <ItemTemplate>
                        <asp:Label ID="lblReferenceId" runat="server" Text='<%# Bind("T_Ref") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblTStatus" runat="server" Text='<%# Bind("TStatus") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="80px" />                
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Category" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblCTitle" runat="server" Text='<%# Bind("CTitle") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:Label ID="lblTType" runat="server" Text='<%# Bind("TT_Title") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject">
                    <ItemTemplate>                        
                        <asp:HyperLink ID="hlPublicationDetail" runat="server" Text='<%# Bind("T_Title") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem , "TT_URL") + "?TId=" + DataBinder.Eval(Container.DataItem , "T_Id") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Initiated By">
                    <ItemTemplate>
                        <asp:Label ID="lblQFrom" runat="server" Text='<%# Bind("CreatedBy_Id") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="190px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Created On">
                    <ItemTemplate>
                        <asp:Label ID="lblCreatedOn" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" VerticalAlign="Top" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />  
            <PagerSettings LastPageText="&amp;lt;&amp;lt;" />
        </asp:GridView>
    </div>
</asp:Content>

