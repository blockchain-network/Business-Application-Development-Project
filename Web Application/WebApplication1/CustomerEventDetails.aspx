<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="CustomerEventDetails.aspx.cs" Inherits="WebApplication1.CustomerEventDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 211px;
            text-align: left;
        }
        .auto-style2 {
            width: 74%;
            height: 401px;
        }
        .auto-style3 {
            width: 181px;
        }
        .auto-style6 {
            height: 31px;
        }
        .auto-style8 {
            width: 181px;
            height: 24px;
        }
        .auto-style16 {
            width: 98px;
            height: 24px;
            color: #00FF00;
        }
        .auto-style17 {
            width: 98px;
            height: 24px;
        }
        .auto-style18 {
            width: 98px;
        }
        .auto-style21 {
            height: 24px;
            color: #00FF00;
        }
        .auto-style22 {
            width: 181px;
            text-align: left;
            height: 55px;
        }
        .auto-style23 {
            width: 98px;
            height: 55px;
        }
        .auto-style24 {
            width: 98px;
            height: 73px;
        }
        .auto-style25 {
            width: 181px;
            height: 73px;
        }
        .auto-style26 {
            width: 98px;
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Event Details for
        <asp:Label ID="lbl_Title" runat="server" Text="Label"></asp:Label>
    </h2>
    <table class="auto-style2">
        <tr>
            <td class="auto-style1" rowspan="8">
                <asp:ImageButton ID="Event_Img" runat="server" Height="341px" Width="227px" />
            </td>
            <td class="auto-style26">Event Title: </td>
            <td class="auto-style6">
                <asp:Label ID="lbl_eventTitle" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style23">Event Description:</td>
            <td class="auto-style22">
                <asp:Label ID="lbl_eventDescription" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style17">Start Date:</td>
            <td class="auto-style8">
                <asp:Label ID="lbl_StartDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style18">End Date:</td>
            <td class="auto-style3">
                <asp:Label ID="lbl_EndDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style18">Start Time:</td>
            <td class="auto-style3">
                <asp:Label ID="lbl_StartTime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style18">End Time:</td>
            <td class="auto-style3">
                <asp:Label ID="lbl_EndTime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style17">Category:</td>
            <td class="auto-style8">
                <asp:Label ID="lbl_Category" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style24">Location:</td>
            <td class="auto-style25">
                <asp:Label ID="lbl_Location" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style16">Event Vacancy:</td>
            <td class="auto-style8">
                <asp:Label ID="lbl_Vacancy" runat="server" ForeColor="Lime" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style21" colspan="2">
                <asp:Label ID="lbl_registrationStatus" runat="server" ForeColor="Red" Text="The registration is full" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
    <asp:Button ID="btn_Back" runat="server" BorderStyle="None" CssClass="rounded" Height="41px" Text="Back" Width="118px" OnClick="btn_Back_Click" />
            </td>
            <td class="auto-style17">
                &nbsp;</td>
            <td class="auto-style8">
    <asp:Button ID="btn_Register" runat="server" BackColor="#FF9900" BorderStyle="None" CssClass="rounded" ForeColor="White" Height="42px" Text="Register" Width="110px" OnClick="btn_Register_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style8">
    <asp:Button ID="btn_TicketInformation" runat="server" BackColor="#FF9900" BorderStyle="None" CssClass="rounded" ForeColor="White" Height="44px" Text="View Ticket Information" Width="217px" OnClick="btn_TicketInformation_Click"/>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
</asp:Content>
