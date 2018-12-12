<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="KnowledgeBase_Accounts.aspx.cs" Inherits="KnowledgeBase_Accounts"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="page">    
    <div class="pageHeading">Knowledge Base</div>

    <asp:Menu ID="Menu1" runat="server" BackColor="LightSteelBlue" DynamicHorizontalOffset="2"
        Font-Names="Verdana"  Font-Size="8pt" ForeColor="#000000" Orientation="Horizontal"
        StaticSubMenuIndent="10px">
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
        <DynamicMenuStyle BackColor="#FFFBD6" />
        <StaticSelectedStyle BackColor="#FFCC66" />
        <DynamicSelectedStyle BackColor="#FFCC66" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <Items>
            <asp:MenuItem NavigateUrl="../SFS/KnowledgeBase.aspx" Text="Registration" Value="Registration"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="../SFS/KnowledgeBase_Exam.aspx" Text="Examination" Value="Examination"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="../SFS/KnowledgeBase_Accounts.aspx" Text="Accounts" Value="Accounts"></asp:MenuItem>
        </Items>
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
    </asp:Menu> 
 
    <div class="pageSubHeading">Accounts</div>
    <div id="accordion">
	<h3><a href="#">Semester Fees/Dues</a></h3>
	<div>
		<p>Students are advised to  pay the semester fees regularly within deadlines to avoid unnecessary fines and  inconvenience.</p>
	</div>
	<h3><a href="#">Scholarships, Financial Assistance & Fee Concession Policies at CIIT Lahore</a></h3>
	<div>
		
		<table border="1" cellpadding="0" cellspacing="0" style="width: 718px">
  <tr>
    <td width="113" valign="top" bgcolor="#CCCCCC"><p align="center"><strong><em>Scholarship Title</em></strong><strong> </strong></p></td>
    <td width="134" valign="top" bgcolor="#CCCCCC"><p align="center"><strong>Amount</strong><strong> </strong></p></td>
    <td width="180" valign="top" bgcolor="#CCCCCC"><p align="center"><strong>Eligibility</strong><strong> </strong></p></td>
    <td valign="top" bgcolor="#CCCCCC" style="width: 192px"><p align="center"><strong>Continuity</strong></p></td>
  </tr>
  <tr>
    <td width="113" valign="top"><p><em>Talent Hunt Scholarship</em></p></td>
    <td width="134" valign="top"><p align="center">100% Tuition Fee Waiver</p></td>
    <td width="180" valign="top"><p>Top 3 position holder of a board/university</p></td>
    <td valign="top" style="width: 192px"><p>Subject    to a minimum GPA of 3.5&nbsp; in subsequent    semesters</p></td>
  </tr>
  <tr>
    <td width="113" valign="top"><p><em>&nbsp;</em>&nbsp;</p>
        <p>
            <em>Financial Assistance Program</em> 
        </p>
    </td>
    <td width="134" valign="top"><p align="center">&nbsp;</p>
        <p align="center">Up to Maximum Rs. 20,000/ </p></td>
    <td width="180" valign="top"><p>Obtaining minimum 2.75    GPA in a semester along with meeting other conditions as per CIIT criteria on    need and proven poverty basis </p></td>
    <td valign="top" style="width: 192px"><p>Subject to eligibility    as detailed in previous column&nbsp; </p></td>
  </tr>
  <tr>
    <td width="113" valign="top"><p><em>&nbsp;</em>&nbsp;</p>
        <p><em>Kinship Concession</em></p></td>
    <td width="134" valign="top"><p align="center">&nbsp;</p>
        <p align="center">Rs. 8,000/-</p></td>
    <td width="180" valign="top"><p>In case of two or more    siblings are students, all the students will get scholarship except the one.</p></td>
    <td valign="top" style="width: 192px"><p>&nbsp;Subject to 2 GPA in subsequent semesters by    all the siblings.</p></td>
  </tr>
  <tr>
    <td width="113" valign="top"><p><em>Undergraduate Scholarships </em> </p></td>
    <td width="134" valign="top"><p align="center"><em>Amount &amp; number of    scholarship is class Size / position based as detailed in following table</em> </p></td>
    <td width="180" valign="top"><p>(In first semester)</p>
        <p>
            NTS Score: 70%, <br />
        Board Exam Marks: 60%</p>
    </td>
    <td valign="top" style="width: 192px"><p>(2nd semester    onward)</p>
      <p>GPA: 3.5 &amp; above</p></td>
  </tr>
</table>
<table border="1" cellspacing="0" cellpadding="0" style="width: 718px">
  <tr>
    <td width="612" colspan="8" valign="bottom" bgcolor="#CCCCCC"><p align="center"><strong><em>*Class Size    Based /Position Wise Scholarship Details</em></strong></p></td>
  </tr>
  <tr>
    <td width="204" valign="bottom"><p align="center"><em>Class Size</em><br />
            <em>(Excluding Labor, ICT &amp; DIK quota    students)</em></p></td>
    <td width="60" valign="bottom"><p><em>No. of Scholar-</em><br />
            <em>Ship(s)</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>Ist Position</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>2nd Position</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>3rd Position</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>4th Position</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>5th Position</em></p></td>
    <td width="56" valign="bottom"><p align="center"><em>6th Position</em></p></td>
  </tr>
  <tr>
    <td width="204" valign="bottom"><p align="center"><em>150 plus</em></p></td>
    <td width="60" valign="bottom"><p align="center"><em>6</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>24,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>20,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>17,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>14,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>11,000/-</em></p></td>
    <td width="56" valign="bottom"><p align="center"><em>9,000/-</em></p></td>
  </tr>
  <tr>
    <td width="204" valign="bottom"><p align="center"><em>120-149</em></p></td>
    <td width="60" valign="bottom"><p align="center"><em>5</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>20,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>17,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>14,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>11,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>9,000/-</em></p></td>
    <td width="56" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
  </tr>
  <tr>
    <td width="204" valign="bottom"><p align="center"><em>90-119</em></p></td>
    <td width="60" valign="bottom"><p align="center"><em>4</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>17,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>14,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>11,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>9,000/-</em></p></td>
    <td width="58" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
    <td width="56" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
  </tr>
  <tr>
    <td width="204" valign="bottom"><p align="center"><em>60-89</em></p></td>
    <td width="60" valign="bottom"><p align="center"><em>3</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>14,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>11,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>9,000/-</em></p></td>
    <td width="58" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
    <td width="58" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
    <td width="56" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
  </tr>
  <tr>
    <td width="204" valign="bottom"><p align="center"><em>30 to 59</em></p></td>
    <td width="60" valign="bottom"><p align="center"><em>2</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>11,000/-</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>9,000/-</em></p></td>
    <td width="58" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
    <td width="58" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
    <td width="58" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
    <td width="56" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
  </tr>
  <tr>
    <td width="204" valign="bottom"><p align="center"><em>10 to 29</em></p></td>
    <td width="60" valign="bottom"><p align="center"><em>1</em></p></td>
    <td width="58" valign="bottom"><p align="center"><em>9,000/-</em></p></td>
    <td width="58" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
    <td width="58" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
    <td width="58" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
    <td width="58" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
    <td width="56" valign="bottom" bgcolor="#CCCCCC"><p align="center"><em>&nbsp;</em>&nbsp;</p></td>
  </tr>
</table>
		
		
	</div>
	<h3><a href="#">Refund of Dues /Admission Cancellation</a></h3>
	<div>
		<p>After  payment of the semester fees, if a student wishes to quit studies for whatever  reason, no refund shall be allowed except the caution money</p>
	</div>
</div>

</div>
</asp:Content>

