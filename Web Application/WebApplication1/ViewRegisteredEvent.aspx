<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="ViewRegisteredEvent.aspx.cs" Inherits="WebApplication1.ViewRegisteredEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2 class="text-decoration-underline"><strong>List of Registered Events</strong></h2>
    <br />
    <h3>Upcoming Events</h3>
    <p>
        <asp:GridView ID="gv_UpcomingEvents" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="22px" Width="936px" OnSelectedIndexChanged="gv_UpcomingEvents_SelectedIndexChanged" OnRowDeleting="gv_UpcomingEvents_RowDeleting" CssClass="auto-style1" ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="eventId" HeaderText="Event ID" />
                <asp:BoundField DataField="eventTitle" HeaderText="Event Title" />
                <asp:BoundField DataField="startDate" DataFormatString="{0:d}" HeaderText="Start Date" ApplyFormatInEditMode="True" />
                <asp:BoundField DataField="endDate" DataFormatString="{0:d}" HeaderText="End Date" ApplyFormatInEditMode="True" />
                <asp:BoundField DataField="custPax" HeaderText="Pax" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="Cancel Registration" OnClientClick="return confirm('Are you sure you want to delete this registration?');"/>
                    </ItemTemplate>
                </asp:TemplateField>
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
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <h3>Past Events</h3>
        <asp:GridView ID="gv_PastEvents" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="22px" Width="936px" OnSelectedIndexChanged="gv_PastEvents_SelectedIndexChanged" ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="eventId" HeaderText="Event ID" />
                <asp:BoundField DataField="eventTitle" HeaderText="Event Title" />
                <asp:BoundField DataField="startDate" DataFormatString="{0:d}" HeaderText="Start Date" />
                <asp:BoundField DataField="endDate" DataFormatString="{0:d}" HeaderText="End Date" />
                <asp:BoundField DataField="custPax" HeaderText="Pax" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
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
    <br />
    <br />
</asp:Content>
