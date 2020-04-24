<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDPage.aspx.cs" Inherits="WebApp.Pages.CRUDPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <h1>Student Maintenance Page</h1>
    <br />
    <asp:DataList ID="Message" runat="server">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label1" runat="server" Text="Student Number"
                AssociatedControlID="StudentNumber">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="StudentNumber" runat="server" ReadOnly="true">
            </asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label2" runat="server" Text="First Name"
                AssociatedControlID="FirstName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label3" runat="server" Text="Last Name"
                AssociatedControlID="LastName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label4" runat="server" Text="Display Name"
                AssociatedControlID="DisplayName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="DisplayName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label5" runat="server" Text="Country"
                AssociatedControlID="CountryList">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:DropDownList ID="CountryList" runat="server" Width="300px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label6" runat="server" Text="Gender"
                AssociatedControlID="GenderList">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:DropDownList ID="GenderList" runat="server" Width="300px">
                <asp:ListItem Text="Select..." Value=""></asp:ListItem>
                <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                <asp:ListItem Text="Female" Value="F"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label7" runat="server" Text="Birthdate"
                AssociatedControlID="BirthDate">
            </asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:TextBox ID="BirthDate" CssClass="date" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-6 text-left">
            <asp:Button ID="BackButton" runat="server" Text="Back" CausesValidation="false" OnClick="Back_Click" />&nbsp;&nbsp;
            <asp:Button ID="ClearButton" runat="server" OnClick="Clear_Click" Text="Clear" CausesValidation="false" />&nbsp;&nbsp;
            <asp:Button ID="AddButton" runat="server" OnClick="Add_Click" Text="Add" />&nbsp;&nbsp;
            <asp:Button ID="UpdateButton" runat="server" OnClick="Update_Click" Text="Update" />&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" OnClick="Delete_Click" Text="Delete" />
        </div>
    </div>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        function CallFunction() {
            alert("Are you sure you wish to delete this item?");
        }
        $(function () {
            $('.date').datepicker({
                dateFormat: 'yy-mm-dd',
                changeMonth: true,
                changeYear: true
            });
            $('.date').attr('readonly', true);
        });

    </script>   
</asp:Content>
