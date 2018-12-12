<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/mpSFS_App.master" AutoEventWireup="true" CodeFile="app_DuplicateCard.aspx.cs" Inherits="SFS_app_DuplicateCard" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.5.2356, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder21" Runat="Server">

    <div class="pageHeading">Duplicate Card</div>
    Every student admitted in university is issued with a Student Identity Card, which is handed at the orientation day. 
    <br />
    <br />
    Any student who lost his/her card must select the option of &#39;Duplicate card&#39;. 
    Students who chanded the discipline after admission but didn&#39;t get the identity 
    card must select the option &#39;Changed Discipline&#39;.

    <div class="pageSubHeading" style="padding-top:20px; padding-bottom:20px;">Applying for Student Card</div>
        
    <asp:Label ID="lblException" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Panel ID="pnlCardsType" runat="server" Width="500px">
                    <asp:RadioButton ID="rbDuplicateCard" GroupName="rbCards" runat="server" Text="Duplicate Card"/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbChangedDiscipline" GroupName="rbCards" runat="server" Text="Changed Discipline" />
                </asp:Panel>
            </td>               
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <div style="display:none; visibility: hidden; height:0px;" id="rhbox_DuplicateCard">
                    Please get a challan of 500/- Rs. from Accounts section, SSC for duplicate student card, submit in HBL Bank COMSATS Lahore Branch and provide the following information:-
                     <br /><br />
                     <table >
                        <tr>
                            <td width="160px">Challan #:</td>
                            <td width="20px"></td>
                            <td><asp:TextBox ID="txtChallanNo" runat="server" Width="250px"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Challan #" ControlToValidate="txtChallanNo" ValidationGroup="DuplicateCard">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>Challan Submission Date:</td>
                            <td></td>
                            <td><ew:CalendarPopup ID="cpuChallanSubmissionDate" runat="server"  Width="250px"></ew:CalendarPopup></td>
                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Challan Submission Date" ControlToValidate="cpuChallanSubmissionDate" ValidationGroup="DuplicateCard">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td><asp:Button ID="btnDuplicateCard" runat="server" onclick="btnDuplicateCard_Click" Text="Apply"  Width="87px" ValidationGroup="DuplicateCard" /></td>
                            <td></td>
                        </tr>
                        <tr><td colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="DuplicateCard" ShowMessageBox="true" ShowSummary="true" />
                        </td></tr>
                    </table>
                </div>

                <div style="display:none; visibility: hidden; height:0px;" id="rhbox_ChangedDiscipline">
                    If you were allowed to change the discipline after admission but did not get the changed student card then provide following information and apply:-  
                    <br /><br />
                    <table>
                        <tr>
                            <td width="120px">Previous Program:</td>
                            <td width="20px"></td>
                            <td>
                                <asp:DropDownList ID="ddlProgramFrom" runat="server" ValidationGroup="ChangedDiscipline">
                                    <asp:ListItem Value="-1">-- Select Program --</asp:ListItem>
                                    <asp:ListItem Value="BAR">B-Archtecture</asp:ListItem>
                                    <asp:ListItem Value="BDE">B-Design</asp:ListItem>
                                    <asp:ListItem Value="BFA">B-Fine Arts</asp:ListItem>
                                    <asp:ListItem Value="BCS">BS (Computer Science)</asp:ListItem>
                                    <asp:ListItem Value="BSE">BS (Softrware Engineering)</asp:ListItem>
                                    <asp:ListItem Value="BTE">BS (Electrical in Telecommunication Engineering)</asp:ListItem>
                                    <asp:ListItem Value="BCE">BS (Computer Engineering)</asp:ListItem>
                                    <asp:ListItem Value="BEE">BS (Electronics Engineering)</asp:ListItem>
                                    <asp:ListItem Value="BEC">BS (Chemical Engineering)</asp:ListItem>
                                    <asp:ListItem Value="BBA">BS (Business Administration)</asp:ListItem>
                                    <asp:ListItem Value="BEco">BS (Economics)</asp:ListItem>
                                    <asp:ListItem Value="BPhy">BS (Physics)</asp:ListItem>
                                    <asp:ListItem Value="BPsy">BS (Psychology)</asp:ListItem>                        
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ddlProgramFrom"
                                    ErrorMessage="Select Previous Program" Operator="NotEqual" ValueToCompare="-1" ValidationGroup="ChangedDiscipline">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>New Program:</td>
                            <td></td>
                            <td>
                                <asp:DropDownList ID="ddlProgramTo" runat="server" ValidationGroup="ChangedDiscipline">
                                    <asp:ListItem Value="-1">-- Select Program --</asp:ListItem>
                                    <asp:ListItem Value="BAR">B-Archtecture</asp:ListItem>
                                    <asp:ListItem Value="BDE">B-Design</asp:ListItem>
                                    <asp:ListItem Value="BFA">B-Fine Arts</asp:ListItem>
                                    <asp:ListItem Value="BCS">BS (Computer Science)</asp:ListItem>
                                    <asp:ListItem Value="BSE">BS (Softrware Engineering)</asp:ListItem>
                                    <asp:ListItem Value="BTE">BS (Electrical in Telecommunication Engineering)</asp:ListItem>
                                    <asp:ListItem Value="BCE">BS (Computer Engineering)</asp:ListItem>
                                    <asp:ListItem Value="BEE">BS (Electronics Engineering)</asp:ListItem>
                                    <asp:ListItem Value="BEC">BS (Chemical Engineering)</asp:ListItem>
                                    <asp:ListItem Value="BBA">BS (Business Administration)</asp:ListItem>
                                    <asp:ListItem Value="BEco">BS (Economics)</asp:ListItem>
                                    <asp:ListItem Value="BPhy">BS (Physics)</asp:ListItem>
                                    <asp:ListItem Value="BPsy">BS (Psychology)</asp:ListItem>                        
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlProgramTo"
                                    ErrorMessage="Select New Program" Operator="NotEqual" ValueToCompare="-1" ValidationGroup="ChangedDiscipline">*</asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="ddlProgramFrom" Operator="NotEqual"
                                    ControlToValidate="ddlProgramTo" ErrorMessage="New and Old programs can't be same" ValidationGroup="ChangedDiscipline"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr><td></td><td></td><td><asp:Button ID="btnChangedDiscipline" runat="server" onclick="btnChangedDiscipline_Click" Text="Apply"  Width="87px" ValidationGroup="ChangedDiscipline" /></td><td></td></tr>
                         <tr><td colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="ChangedDiscipline" ShowMessageBox="true" ShowSummary="true" />
                        </td></tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
                
     

</asp:Content>

