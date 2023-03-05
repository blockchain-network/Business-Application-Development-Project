<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="AdminAddNewEvents.aspx.cs" Inherits="WebApplication1.AdminAddNewEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style10 {
            width: 100%;
            margin-right: 0px;
        }
        .auto-style11 {
            font-size: medium;
        }
        .auto-style12 {
            width: 390px;
        }
        .auto-style13 {
            width: 414px;
        }
        .auto-style16 {
            font-size: 12pt;
        }
        .auto-style18 {
            width: 249px;
            font-size: large;
        }
        .auto-style19 {
            font-size: large;
        }
        .auto-style20 {
            width: 508px;
        }
        .auto-style21 {
            width: 391px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add New Events</h1>
    <h3>
        &nbsp;</h3>
    <p>
        &nbsp;</p>
    <table class="auto-style10">
        <tr>
            <td class="auto-style21">
                <p class="auto-style19">
                    Event Title</p>
            </td>
            <td class="auto-style20">
                <p>
                    <asp:TextBox ID="tb_EventTitle" runat="server"></asp:TextBox>
                </p>
            </td>
            <td>
                <p>
                    <asp:RequiredFieldValidator ID="rfv_EventTitle" runat="server" ControlToValidate="tb_EventTitle" ErrorMessage="Please enter title for event." ForeColor="Red" CssClass="auto-style11"></asp:RequiredFieldValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <p class="auto-style18">
                    Event Description</p>
            </td>
            <td class="auto-style20">
                <p>
                    <asp:TextBox ID="tb_EventDescription" runat="server" Height="95px" Width="351px" TextMode="MultiLine"></asp:TextBox>
                </p>
            </td>
            <td>
                <p>
                    <asp:RequiredFieldValidator ID="rfv_EventDescription" runat="server" ControlToValidate="tb_EventDescription" ErrorMessage="Please enter description for event." ForeColor="Red" CssClass="auto-style11"></asp:RequiredFieldValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <p class="auto-style19">
                    Start Date</p>
            </td>
            <td class="auto-style20">
                <p>
                    <asp:TextBox ID="tb_StartDate" runat="server" TextMode="Date" AutoPostBack="True" ></asp:TextBox>
                </p>
            </td>
            <td>
                <p class="auto-style12">
                    <asp:RequiredFieldValidator ID="rfv_StartDate" runat="server" ControlToValidate="tb_StartDate" ErrorMessage="Please enter the start date for the event." ForeColor="Red" CssClass="auto-style11"></asp:RequiredFieldValidator>
                </p>
                <p class="auto-style12">
                    <asp:CustomValidator ID="cv_StartDate" runat="server" ControlToValidate="tb_StartDate" CssClass="auto-style11" ErrorMessage="Please ensure that the start date must be greater than today's date." ForeColor="Red" OnServerValidate="cv_StartDate_ServerValidate" SetFocusOnError="True" ValidateEmptyText="True"></asp:CustomValidator>
                </p>
                <p class="auto-style12">
                    <asp:CompareValidator ID="comv_StartDate" runat="server" ControlToValidate="tb_StartDate" CssClass="auto-style11" ErrorMessage="Please enter a valid date format" ForeColor="Red" Type="Date" Operator="DataTypeCheck"></asp:CompareValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <p class="auto-style19">
                    End Date</p>
            </td>
            <td class="auto-style20">
                <p>
                    <asp:TextBox ID="tb_EndDate" runat="server" CssClass="auto-style16" TextMode="Date"></asp:TextBox>
                </p>
            </td>
            <td>
                <p>
                    <asp:RequiredFieldValidator ID="rfv_EndDate" runat="server" ControlToValidate="tb_EndTime" ErrorMessage="Please enter the end date for the event." ForeColor="Red" CssClass="auto-style11"></asp:RequiredFieldValidator>
                &nbsp;</p>
                <p>
                    <asp:CompareValidator ID="cv_Date" runat="server" ControlToCompare="tb_StartDate" ControlToValidate="tb_EndDate" ErrorMessage="Please ensure that the end date must be more than or equals to the start date." ForeColor="Red" Operator="GreaterThanEqual" CssClass="auto-style11"></asp:CompareValidator>
                </p>
                <p>
                    <asp:CompareValidator ID="comv_EndDate" runat="server" ControlToValidate="tb_EndDate" ErrorMessage="Please enter a valid date format" ForeColor="Red" Type="Date" Operator="DataTypeCheck"></asp:CompareValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <p class="auto-style19">
                    Start Time</p>
            </td>
            <td class="auto-style20">
                <p>
                    <asp:TextBox ID="tb_StartTime" runat="server" TextMode="Time"></asp:TextBox>
                </p>
            </td>
            <td>
                <p class="auto-style13">
                    <asp:RequiredFieldValidator ID="rfv_StartTime" runat="server" ControlToValidate="tb_StartTime" ErrorMessage="Please enter the start time for the event." ForeColor="Red" CssClass="auto-style11"></asp:RequiredFieldValidator>
                </p>
                <p class="auto-style13">
                    <asp:RegularExpressionValidator ID="reg_StartTime" runat="server" ControlToValidate="tb_StartTime" ErrorMessage="Please enter a valid time." ForeColor="Red" ValidationExpression="([01]?[0-9]|2[0-3]):[0-5][0-9]"></asp:RegularExpressionValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <p class="auto-style19">
                    End Time</p>
            </td>
            <td class="auto-style20">
                <p>
                    <asp:TextBox ID="tb_EndTime" runat="server" CssClass="auto-style16" TextMode="Time" AutoPostBack="True"></asp:TextBox>
                </p>
            </td>
            <td>
                <p>
                    <asp:RequiredFieldValidator ID="rfv_EndTime" runat="server" ControlToValidate="tb_EndTime" ErrorMessage="Please enter the end time for the event." ForeColor="Red" CssClass="auto-style11"></asp:RequiredFieldValidator>
                &nbsp;</p>
                <p>
                    <asp:RegularExpressionValidator ID="reg_EndTime" runat="server" ControlToValidate="tb_EndTime" ErrorMessage="Please enter a valid time." ForeColor="Red" ValidationExpression="([01]?[0-9]|2[0-3]):[0-5][0-9]"></asp:RegularExpressionValidator>
                </p>
                <p>
                    <asp:CustomValidator ID="cv_Time" runat="server" ControlToValidate="tb_EndTime" ErrorMessage="Please make sure that the end time is more than the start time for a one day event." ForeColor="Red" OnServerValidate="cv_Time_ServerValidate" ValidateEmptyText="True" CssClass="auto-style11"></asp:CustomValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <p class="auto-style19">
                    Location</p>
            </td>
            <td class="auto-style20">
                <p>
                    <asp:TextBox ID="tb_Location" runat="server" CssClass="auto-style16"></asp:TextBox>
                    <asp:Button ID="btn_Search" runat="server" OnClick="btn_Search_Click" Text="Search" CssClass="auto-style16" CausesValidation="false" />
                </p>
            </td>
            <td>
                <p>
                    <asp:RequiredFieldValidator ID="rfv_Location" runat="server" ControlToValidate="tb_Location" ErrorMessage="Please enter the location for the event." ForeColor="Red" CssClass="auto-style11"></asp:RequiredFieldValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                &nbsp;</td>
            <td class="auto-style20">
                    <asp:Label ID="lbl_Location" runat="server" Text="Label" CssClass="auto-style11"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">
                <p class="auto-style19">
                    Image</p>
            </td>
            <td class="auto-style20">
                <p>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </p>
            </td>
            <td>
                <p>
                    <asp:RequiredFieldValidator ID="rfv_Image" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please insert an image for the event." ForeColor="Red" CssClass="auto-style11"></asp:RequiredFieldValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <p class="auto-style19">
                    Category</p>
            </td>
            <td class="auto-style20">
                <p>
                    <asp:DropDownList ID="ddl_Category" runat="server">
                        <asp:ListItem>Fashion Show</asp:ListItem>
                        <asp:ListItem>Workshop</asp:ListItem>
                    </asp:DropDownList>
                </p>
            </td>
            <td>
                <p>
                    <asp:RequiredFieldValidator ID="rfv_Category" runat="server" ControlToValidate="ddl_Category" ErrorMessage="Please select the category for the event." ForeColor="Red" CssClass="auto-style11"></asp:RequiredFieldValidator>
                </p>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <p class="auto-style19">
                    Pax</p>
            </td>
            <td class="auto-style20">
                <p>
                    <asp:TextBox ID="tb_Pax" runat="server" TextMode="Number"></asp:TextBox>
                </p>
            </td>
            <td>
                <p>
                    <asp:RequiredFieldValidator ID="rfv_Pax" runat="server" ControlToValidate="tb_Pax" ErrorMessage="Please enter a numeric number for the number of pax for the event" ForeColor="Red" CssClass="auto-style11"></asp:RequiredFieldValidator>
                </p>
            </td>
        </tr>
    </table>
    <br />
    <h3>
        <asp:Button ID="btn_CreateEvent" runat="server" CssClass="rounded" Text="Insert" OnClick="btn_CreateEvent_Click" BackColor="#CCCCCC" BorderStyle="None" Height="46px" Width="218px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Back" runat="server" CssClass="rounded" OnClick="btn_Back_Click" Text="Cancel" CausesValidation="false" BackColor="#CCCCCC" BorderStyle="None" EnableTheming="True" Height="46px" Width="103px" />
    </h3>
    <p>
        &nbsp;</p>
    <p>
        Validation Error Message:</p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" />
</asp:Content>
