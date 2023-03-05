<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="CustomerRegisterEvent.aspx.cs" Inherits="WebApplication1.CustomerRegisterEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 85%;
            height: 336px;
        }
        .auto-style2 {
            width: 225px;
        }
        .auto-style4 {
            width: 149px;
            height: 26px;
        }
        .auto-style5 {
            height: 26px;
        }
        .auto-style7 {
            height: 26px;
            width: 293px;
        }
        .auto-style8 {
            text-align: right;
            width: 293px;
        }
        .auto-style9 {
            text-align: left;
            width: 293px;
        }
        .auto-style11 {
            width: 149px;
        }
        .auto-style12 {
            width: 293px;
        }
        .auto-style13 {
            width: 225px;
            height: 49px;
        }
        .auto-style14 {
            width: 149px;
            height: 49px;
        }
        .auto-style15 {
            width: 293px;
            height: 49px;
        }
        .auto-style16 {
            height: 49px;
        }
        .auto-style17 {
            margin-right: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Register for
        <asp:Label ID="lbl_Title" runat="server" Text="Label"></asp:Label>
    </h2>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2" rowspan="8">
                <asp:ImageButton ID="Event_Img" runat="server" Height="336px" CssClass="auto-style17" Width="227px" />
            </td>
            <td class="auto-style11">Event Title:</td>
            <td class="auto-style12">
                <asp:Label ID="lbl_eventTitle" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">Event Description:</td>
            <td class="auto-style12">
                <asp:Label ID="lbl_eventDescription" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">Start Date:</td>
            <td class="auto-style12">
                <asp:Label ID="lbl_StartDate" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">End Date:</td>
            <td class="auto-style7">
                <asp:Label ID="lbl_EndDate" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style5">
            </td>
        </tr>
        <tr>
            <td class="auto-style11">Start Time:</td>
            <td class="auto-style12">
                <asp:Label ID="lbl_StartTime" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">End Time:</td>
            <td class="auto-style12">
                <asp:Label ID="lbl_EndTime" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">Category:</td>
            <td class="auto-style12">
                <asp:Label ID="lbl_Category" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">Location:</td>
            <td class="auto-style12">
                <asp:Label ID="lbl_Location" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">
                </td>
            <td class="auto-style14">Number of Pax:</td>
            <td class="auto-style15">
                <asp:TextBox ID="tb_Pax" runat="server" TextMode="Number">1</asp:TextBox>
            </td>
            <td class="auto-style16">
                <asp:RequiredFieldValidator ID="rfv_Pax" runat="server" ControlToValidate="tb_Pax" ErrorMessage="Please enter the number of pax attending this event" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator ID="cv_Pax" runat="server" ErrorMessage="Please enter a numeric number for the number of pax attending the event" ControlToValidate="tb_Pax" ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                <br />
                <asp:CustomValidator ID="custValid_Pax" runat="server" ControlToValidate="tb_Pax" ErrorMessage="Please lower the number of pax attending." ForeColor="Red" OnServerValidate="custValid_Pax_ServerValidate"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                &nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td class="text-end">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
    <asp:Button ID="btn_Back" runat="server" BorderStyle="None" CausesValidation="False" CssClass="rounded" Height="46px" OnClick="btn_Back_Click" Text="Back" Width="86px" />
            </td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style9">
                <asp:Button ID="btn_Register" runat="server" BackColor="#FF9933" BorderStyle="None" CssClass="rounded" ForeColor="White" Height="45px" Text="Register for this Event" Width="243px" OnClick="btn_Register_Click" />
            </td>
            <td class="text-start">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
</asp:Content>
