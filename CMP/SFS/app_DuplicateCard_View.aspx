<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="app_DuplicateCard_View.aspx.cs" Inherits="SFS_app_DuplicateCard_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="page">
        <div class="pageHeading">Application for Student ID Card</div>
        <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
        
        <asp:FormView ID="fvApplicationDetail" runat="server" >
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0">                    
                    <tr>
                        <td style="width:300px;">Reference No:</td>
                        <td style="width:700px;"><asp:Label ID="Label1" runat="server" Text='<%# Bind("A_Id") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Applied By:</td>
                        <td><asp:Label ID="Label6" runat="server" Text='<%# Bind("CreatedBy_Id") %>'></asp:Label></td>
                    </tr>
                   <tr>
                        <td>Applied On:</td>
                        <td><asp:Label ID="Label8" runat="server" Text='<%# Bind("AppliedOn") %>'></asp:Label></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Reason:</td>
                        <td><asp:Label ID="Label2" runat="server" Text='<%# Bind("Reason") %>'></asp:Label></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
       
       <br />

        <asp:FormView ID="fvCardLost" runat="server" >
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0">                                        
                    <tr>
                        <td style="width:300px;">Challan #:</td>
                        <td style="width:700px;"><asp:Label ID="lblSubject" runat="server" Text='<%# Bind("ChallanNo") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Challan Submission Date:</td>
                        <td><asp:Label ID="lblCategory" runat="server" Text='<%# Bind("ChallanSubmissionDate") %>'></asp:Label></td>
                    </tr>  
                </table>
            </ItemTemplate>
        </asp:FormView>

        <br />

        <asp:FormView ID="fvDisciplineChanged" runat="server" >
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0">   
                    <tr>
                        <td style="width:300px;">Previous Program:</td>
                        <td style="width:700px;"><asp:Label ID="Label3" runat="server" Text='<%# Bind("ProgramFrom") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td>New Program:</td>
                        <td><asp:Label ID="Label4" runat="server" Text='<%# Bind("ProgramTo") %>'></asp:Label></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>

        <br />

        <asp:FormView ID="fvDocumentStatus" runat="server" >
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0">                    
                    <tr>
                        <td style="width:300px;"><span style=" font-weight:bold; color:Maroon;">Document Created:</span></td>
                        <td style="width:700px;">
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Doc_Created") %>'></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="hlUpdateStatus_Creation" Visible="false" href="javascript:toggleBoxTab('rhboxtab_', '1', '#000000', '#BDD4FD'); showBoxDiv('rhbox_', 'rhbox_Creation')" runat="server">Update</asp:HyperLink>
                            <div style="display:none; visibility: hidden; height:0px;" id="rhbox_Creation">
                                This will update that you have created the document. Are you sure you want to update? 
                                <asp:Button ID="btnUpdateStatus_Creation" runat="server" Text="Submit" 
                                    onclick="btnUpdateStatus_Creation_Click" />
                            </div>
                        </td>
                    </tr>

                    <tr><td>&nbsp;</td><td></td></tr>
                    <tr>
                        <td><span style=" font-weight:bold; color:Maroon;">Document Issued:</span></td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Doc_Issued") %>'></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="hlIssue_Document" Visible="false" href="javascript:toggleBoxTab('rhboxtab_', '1', '#000000', '#BDD4FD'); showBoxDiv('rhbox_', 'rhbox_Issue_Document')" runat="server">Issue Document</asp:HyperLink>
                            <div style="display:none; visibility: hidden; height:0px;" id="rhbox_Issue_Document">
                                This will update that desired document has been issued. Are you sure you want to update? 
                                <asp:Button ID="btnIssue_Document" runat="server" Text="Submit" 
                                    onclick="btnIssue_Document_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

