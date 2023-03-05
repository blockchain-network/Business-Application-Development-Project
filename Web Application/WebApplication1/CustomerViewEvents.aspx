<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="CustomerViewEvents.aspx.cs" Inherits="WebApplication1.CustomerViewEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 84%;
            height: 81px;
        }
        .auto-style2 {
            width: 264px;
        }
        .auto-style3 {
            width: 175px;
        }
        .auto-style4 {
            width: 332px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Welcome to Olivia Events.</h2>
    <p>&nbsp;</p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Search by Event Title:</td>
            <td class="auto-style4">
                <asp:TextBox ID="tb_Search" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_Search" runat="server" OnClick="btn_Search_Click" Text="Search" />
            </td>
            <td class="auto-style3">
                Filter by Category:</td>
            <td>
                <asp:DropDownList ID="ddl_Category" runat="server">
                    <asp:ListItem>Fashion Show</asp:ListItem>
                    <asp:ListItem>Workshop</asp:ListItem>
                </asp:DropDownList>
&nbsp;<asp:Button ID="btn_Filter" runat="server" OnClick="btn_Filter_Click" Text="Filter" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4">
                <asp:Button ID="btn_SearchAll" runat="server" OnClick="btn_SearchAll_Click" Text="Search All" />
&nbsp;<asp:Button ID="btn_Reset" runat="server" OnClick="btn_Reset_Click" Text="Clear" />
            </td>
            <td class="auto-style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <asp:GridView ID="gv_UpcomingEvents" runat="server" Height="51px" Width="1097px" AutoGenerateColumns="False" CssClass="auto-style1" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gv_UpcomingEvents_SelectedIndexChanged" ShowHeaderWhenEmpty="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="eventId" HeaderText="Event ID" />
            <asp:BoundField DataField="eventTitle" HeaderText="Event Title" />
            <asp:BoundField DataField="startDate" HeaderText="Start Date" DataFormatString="{0:d}" />
            <asp:BoundField DataField="endDate" HeaderText="End Date" DataFormatString="{0:d}" />
            <asp:BoundField DataField="category" HeaderText="Category" />
            <asp:BoundField DataField="location" HeaderText="Location" />
            <asp:CommandField EditText="Update" ShowSelectButton="True" ButtonType="Button" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    <br />
</asp:Content>
