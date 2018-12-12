<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="frmOverAllDocuments.aspx.cs" Inherits="frmViewNotification" Title="View Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center">
        <table style="width: 100%">
            <tr>
                <td colspan="4">
                    <div style="text-align: center">
                        <table style="width: 800px">
                            <tr>
                                <td style="width: 200px">
                                </td>
                                <td style="width: 200px; text-align: left;">
                    <asp:DropDownList ID="ddlFilter" runat="server" CssClass="textBox" Width="200px">
                        <asp:ListItem Value="ContainingDepartment">Department</asp:ListItem>
                        <asp:ListItem Value="DocumentDescription">Description</asp:ListItem>
                    </asp:DropDownList></td>
                                <td style="width: 200px; text-align: left;">
                                    <asp:TextBox ID="txtFilter" runat="server" CssClass="textBox" Width="200px"></asp:TextBox></td>
                                <td style="width: 200px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 200px">
                                </td>
                                <td style="width: 200px; text-align: left">
                                </td>
                                <td style="width: 200px">
                                    <asp:Button ID="btnFilter" runat="server" CssClass="button" OnClick="btnFilter_Click"
                                        Text="Filter Record(s)" /></td>
                                <td style="width: 200px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 200px">
                                </td>
                                <td style="width: 200px; text-align: left">
                                </td>
                                <td style="width: 200px; text-align: left">
                                    <asp:Label ID="lblError" runat="server" CssClass="error_text"></asp:Label></td>
                                <td style="width: 200px">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="False" OnRowCommand="gvNotification_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSr" runat="server" CssClass="labelFont"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="gridHeader" />
                                <ItemStyle CssClass="gridItem" HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="documentid" HeaderText="ID" >
                                <HeaderStyle CssClass="gridHeader" />
                                <ItemStyle CssClass="gridItem" HorizontalAlign="Left" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="containingdepartment" HeaderText="Department" >
                                <HeaderStyle CssClass="gridHeader" />
                                <ItemStyle CssClass="gridItem" HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BoxFileName" HeaderText="Box File Name">
                                <HeaderStyle CssClass="gridHeader" />
                                <ItemStyle CssClass="gridItem" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DocumentDescription" HeaderText="Description" >
                                <HeaderStyle CssClass="gridHeader" />
                                <ItemStyle CssClass="gridItem" HorizontalAlign="Left" Width="300px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FileName" HeaderText="File Name">
                                <HeaderStyle CssClass="gridHeader" />
                                <ItemStyle CssClass="gridItem" HorizontalAlign="Left" Width="150px" />
                            </asp:BoundField>
                            <asp:ButtonField CommandName="View" HeaderText="View" Text="View">
                                <HeaderStyle CssClass="gridHeader" />
                                <ItemStyle CssClass="gridItem" />
                            </asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

