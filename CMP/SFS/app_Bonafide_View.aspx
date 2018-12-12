<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="app_Bonafide_View.aspx.cs" Inherits="SFS_app_Bonafide_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="page">
        <div class="pageHeading">Application for Bonafide Certificate:</div>
        <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
        <asp:FormView DefaultMode="Edit" ID="fvApplicationDetail" runat="server" >
            <EditItemTemplate>
                <table cellpadding="0" cellspacing="0">                    
                    <tr>
                        <td style="width:300px;">Reference No:</td>
                        <td style="width:600px;"><asp:Label ID="Label1" runat="server" Text='<%# Bind("A_Id") %>'></asp:Label></td>
                        <td style="width:100px;">
                            <asp:Button ID="btnReply" runat="server" Text="Reply" OnClick="btnReply_Click" /></td>
                    </tr>
                    <tr>
                        <td>Applied By:</td>
                        <td><asp:Label ID="Label6" runat="server" Text='<%# Bind("CreatedBy_Id") %>'></asp:Label></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td>Applied On:</td>
                        <td><asp:Label ID="Label8" runat="server" Text='<%# Bind("AppliedOn") %>'></asp:Label></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Must be Addressed To:</td>
                        <td><asp:Label ID="lblSubject" runat="server" Text='<%# Bind("AddressedTo") %>'></asp:Label></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr><td>&nbsp;</td><td></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Include English Proficiency:</td>
                        <td><asp:Label ID="lblCategory" runat="server" Text='<%# Bind("EnglishProficiency") %>'></asp:Label></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Include Character Certificate:</td>
                        <td><asp:Label ID="Label2" runat="server" Text='<%# Bind("CharacterCertificate") %>'></asp:Label></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Include Pass Out / Expected Status:</td>
                        <td><asp:Label ID="Label3" runat="server" Text='<%# Bind("PassOut_ExpectedPassOut") %>'></asp:Label></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Include CGPA:</td>
                        <td><asp:Label ID="Label4" runat="server" Text='<%# Bind("CGPA") %>'></asp:Label></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr><td>&nbsp;</td><td></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td><span style=" font-weight:bold; color:Maroon;">Document Created:</span></td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Doc_Created") %>'></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="hlUpdateStatus_Creation" Visible="false" href="javascript:toggleBoxTab('rhboxtab_', '1', '#000000', '#BDD4FD'); showBoxDiv('rhbox_', 'rhbox_Creation')" runat="server">Update</asp:HyperLink>
                            <div style="display:none; visibility: hidden; height:0px;" id="rhbox_Creation">
                                This will update that you have created the document. Are you sure you want to update? 
                                <asp:Button ID="btnUpdateStatus_Creation" runat="server" Text="Submit" 
                                    onclick="btnUpdateStatus_Creation_Click" />
                            </div>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr><td>&nbsp;</td><td></td>
                        <td>
                            &nbsp;</td>
                    </tr>
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
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
       
        <br />
       <asp:Panel ID="pnlAddConversation" runat="server" Visible="false" align="left">
            <table align="left">
                <tr>
                    <td>
                        <asp:Label ID="lblIndication" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                        <br />
                        
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"  
                            Height="280px"  Width="800px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="Please Enter the Description" ControlToValidate="txtDescription" 
                            ValidationGroup="Save">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnSave_Reply" runat="server" OnClick="btnSave_Reply_Click" Text="Reply" 
                            ValidationGroup="Save" Height="229px" Width="80px" Font-Bold="True" 
                            Font-Underline="False" ForeColor="#0066CC" Visible="false" />
                            &nbsp;
                        
                    </td>
                </tr>

                <tr>
                    <td colspan="2">Attachment:
                        <asp:FileUpload ID="fuAttachment" runat="server" Width="650px" />
                    </td>
                </tr>
                <tr><td colspan="2"><asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" 
                ShowSummary="false" runat="server" ValidationGroup="Save" /> </td></tr>
            </table>
           
        </asp:Panel>
       <br />
        <asp:Panel ID="pnlQueryConversation" runat="server">
        </asp:Panel> 
    </div>
</asp:Content>

