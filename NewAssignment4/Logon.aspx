<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="NewAssignment4.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table style="width: 100%;">
            <tr>
                <td style="width: 274px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 274px">&nbsp;</td>
                <td>
                    <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Height="194px" Width="316px" OnAuthenticate="Login1_Authenticate">
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                        <TextBoxStyle Font-Size="0.8em" />
                        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                    </asp:Login>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 274px; height: 129px;"></td>
                <td style="height: 129px"></td>
                <td style="height: 129px"></td>
            </tr>
        </table>
    </p>
</asp:Content>
