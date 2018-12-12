<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="SFMS-FeeConfirmation.aspx.cs" Inherits="SFMS_FeeConfirmation" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.5.2356, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="page">
        <div class="pageHeading">Fee Confirmation</div>
        <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>

        <br />
        <br />
    <asp:Panel ID="pnlFilter" runat="server" Visible="false">
        <table>
            <tr>
                <td>Filter by Insertion Date:</td>
                <td width="20px"></td>
                <td><ew:CalendarPopup ID="cpuUpdatedOn" runat="server"></ew:CalendarPopup></td>
                <td width="20px"></td>
                <td>
                    <asp:Button ID="btnFilter" runat="server" Text="Get Data" 
                        onclick="btnFilter_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
        <br />
        <asp:GridView ID="gvChallans" runat="server" AutoGenerateColumns="False"
            BackColor="White" BorderColor="#B6C9E7" BorderStyle="Ridge" BorderWidth="1px"
            CellPadding="3" EnableModelValidation="True" 
            onrowcancelingedit="gvChallans_RowCancelingEdit" 
            onrowediting="gvChallans_RowEditing" onrowupdating="gvChallans_RowUpdating" >
            <Columns>
                <asp:TemplateField HeaderText="Student ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblStudent_ID" runat="server" Text='<%# Bind("Student_ID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblStudent_ID" runat="server" Text='<%# Bind("Student_ID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Challan No" >
                    <ItemTemplate>
                        <asp:Label ID="lblChallanNo" runat="server" Text='<%# Bind("ChallanNo") %>'></asp:Label>
                    </ItemTemplate>
                     <EditItemTemplate>
                        <asp:Label ID="lblChallanNo" runat="server" Text='<%# Bind("ChallanNo") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" >
                    <ItemTemplate>
                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>'></asp:Label>
                    </ItemTemplate>
                     <EditItemTemplate>
                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bank Branch">
                    <ItemTemplate>
                        <asp:Label ID="lblBank_Branch" runat="server" Text='<%# Bind("Bank_Branch") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBank_Branch" runat="server" Text='<%# Bind("Bank_Branch") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBank_Branch" runat="server" Text="*" ValidationGroup="editGvChallans" ErrorMessage="Please enter Name of Bank Branch" ControlToValidate="txtBank_Branch"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="250px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Deposit_Date">
                    <ItemTemplate>
                        <asp:Label ID="lblDeposit_Date" runat="server" Text='<%# Bind("Deposit_Date") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <ew:CalendarPopup ID="cpuDeposit_Date" runat="server"></ew:CalendarPopup>
                        <asp:RequiredFieldValidator ID="rfvDepositDate" runat="server" Text="*" ValidationGroup="editGvChallans" ErrorMessage="Please enter date of deposit" ControlToValidate="cpuDeposit_Date"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Updated On">
                    <ItemTemplate>
                        <asp:Label ID="lblUpdatedOn" runat="server" Text='<%# Bind("UpdatedOn") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblUpdatedOn" runat="server" Text='<%# Bind("UpdatedOn") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField >
                    <EditItemTemplate> 
                        <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" ValidationGroup="editGvChallans"></asp:LinkButton> 
                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                    </EditItemTemplate>
                    <ItemTemplate> 
                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text='<%# Bind("Allow_Add_Detail") %>'></asp:LinkButton> 
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
    </div>
</asp:Content>

