<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS_App.master" AutoEventWireup="true" CodeFile="query.aspx.cs" Inherits="query" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder21" Runat="Server">
    <div class="page">
        <div class="pageHeading">Detail of Query</div>
        <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
        <asp:FormView DefaultMode="Edit" ID="fvQueryDetail" runat="server" >
            <EditItemTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" style="text-align:right; padding-right:30px;">
                            <asp:Button ID="btnReply" runat="server" Text="Reply" OnClick="btnReply_Click" />
                            <asp:Button ID="btnForward" runat="server" Visible="false" Text="Forward" OnClick="btnForward_Click" />
                            <asp:HyperLink ID="hlGetSPF" runat="server" Visible="false" Text="Student File"  NavigateUrl="SPFDetail.aspx" Target="_blank"  />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:120px;">Reference No:</td>
                        <td style="width:600px;"><asp:Label ID="Label1" runat="server" Text='<%# Bind("T_Ref") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Subject:</td>
                        <td><asp:Label ID="lblSubject" runat="server" Text='<%# Bind("QSubject") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Category:</td>
                        <td><asp:Label ID="lblCategory" runat="server" Text='<%# Bind("CTitle") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Status:</td>
                        <td>
                             <asp:DropDownList ID="ddlQStatus" runat="server" Text='<%# Bind("TStatusId") %>' Enabled="false" Width="200px">
                                <asp:ListItem Value="1">Pending Queries</asp:ListItem>
                                <asp:ListItem Value="2">On Hold Queries</asp:ListItem>
                                <asp:ListItem Value="3">Completed Queries</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btnUpdateQStatus" runat="server" Text="Update Status" Visible="false" OnClick="btnUpdateQStatus_Click" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
        <br />
        <asp:Panel ID="pnlAddConversation" runat="server" Visible="false">
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblIndication" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlUsers" runat="server" Height="17px" Visible="False" 
                            Width="294px">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="ddlUsers" ErrorMessage="Please Select Recipient" Operator="NotEqual" 
                            ValidationGroup="Save" ValueToCompare="0">*</asp:CompareValidator>
                        <br />
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"  
                            Height="280px"  Width="500px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="Please Enter the Description" ControlToValidate="txtDescription" 
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnSave_Reply" runat="server" OnClick="btnSave_Reply_Click" Text="Reply" 
                            ValidationGroup="Save" Height="229px" Width="80px" Font-Bold="True" 
                            Font-Underline="False" ForeColor="#0066CC" Visible="false" />
                            &nbsp;
                        <asp:Button ID="btnSave_Forward" runat="server" OnClick="btnSave_Forward_Click" Text="Forward" 
                            Height="229px" Width="80px" Font-Bold="True" 
                            Font-Underline="False" ForeColor="Maroon" Visible="false" 
                            ValidationGroup="Save" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>   
                    <td><asp:HyperLink ID="hlGetSPF" runat="server" Text="Student File"  NavigateUrl="javascript:toggleBoxTab('rhboxtab_', '1', '#000000', '#BDD4FD'); showBoxDiv('rhbox_', 'rhbox_SPF')"/></td>                
                    <td>
                        <div style="display:none; visibility: hidden; height:0px;" id="rhbox_SPF">
                            <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="false"
                                BackColor="White" BorderColor="#B6C9E7" BorderStyle="Ridge" BorderWidth="1px"
                                CellPadding="3" GridLines="Both" ShowHeader="true" AllowSorting="true">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocumentId" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="0%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Documents in Student File">
                                        <ItemTemplate>                        
                                            <asp:HyperLink ID="hlDescription" runat="server" Text='<%# Bind("Description") %>' NavigateUrl='<%# "SPFDocument.aspx?id=" + DataBinder.Eval(Container.DataItem , "Location") %>' Target="_blank"></asp:HyperLink>                    
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="500px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkDocument" runat="server" />
                                        </ItemTemplate>
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
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Attachment:
                    </td>
                    <td>
                        <asp:FileUpload ID="fuAttachment" runat="server" Width="550px" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" 
                ShowSummary="false" runat="server" ValidationGroup="Save" />
        </asp:Panel>
        
        <br />
        <asp:Panel ID="pnlQueryConversation" runat="server">
        </asp:Panel>
    </div>
</asp:Content>

