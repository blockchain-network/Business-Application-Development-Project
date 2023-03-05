<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="CustomerTicketInformation.aspx.cs" Inherits="WebApplication1.CustomerTicketInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 55%;
            height: 159px;
        }
        .auto-style5 {
            width: 199px;
        }
        .auto-style6 {
            width: 340px;
            height: 27px;
            font-size: large;
        }
        .auto-style10 {
            width: 275px;
            height: 29px;
        }
        .auto-style11 {
            width: 275px;
            font-size: large;
        }
        .auto-style12 {
            width: 199px;
            font-size: large;
        }
        .auto-style13 {
            font-size: large;
        }
        .auto-style14 {
            width: 340px;
            height: 28px;
            font-size: large;
        }
        .auto-style17 {
            width: 340px;
            font-size: large;
            height: 29px;
        }
        .auto-style18 {
            height: 28px;
            width: 275px;
        }
        .auto-style19 {
            height: 27px;
            width: 275px;
        }
        .auto-style20 {
            width: 340px;
            font-size: large;
        }
        .auto-style21 {
            width: 199px;
            font-size: large;
            height: 27px;
        }
        .auto-style22 {
            width: 275px;
            font-size: large;
            height: 27px;
        }
        .auto-style23 {
            height: 24px;
        }
        .auto-style24 {
            width: 55%;
            height: 37px;
        }
        .auto-style25 {
            height: 24px;
            width: 283px;
        }
        .auto-style26 {
            width: 283px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ticket Information for
        <asp:Label ID="lbl_Title" runat="server" Text="Label"></asp:Label>
        <br />
    </h2>
    <table class="auto-style24">
        <tr>
            <td class="auto-style25">
                <asp:Image ID="QRcode" runat="server" CssClass="auto-style13" Height="155px" Width="150px" />
            </td>
            <td class="auto-style23"></td>
        </tr>
        <tr>
            <td class="auto-style26">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table class="auto-style1" id="table" runat="server">
        <tr>
            <td class="auto-style14">Event Title:</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_eventTitle" runat="server" Text="Label" CssClass="auto-style13"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style17">Name:</td>
            <td class="auto-style10">
                <asp:Label ID="lbl_custFname" runat="server" Text="Label" CssClass="auto-style13"></asp:Label>
            &nbsp;<asp:Label ID="lbl_custLname" runat="server" Text="Label" CssClass="auto-style13"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">Number of Pax attending:</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_Pax" runat="server" Text="Label" CssClass="auto-style13"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Date:</td>
            <td class="auto-style19">
                <asp:Label ID="lbl_StartDate" runat="server" Text="Label"></asp:Label>
&nbsp;-
                <asp:Label ID="lbl_EndDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Time:</td>
            <td class="auto-style19">
                <asp:Label ID="lbl_StartTime" runat="server" Text="Label"></asp:Label>
&nbsp;-
                <asp:Label ID="lbl_EndTime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style20">Location:</td>
            <td class="auto-style11">
                <asp:Label ID="lbl_Location1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style22">
                <asp:Label ID="lbl_Location" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btn_Export" runat="server" BorderStyle="None" Height="45px" OnClick="btn_Export_Click" Text="Export Ticket Information" Width="251px" />
    <br />
    <br />
    <br />
    <asp:Button ID="btn_Back" runat="server" BorderStyle="None" Height="45px" OnClick="btn_Back_Click" Text="Return to Home Page" Width="251px" />
    <br />
    <br />
    <br />
</asp:Content>
