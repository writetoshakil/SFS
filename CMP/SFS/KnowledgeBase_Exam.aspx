<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="KnowledgeBase_Exam.aspx.cs" Inherits="KnowledgeBase_Exam"  %>

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
    
    <div class="pageSubHeading">Examination</div>
    <div id="accordion">  
        <h3><a href="#" class="FAQ_Heading">Examination System </a></h3>
        <div>
          <p>In every  semester, two sessionals and one terminal examination is conducted in CIIT. Students  are evaluated in each course on the basis of tests, classroom assignments,  quizzes, practical work in the laboratories, and terminal examinations. The  distribution of marks shall be as follows: </p>
                <ol>
                  <li><span dir="ltr">Courses  without practical/lab work requirement:</span>
                    <table width="40%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td><ul>
                          <li><span dir="ltr">First  Sessional Test</span></li><li><span dir="ltr">Second  Sessional Test</span></li><li><span dir="ltr">Quizzes/Assignments&nbsp;</span></li><li><span dir="ltr">Terminal  Examination&nbsp;</span></li></ul></td>
                        <td>10%<br />
                          15%<br />
                          25%<br />
                          50%</td>
                      </tr>
                    </table>
                    </li>
                  <li><span dir="ltr">Courses  with practical/lab work requirement:</span></li></ol>
                <p><strong>Theory  Part:</strong></p>
                <table width="42%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td><ul>
                      <ul>
                        <li><span dir="ltr">First  Sessional Test</span></li><li><span dir="ltr">Second  Sessional Test</span></li><li><span dir="ltr">Quizzes/Assignments&nbsp;</span></li><li><span dir="ltr">Terminal  Examination&nbsp;</span></li></ul>
                    </ul></td>
                    <td>10%<br />
                      15%<br />
                      25%<br />
                      50%</td>
                  </tr>
                </table>
                <p><strong> Practical/Lab  work Part:</strong></p>
                <table width="42%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td><ul>
                      <ul>
                        <li><span dir="ltr">First  Lab Sessional Test</span></li><li><span dir="ltr">Second  Lab Sessional Test</span></li><li><span dir="ltr">Lab  Assignments&nbsp;</span></li><li><span dir="ltr">Lab  Terminal Examination/Viva</span></li></ul>
                    </ul></td>
                    <td>10%<br />
                      15%<br />
                      25%<br />
                      50%</td>
                  </tr>
                </table>
                      <p><b>Note:</b>&nbsp;&nbsp; Marks in courses with  practical/lab work shall be calculated as per the following formula</p>
                <div>
                 
                        <p>Total      % Marks = {(% Theory Marks X theory credit hours) + (%Practical Marks X      Practical Credit hours)}/Total Credit Hours</p>
                    
                </div>
                <p>The  students shall have to pass separately in theory and in practical/lab work.  Failure in any one, theory or practical, shall result in failure in the course. </p>
                <p><strong><u>Students shall be eligible to appear  in the terminal examination provided:</u></strong></p>
                <ol>
                  <li><span dir="ltr">They have paid all prescribed fees/charges  and have been on the rolls of the campus during that semester;</span></li><li><span dir="ltr">They have registered for the courses  of study and have attended not less than 80% of the lectures/seminars delivered  in each course and 80% of the practical/laboratory work prescribed for the  respective courses.&nbsp;  </span></li>
                </ol>
        </div>
        <h3><a href="#" class="FAQ_Heading">Grading System</a></h3>
        <div>
                <p>The  minimum pass marks for each course shall be 50%. Students obtaining less than  50% marks in any course shall be deemed to have failed in that course.&nbsp; <br />
                The  correspondence between letter grades, credit points, and percentage marks is as  followed:</p>
                <table border="1" cellspacing="0" cellpadding="0" style="width: 689px; text-align: center">
                  <tr>
                      <td bgcolor="#cccccc" style="width: 64px" valign="middle">
                      </td>
                    <td valign="top" bgcolor="#CCCCCC" style="width: 146px"><p align="center"><strong>Letter    Grade</strong></p></td>
                    <td valign="top" bgcolor="#CCCCCC" style="width: 90px"><p align="center"><strong>Credit    Points</strong></p></td>
                    <td valign="top" bgcolor="#CCCCCC" style="width: 166px"><p align="center"><strong>Percentage    Marks</strong></p></td>
                  </tr>
                  <tr>
                      <td style="width: 64px; height: 18px" valign="middle">
                          <strong>A</strong>&nbsp;</td>
                    <td valign="top" style="width: 146px; height: 18px"><p style="text-align: center"> <strong>(excellent)</strong> </p></td>
                    <td valign="top" style="width: 90px; height: 18px"><p align="center">4.0</p></td>
                    <td valign="top" style="width: 166px; height: 18px"><p align="center">90 and above</p></td>
                  </tr>
                  <tr>
                      <td style="width: 64px;" valign="middle">
                          <strong>A-</strong></td>
                    <td valign="top" style="width: 146px;"></td>
                    <td valign="top" style="width: 90px;"><p align="center">3.7</p></td>
                    <td valign="top" style="width: 166px;"><p align="center">85&mdash;89</p></td>
                  </tr>
                  <tr>
                      <td style="width: 64px;" valign="middle">
                          <strong>B+</strong></td>
                    <td valign="top" style="width: 146px;"></td>
                    <td valign="top" style="width: 90px;"><p align="center">3.3</p></td>
                    <td valign="top" style="width: 166px;"><p align="center">80&nbsp; &ndash; 84</p></td>
                  </tr>
                  <tr>
                      <td style="width: 64px;" valign="middle">
                          <strong>B </strong>
                      </td>
                    <td valign="top" style="width: 146px;"><p style="text-align: center"><strong>(good)</strong></p></td>
                    <td valign="top" style="width: 90px;"><p align="center">3.0</p></td>
                    <td valign="top" style="width: 166px;"><p align="center">75&nbsp; &ndash; 79</p></td>
                  </tr>
                  <tr>
                      <td style="width: 64px" valign="middle">
                          <strong>B-</strong></td>
                    <td valign="top" style="width: 146px"><p><strong></strong>&nbsp;</p></td>
                    <td valign="top" style="width: 90px"><p align="center">2.7</p></td>
                    <td valign="top" style="width: 166px"><p align="center">70&nbsp; &ndash; 74</p></td>
                  </tr>
                  <tr>
                      <td style="width: 64px" valign="middle">
                          <strong>C+</strong></td>
                    <td valign="top" style="width: 146px"></td>
                    <td valign="top" style="width: 90px"><p align="center">2.3</p></td>
                    <td valign="top" style="width: 166px"><p align="center">65&nbsp; &ndash; 69</p></td>
                  </tr>
                  <tr>
                      <td style="width: 64px" valign="middle">
                          <strong>C </strong>&nbsp;&nbsp;</td>
                    <td valign="top" style="width: 146px"><p style="text-align: center"><strong>(average)</strong></p></td>
                    <td valign="top" style="width: 90px"><p align="center">2.0</p></td>
                    <td valign="top" style="width: 166px"><p align="center">60&nbsp; &ndash; 64</p></td>
                  </tr>
                  <tr>
                      <td style="width: 64px" valign="middle">
                          <strong>C-</strong></td>
                    <td valign="top" style="width: 146px"></td>
                    <td valign="top" style="width: 90px"><p align="center">1.7</p></td>
                    <td valign="top" style="width: 166px"><p align="center">55&nbsp; &ndash; 59</p></td>
                  </tr>
                  <tr>
                      <td style="width: 64px" valign="middle">
                          <strong>D</strong></td>
                    <td valign="top" style="width: 146px"><p style="text-align: center"> <strong>(minimum passing)</strong></p></td>
                    <td valign="top" style="width: 90px"><p align="center">1.3</p></td>
                    <td valign="top" style="width: 166px"><p align="center">50&nbsp; &ndash; 54</p></td>
                  </tr>
                  <tr>
                      <td style="width: 64px" valign="middle">
                          <strong>F </strong>
                      </td>
                    <td valign="top" style="width: 146px"><p style="text-align: center"><strong>(failing)</strong></p></td>
                    <td valign="top" style="width: 90px"><p align="center">0.0</p></td>
                    <td valign="top" style="width: 166px"><p align="center">Less than 50</p></td>
                  </tr>
                </table>
                <p><strong>Note: </strong><em>The marks to be assigned to students shall  be in whole numbers.</em></p>
        </div>
        
        <h3><a href="#" class="FAQ_Heading">Make-Up Examinations</a></h3>
        <div>
            <p>At the discretion of  chairman/head of the concerned department, the make-up of sessional tests may  be permissible under special circumstances. However, make-up of terminal  examination shall not be allowed under any circumstances.</p>        
        </div>
        
              
        <h3><a href="#" class="FAQ_Heading">Assignment of Scholastic Status</a></h3>
        <div>
                            <p>Each  student is assigned a two-letter abbreviated status on the transcript according  to the scholastic achievements during the semester. Each status reflects the  changes in the academic achievements and has been individually explained below:</p>
                    <ol>

                        <li><span dir="ltr"><strong><u>Good Standing (GS)</u></strong></span></li><p>Students  are assigned this status at the beginning of their studies. It is retained as  long as the CGPA does not fall below 2.00/4.00.</p>

                        <li><span dir="ltr"><strong><u>Probation (PB)</u></strong></span></li><p>A  student is placed under probation if his/her CGPA falls below 2.00/4.00 at the  end of a semester.</p>

                        <li><span dir="ltr"><strong><u>Dismissal (DI)</u></strong></span></li></ol>
                    <p>A  student already on probation is automatically dismissed if he/she attains a  second successive probation at the end of a semester.</p>
                            
        </div>
	    
        <h3><a href="#" class="FAQ_Heading">Semester Result Cards</a></h3>
        <div>
          <p>Semester  result cards are dispatched to the concerned departments by the examination  section within 30 days of declaration of final result. Students are advised to  acquire a copy of the same from their concerned department, check it carefully  and retain it for your record. </p>
        </div>   	    
        
        <h3><a href="#" class="FAQ_Heading">Fair Means</a></h3>
        <div>
          <p>Merit is  the second name of justice and justice can only be made using fair means. If  you cheat by using unfair means to get higher grades, better position than your  co fellows, you are making injustice not only to others but to your self also.  The Degree got through unfair means is nothing more than a mere piece of paper  because it has not been obtained with the desired store of knowledge to back  it. Let it be understood clearly that use of unfair means will be firmly dealt  with by the campus authority. </p>
        </div>

        <h3><a href="#" class="FAQ_Heading">Unfair Means In Examinations</a></h3>
        <div>
            <p>The  following shall constitute acts of unfair-means during an examination:</p>
            <ol>
              <li> Using hand signals during an examination.</li><li>Procuring or divulging information to a  student pertaining to the examination question paper.</li><li>Concealing notes on clothing, hands,  caps, shoes or in pockets.</li><li>Supplying  to a student during his/her examination, answer to a question that may or may  not be contained in the question paper.</li><li>Copying  from any paper, book or note, or any electronic device, or allowing any other  student to copy the answer, or using or attempting to use these or any other  unfair means.</li><li>Processing  papers, books, notes, any electronic device, or any material which may possibly  be of assistance in the examination, and which have been explicitly prohibited  in the examination.</li><li>Giving or receiving unlawful assistance  during an examination.</li><li>Impersonating or falsely representing a  student in the examination.</li><li>Replacing an answer book or any portion  thereof.</li><li>Mutilating an answer book by way of  tearing off pages.</li><li>Impeding the progress of an examination  by any means whatsoever.</li><li>Assaulting  or threatening to assault any person in charge of an examination.</li><li>Possessing fire-arms or anything capable of being used as a  weapon of offence during an examination.</li><li>Falsifying  an examination result by any means including the substitution of answer books,  mutilation, or alteration of the examination records, etc.</li><li><span dir="ltr">Approaching  or influencing an employee of the Institute to act corruptly or dishonestly in  the conduct of an examination, declaration of examination result, or marking of  paper or obtaining secret information relating to an examination.</span></li><li><span dir="ltr">Intentionally  or knowingly representing the words or ideas or another as one&rsquo;s own in any  academic exercise, and failure to attribute direct quotation, paraphrase, or  borrowed facts, information, or prose.</span></li><li><span dir="ltr">Mutilating,  altering, interpolating or erasing a certificate or other document or any  record maintained by the Institute, or in any manner using or causing to be  used, a certificate, document or record, knowing that it is mutilated,  interpolated or erased.</span></li><li><span dir="ltr">Any  such offence, which is deemed to constitute the use of unfair-means.</span></li></ol>
        </div>
        <h3><a href="#" class="FAQ_Heading">Punctuality and Attendance</a></h3>
        <div>
         <p>Attendance  in class room/Lab shows relative interest of a student in his/her studies. The  only reason to join an educational institution is undoubtedly to get knowledge  and classroom is the place of learning and enhancing knowledge. Hence no reason  can justify absence except for unavoidable circumstances.<br />
  You  must be aware that at least <strong><u>80 % ATTENDANCE </u></strong>is a <strong><u>MUST</u></strong> in a course (both in theory and practical part) to appear in final examination  of that particular course failing which you will not be allowed in any case to  appear in exam. <strong><u></u></strong><br />
  So be  careful enough to maintain the minimum required attendance otherwise you may  face frustration that despite having full preparation, you are unable to sit in  the examination. </p>
<h5><span dir="ltr">IMPORTANT</span>: All students are advised to keep track of their attendance  record with concerned teacher. In case of any discrepancy, students must get it  corrected before the last day of classes because, once list of students on  short attendance is notified, no correction can be made in the record and  student will get &ldquo;F&rdquo; grade in that course.</h5> 
        </div>

        <h3><a href="#" class="FAQ_Heading">Degree</a></h3>
        <div>
          <p>The Institute shall issue  the degrees. Students are required to complete their entire degree requirements  including projects, internships, viva voce and/or comprehensive examination  within the following time limits.</p>
<table border="1" cellspacing="0" cellpadding="0">
  <tr>
    <td width="189" valign="top" bgcolor="#CCCCCC"><p><strong>Program</strong></p></td>
    <td width="190" valign="top" bgcolor="#CCCCCC"><p><strong>Normal    Duration</strong></p></td>
    <td width="190" valign="top" bgcolor="#CCCCCC"><p><strong>Maximum    Duration</strong></p></td>
  </tr>
  <tr>
    <td width="189" valign="top"><p>Bachelors (4 Years)</p></td>
    <td width="190" valign="top"><p>8 Semesters</p></td>
    <td width="190" valign="top"><p>12 Semesters</p></td>
  </tr>
</table>
<p><strong>Warning: <u>Students  are strictly advised to follow the minimum and maximum time duration of  completing a certain degree program otherwise they will not be eligible for  grant of MEDALS in case minimum duration is crossed and for DEGREE in case  maximum duration is crossed.</u></strong></p>
          
        </div>

        <h3><a href="#" class="FAQ_Heading">Change of Address Intimation</a></h3>
        <div>
            <p>Intimation  about change of permanent or postal address must be made through an application  submitted to the registration branch for changes in the electronic student  record.</p>
        </div>

        <%--
        <h3><a href="#" class="FAQ_Heading"></a></h3>
        <div></div>
        
        <h3><a href="#" class="FAQ_Heading"></a></h3>
        <div></div>--%>
    </div>
</div>
</asp:Content>

