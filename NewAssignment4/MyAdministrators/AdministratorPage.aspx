﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministratorPage.aspx.cs" Inherits="NewAssignment4.MyAdministrators.AdministratorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Hi, "></asp:Label>
        <asp:LoginName ID="LoginName1" runat="server" />
        <br />
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="height: 21px; width: 78px">&nbsp;</td>
                <td style="height: 21px; width: 386px">
                    <asp:GridView ID="memberGridView" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Caption="Members" CellPadding="4" ForeColor="Black" GridLines="Horizontal" style="margin-left: 0px">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 78px; height: 25px"></td>
                <td style="height: 25px; width: 386px"></td>
            </tr>
            <tr>
                <td style="width: 78px; height: 216px;"></td>
                <td style="width: 386px; height: 216px;">
                    <asp:GridView ID="instructorGridView" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Caption="Instructors" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 78px; height: 23px;"></td>
                <td style="width: 386px; height: 23px;">
                </td>
            </tr>
            <tr>
                <td style="width: 78px; height: 257px"></td>
                <td style="height: 257px; width: 386px">
                    <asp:Label ID="Label2" runat="server" Text="First Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtMemberFirstName" runat="server" Width="160px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Last Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtMemberLastName" runat="server" Width="160px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Phone Number:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtMemberPhoneNumber" runat="server" Width="160px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtMemberEmail" runat="server" Width="160px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="User Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtMemberUserName" runat="server" Width="160px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtMemberPassword" runat="server" Width="160px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnAddMember" runat="server" OnClick="btnAddMember_Click" Text="Add Member" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnDeleteMember" runat="server" OnClick="btnDeleteMember_Click" Text="Delete Member" />
                    <br />
                    <asp:Label ID="lblDeletedMember" runat="server"></asp:Label>
                    </td>
                <td style="height: 257px">
                    <asp:Label ID="Label9" runat="server" Text="First Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtInstructorFirstName" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Last Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtInstructorLastName" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Phone Number:"></asp:Label>
&nbsp;&nbsp;
                    <asp:TextBox ID="txtInstructorPhoneNumber" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="User Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtInstructorUserName" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtInstructorPassword" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnAddInstructor" runat="server" OnClick="btnAddInstructor_Click" Text="Add Instructor" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnDeleteInstructor" runat="server" OnClick="btnDeleteInstructor_Click" Text="Delete Instructor" />
                    <br />
                    <asp:Label ID="lblDeletedInstructor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 78px; height: 262px"></td>
                <td style="height: 262px; width: 386px">
                    <asp:Label ID="Label14" runat="server" Text="Section Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="sectionDropDown" runat="server" OnSelectedIndexChanged="sectionDropDown_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>Karate Age-Uke</asp:ListItem>
                        <asp:ListItem>Karate Chudan-Uke</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="Member First Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtMember" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="Instructor First Name:"></asp:Label>
&nbsp;&nbsp;
                    <asp:TextBox ID="txtInstructor" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label18" runat="server" Text="Section Price:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSectionPrice" runat="server" Text="$500"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnAddSection" runat="server" OnClick="btnAddSection_Click" Text="Add Section" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSectionCreation" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td style="width: 78px; height: 105px">&nbsp;</td>
                <td style="height: 105px; width: 386px">
                    &nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>
