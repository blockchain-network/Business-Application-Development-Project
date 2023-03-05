<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="AdminEventDetails.aspx.cs" Inherits="WebApplication1.AdminEventDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 94%;
            height: 293px;
        }
        .auto-style2 {
            width: 504px;
        }
        .auto-style4 {
            width: 504px;
            height: 32px;
        }
        .auto-style5 {
            height: 32px;
        }
        .auto-style6 {
            width: 504px;
            height: 37px;
        }
        .auto-style7 {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Event Details for
        <asp:Label ID="lbl_Title" runat="server" Text="Label"></asp:Label>
    </h2>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Event Title:</td>
            <td>
                <asp:Label ID="lbl_eventTitle" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Event Description:</td>
            <td>
                <asp:Label ID="lbl_eventDescription" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Start Date:</td>
            <td class="auto-style7">
                <asp:Label ID="lbl_StartDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">End Date:</td>
            <td class="auto-style5">
                <asp:Label ID="lbl_EndDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Start Time:</td>
            <td>
                <asp:Label ID="lbl_StartTime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">End Time:</td>
            <td>
                <asp:Label ID="lbl_EndTime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Category:</td>
            <td class="auto-style5">
                <asp:Label ID="lbl_Category" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Location:</td>
            <td>
                <asp:Label ID="lbl_Location" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Total Pax:</td>
            <td>
                <asp:Label ID="lbl_Pax" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btn_RegistrationData" runat="server" BorderStyle="None" CssClass="rounded" Height="57px" Text="View Registration Data" Width="263px" OnClick="btn_RegistrationData_Click" BackColor="#00CC66" ForeColor="White" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="btn_Back" runat="server" BorderStyle="None" CssClass="rounded" Height="44px" Text="Back" Width="126px" OnClick="btn_Back_Click" />
    <br />
    <br />
    <br />
</asp:Content>
