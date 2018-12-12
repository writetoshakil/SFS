<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="SPFDetail.aspx.cs" Inherits="SPFDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="page">
    <div class="pageHeading">Student Personal File</div>
    <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
    <asp:Panel ID="pnlDocuments" runat="server" Visible="false">
    
        <table >
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
                    <asp:Button ID="btnGetData" runat="server" OnClick="btnGetData_Click" Text="Get Personal File"
                        ValidationGroup="GetData" /></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 123px; text-align: center">
                    &nbsp;</td>
                <td colspan="2" style="text-align: center">                
                   <span style="font-size:small;"> e.g. SP11-BPH-003</span></td>
                <td colspan="1" style="text-align: center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 123px; text-align: center">
                </td>
                <td colspan="2" style="text-align: center">                
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="GetData" />
                </td>
                <td colspan="1" style="text-align: center">
                </td>
            </tr>
        </table>


        <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="false"
            BackColor="White" BorderColor="#B6C9E7" BorderStyle="Ridge" BorderWidth="1px"
            CellPadding="3" GridLines="Both" ShowHeader="true" AllowSorting="true">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblQueryId" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="0%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Documents in Student File">
                    <ItemTemplate>                        
                        <asp:HyperLink ID="hlDescription" runat="server" Text='<%# Bind("Description") %>' NavigateUrl='<%# "SPFDocument.aspx?id=" + DataBinder.Eval(Container.DataItem , "Location") %>' Target="_blank"></asp:HyperLink>                    
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="500px" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" VerticalAlign="Top" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
    </asp:Panel>
</div>
</asp:Content>

