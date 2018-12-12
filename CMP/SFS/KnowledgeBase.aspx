<%@ Page Language="C#" MasterPageFile="../MasterPages/mpSFS.master" AutoEventWireup="true" CodeFile="KnowledgeBase.aspx.cs" Inherits="KnowledgeBase"  %>

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
    
    <div class="pageSubHeading">Registration</div>
    <div id="accordion">
        <h3><a href="#" class="FAQ_Heading">Registration Of Courses</a></h3>
        <div>
            <p>At the beginning of each semester, students are required to register for a group of courses prescribed for a particular degree program and for a particular semester. </p>
            <p>A student may change (add/drop) course(s) within five teaching days from the date of commencement of a semester on the recommendations of the teacher(s) concerned. </p>
            <p>In order to remain a full-time student of the Institute, a student must be registered in at least 12 credit hours of course work during a semester. The maximum credit hours of course work for which a student can register during a semester, shall not exceed 21.</p>
        </div>
        
        
        
        <h3><a href="#" class="FAQ_Heading">Freezing Of Studies</a></h3>
        <div>
            <p>A student may be allowed to freeze studies before the commencement of a semester, with the permission of the Director of a campus or Incharge of Academic Affairs. Freezing of studies for a bachelor degree program shall not be allowed for more than four semesters in total. For a Master’s degree (16 years) program the maximum limit shall be two semesters in total. However, not more than two semesters in succession shall be allowed to be frozen at a time. <strong>Frozen semester(s) shall count towards the time duration for completing a degree.</strong></p>
            <p>The student may re-enroll in the same semester, which he/she had frozen. The semester fees of the frozen semester, if already paid, shall be allowed to roll over. </p>
            <p><strong>Freezing shall only become effective when appropriately notified, failing which the name of the absentee student shall be struck off the campus rolls. In that case, resumption of studies shall only be allowed after payment of Admission Fee.</strong></p>
        </div>
        
        <h3><a href="#" class="FAQ_Heading">Withdrawal of Courses/Semester</a></h3>
        <div>
            <p>A student may be allowed to withdraw from a course or a whole semester, as the case may be, at any time before the commencement of the second sessional test, with the permission of the Director of a campus/Incharge of Academic Affairs. </p>
            <p>Withdrawal from a course or the whole semester, as the case may be, shall not result in academic penalty. However, the course/semester fees shall not be allowed to roll over. </p>
            <p><strong>IMPORTANT: A withdrawn or frozen semester shall count towards the maximum permissible number of semesters to complete a degree program.</strong></p>
        </div>
        
        <h3><a href="#" class="FAQ_Heading">Migration to other campuses of CIIT</a></h3>
        <div>
            <p>Migration of students from other educational institutions to the Institute is not allowed as we do not have any exemption policy. However, within the Institute students may be allowed to migrate from one campus to another, only under special/genuine circumstances, with the mutual consent of the two campuses, and after the approval of the relevant authority. <strong>Migration shall only be allowed before the commencement of a semester.</strong></p>
        </div>
         <h3><a href="#" class="FAQ_Heading">Migration to other campuses of CIIT</a></h3>
        <div>
            <p>Migration of students from other educational institutions to the Institute is not allowed as we do not have any exemption policy. However, within the Institute students may be allowed to migrate from one campus to another, only under special/genuine circumstances, with the mutual consent of the two campuses, and after the approval of the relevant authority. <strong>Migration shall only be allowed before the commencement of a semester.</strong></p>
        </div>
         <h3><a href="#" class="FAQ_Heading">Frequently Asked Questions (FAQ’s)</a></h3>
        <div>
            <p><b>•	What is the Difference between a semester and a batch?</b><br />
            A student admitted in a particular semester of a year is known to be intake of that particular semester. Now that semester becomes a batch ID for this student to be differentiated from others one. For example, fall 2011 semester intake of students is known as fall 2011 batch studying in first semester i.e. fall 2011. Now the spring 2012 semester will be 2nd semester for fall 2011 batch students while it will be a batch ID for the spring 2012 intake on the one hand and Ist semester on the other.
            </p>
            <p><b>•	What is the Registration number format of the students at CIIT?</b><br />
            Every student is allotted a registration number with format (CIIT/Batch ID-program ID-number/campus name). For example, registration number of a student admitted at CIIT Lahore during fall 2011 semester in BS Chemical Engineering program shall be (CIIT/FA11-BEC-001/LHR). However, for students in Dual Degree Program with Lancaster University UK, it shall be (CIIT/DDP-FA11-BEC-001/LHR).
            </p>
            <p><b>•	Is there any specific duration for completing a degree program?</b><br />
            Yes, there are minimum and maximum durations for completing a degree program, extension in which is not given in any case. For example, all undergraduate programs (BS) are having minimum duration of eight semesters and maximum of twelve. See prospectus for more details.
            </p>
            <p><b>•	I am unable to join or continue studies at CIIT due to some unavoidable circumstances. Can I suspend studies for one semester?</b><br />
            Yes, before commencement of classes of a semester, you can apply for Freeze of semester. However, during a semester is continued you can withdraw the semester till sessional II exam to meet some serious eventualities. You are strongly advised no to leave university without freezing or withdrawal of semester otherwise you will be awarded F grades in the registered courses. 
            </p>
            <p><b>•	Will the frozen or withdrawn semester be counted towards the maximum duration?</b><br />
            Yes, these are counted. 
            </p>
            <p><b>•	Can a course be dropped, if a student fears to fail in it?</b><br />
            In fact, a course can be withdrawn before SII examination. A “W” grade is assigned to that course with no affect on GPA/CGPA. However, the fee for the course will have to be paid again while repeating the course in next semester.
            </p>
            <p><b>•	What is the credit hours requirements for a student to register?</b><br />
            To be a bonafide student in undergraduate program, minimum credit hours 12 and maximum 21 are required to be registered by a student.
            </p>
            <p><b>•	What is SoS?</b><br />
            SoS is abbreviation for Scheme of Studies containing necessary details about a program like course title, course code, credit hours, nature of course (core/optional), prerequisites and the batch(es) ID for which it is effective. You are strictly required to follow the SoS of your respective batch failing which degree will not be awarded to such student.
            </p>
            <p><b>•	I have found that my attendance record at CU Online is not as per my actual attendance. How can this discrepancy be removed?</b><br />
             Immediately contact your teacher and reconcile your attendance status with him and request for a correction, if found. Keep in mind that once the short attendance list is notified on the last teaching day, it is final and no correction can be made thereof.
            </p>
             <p><b>•	I am attending a class while my name is not in the list of attendance sheet of teacher?</b><br />
             Either you are attending classes with a wrong section or you are not registered in this course. Report immediately to your Head of Department or at the Student Services Center to get the course registered within the add/drop period.
            </p>
        </div>
    </div>
</div>
</asp:Content>

