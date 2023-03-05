<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="AdminViewRegistrationData.aspx.cs" Inherits="WebApplication1.AdminViewRegistrationData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
        .auto-style2 {
            width: 56%;
            height: 37px;
        }
        .auto-style3 {
            height: 32px;
            width: 220px;
        }
        .auto-style4 {
            width: 92%;
            height: 165px;
        }
        .auto-style5 {
            width: 287px;
        }
        .auto-style6 {
            width: 287px;
            height: 32px;
        }
        .auto-style7 {
            margin-left: 95;
        }
        .auto-style8 {
            width: 588px;
        }
        .auto-style9 {
            height: 32px;
            width: 588px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="mt-0">
        Registration Data for
        <asp:Label ID="lbl_event" runat="server" Text="Label"></asp:Label>
    </p>
    <table class="auto-style2">
        <tr>
            <td class="auto-style3">Total Pax:</td>
            <td class="auto-style1">
                <asp:Label ID="lbl_CurrentPax" runat="server" Text="Label"></asp:Label>
                /<asp:Label ID="lbl_EventPax" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table class="auto-style4">
        <tr>
            <td class="auto-style5">Filter by Customer ID</td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddl_custID" runat="server" CssClass="auto-style7">
                </asp:DropDownList>
            &nbsp;<asp:Button ID="btn_Filter" runat="server" Text="Filter by Customer ID" OnClick="btn_Filter_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Search by First Name:</td>
            <td class="auto-style9">
                <asp:TextBox ID="tb_firstName" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="btn_SearchFirstName" runat="server" OnClick="btn_SearchFirstName_Click" Text="Search by First Name" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Search by Last Name:</td>
            <td class="auto-style8">
                <asp:TextBox ID="tb_lastName" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="btn_SearchLastName" runat="server" OnClick="btn_SearchLastName_Click" Text="Search by Last Name" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style8">
                <asp:Button ID="btn_Reset" runat="server" OnClick="btn_Reset_Click" style="height: 42px" Text="Clear" />
            </td>
        </tr>
    </table>
    <br />
    <p class="mt-0">
        <asp:GridView ID="gv_RegistrationDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="33px" Width="735px" ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="custID" HeaderText="Customer ID" />
                <asp:BoundField DataField="custFname" HeaderText="Customer First Name" />
                <asp:BoundField DataField="custLname" HeaderText="Customer Last Name" />
                <asp:BoundField DataField="pax" HeaderText="Number of Pax" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </p>
    <p class="mt-0">
        &nbsp;</p>
    <p class="mt-0">
        <asp:Button ID="btn_Export" runat="server" BorderStyle="None" CssClass="rounded" Height="51px" OnClick="btn_Export_Click" Text="Export" Width="120px" BackColor="#00CC66" ForeColor="White" />
    </p>
    <p class="mt-0">
        &nbsp;</p>
<p class="mt-0">
    <asp:Button ID="btn_Back" runat="server" BorderStyle="None" CssClass="rounded" Height="44px" Text="Back" Width="126px" OnClick="btn_Back_Click" />
    </p>
    <p class="mt-0">
        &nbsp;</p>
</asp:Content>
