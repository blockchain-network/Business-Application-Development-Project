<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="AdminViewEvents.aspx.cs" Inherits="WebApplication1.AdminViewEvents" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 107px;
            font-size: large;
        }
        .auto-style2 {
            font-size: large;
        }
        .auto-style12 {
            width: 175%;
            height: 66px;
        }
        .auto-style13 {
            height: 23px;
        }
        .auto-style14 {
            height: 23px;
            width: 170px;
        }
        .auto-style18 {
            width: 175%;
            height: 85px;
        }
        .auto-style23 {
            height: 49px;
        }
        .auto-style24 {
            height: 49px;
            width: 354px;
        }
        .auto-style25 {
            width: 354px;
        }
        .auto-style26 {
            height: 49px;
            width: 144px;
        }
        .auto-style28 {
            height: 49px;
            width: 170px;
        }
        .auto-style29 {
            width: 170px;
        }
        .auto-style30 {
            width: 144px;
        }
        .auto-style31 {
            height: 23px;
            width: 336px;
        }
        .auto-style33 {
            width: 336px;
            height: 55px;
        }
        .auto-style34 {
            height: 23px;
            width: 150px;
        }
        .auto-style35 {
            width: 150px;
            height: 55px;
        }
        .auto-style36 {
            height: 55px;
            width: 170px;
        }
        .auto-style37 {
            height: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>EVENTS OVERVIEW</h1>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <ajaxToolkit:BarChart ID="barChartEvent" runat="server" Height="322px" ValueAxisLines="11" Width="916px">
    </ajaxToolkit:BarChart>
    <p> &nbsp;&nbsp; </p>
    <p> &nbsp;&nbsp; </p>
    <p>&nbsp;</p>
<h3>
    <asp:Button ID="btn_AddNewEvent" runat="server" BackColor="#00CC66" BorderStyle="None" CssClass="rounded" ForeColor="White" OnClick="btn_AddNewEvent_Click" Text="Add New Event" Height="46px" Width="213px" />
    </h3>
    <p>
        &nbsp;</p>
    <h2>
        <strong>Upcoming Events</strong></h2>
    <table class="auto-style18">
        <tr>
            <td class="auto-style28">Search by Event Title:</td>
            <td class="auto-style24">
                    <asp:TextBox ID="tb_UpcomingSearch" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_SearchUpcoming" runat="server" OnClick="btn_SearchUpcoming_Click" Text="Search" />
                </td>
            <td class="auto-style26">
                    Filter by Category:</td>
            <td class="auto-style23">
                    <asp:DropDownList ID="ddl_CategoryUpcoming" runat="server">
                        <asp:ListItem>Fashion Show</asp:ListItem>
                        <asp:ListItem>Workshop</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;<asp:Button ID="btn_UpcomingFilter" runat="server" OnClick="btn_UpcomingFilter_Click" Text="Filter" />
                </td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style25"><asp:Button ID="btn_UpcomingFilterAll" runat="server" OnClick="btn_UpcomingFilterAll_Click" Text="Search All" />
&nbsp;<asp:Button ID="btn_UpcomingReset" runat="server" OnClick="btn_UpcomingReset_Click" Text="Clear" />
            </td>
            <td class="auto-style30">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="gv_UpcomingEvents" runat="server" Height="16px" Width="1260px" AutoGenerateColumns="False" CssClass="auto-style1" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="gv_UpcomingEvents_SelectedIndexChanged" DataKeyNames="eventId" OnRowCancelingEdit="gv_UpcomingEvents_RowCancelingEdit" OnRowDeleting="gv_UpcomingEvents_RowDeleting" OnRowEditing="gv_UpcomingEvents_RowEditing" OnRowUpdating="gv_UpcomingEvents_RowUpdating" ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="eventId" HeaderText="Event ID" ReadOnly="True" />
            <asp:BoundField DataField="eventTitle" HeaderText="Event Title" />
            <asp:BoundField DataField="startDate" HeaderText="Start Date" DataFormatString="{0:d}" ApplyFormatInEditMode="True" ReadOnly="True" />
            <asp:BoundField DataField="endDate" HeaderText="End Date" DataFormatString="{0:d}" ApplyFormatInEditMode="True" ReadOnly="True" />
            <asp:BoundField DataField="category" HeaderText="Category" ReadOnly="True" />
            <asp:BoundField DataField="location" HeaderText="Location" />
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            <asp:CommandField ButtonType="Button" EditText="Update" ShowEditButton="True" />
            
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this event?');"/>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
<h2>&nbsp;</h2>
    <h2><strong>Past Events</strong></h2>
    <table class="auto-style12">
        <tr>
            <td class="auto-style14">Search by Event Title:</td>
            <td class="auto-style31">
                    <asp:TextBox ID="tb_PastSearch" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_SearchPast" runat="server" Text="Search" OnClick="btn_SearchPast_Click" />
            </td>
            <td class="auto-style34">
                    Filter by Category:</td>
            <td class="auto-style13">
                    <asp:DropDownList ID="ddl_CategoryPast" runat="server">
                        <asp:ListItem>Fashion Show</asp:ListItem>
                        <asp:ListItem Value="Workshop">Workshop</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;<asp:Button ID="btn_PastFilter" runat="server" Text="Filter" OnClick="btn_PastFilter_Click"/>
            </td>
        </tr>
        <tr>
            <td class="auto-style36"></td>
            <td class="auto-style33">
                <asp:Button ID="btn_PastFilterAll" runat="server" Text="Search All" OnClick="btn_PastFilterAll_Click" />
&nbsp;<asp:Button ID="btn_PastReset" runat="server" Text="Clear" OnClick="btn_PastReset_Click" />
            </td>
            <td class="auto-style35">
                </td>
            <td class="auto-style37">
                </td>
        </tr>
    </table>

    <p>&nbsp;</p>
    <asp:GridView ID="gv_PastEvents" runat="server" Height="16px" Width="1260px" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style2" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="gv_PastEvents_SelectedIndexChanged" ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
    <Columns>
        <asp:BoundField DataField="eventId" HeaderText="Event ID" />
        <asp:BoundField DataField="eventTitle" HeaderText="Event Title" />
        <asp:BoundField DataField="startDate" HeaderText="Start Date" DataFormatString="{0:d}" />
        <asp:BoundField DataField="endDate" HeaderText="End Date" DataFormatString="{0:d}" />
        <asp:BoundField DataField="category" HeaderText="Category" />
        <asp:BoundField DataField="location" HeaderText="Location" />
        <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
    </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <br />
    <br />
    <br />
</asp:Content>
