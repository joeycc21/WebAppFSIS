<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="WebAppFSIS.ExercisePages.CRUD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Player CRUD Maintenance</h1>
    </div>

    <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server"
        ErrorMessage="First name is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
        ControlToValidate="FirstName"> </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredLastName" runat="server"
        ErrorMessage="Last name is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
        ControlToValidate="LastName"> </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredAge" runat="server"
        ErrorMessage="Age is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
        ControlToValidate="Age" Type="Integer" > </asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidatorAge" runat="server"
        ErrorMessage="Age must be between 6 and 14" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
        ControlToValidate="Age" MaximumValue="14" MinimumValue="6" Type="Integer"> </asp:RangeValidator>

    <asp:RequiredFieldValidator ID="RequiredAlbertaHealthCareNumber" runat="server" Display="None" ControlToValidate="AlbertaHealthCareNumber"
        ErrorMessage="Alberta health care number is required">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionAlbertaHealthCareNumber" runat="server" Display="None" ValidationExpression="^[1-9]{1}[0-9]{9}$" ControlToValidate="AlbertaHealthCareNumber"
        ErrorMessage="Alberta health care number must be 10 digit and first digit must start with 1-9"> </asp:RegularExpressionValidator>

    <%-- validation summary control--%>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
        HeaderText="Address the following concerns with your entered data." />

    <%--  this will be the lookup control area--%>
    <br />
    <div class="col-md-12">
        <asp:Label ID="Label0" runat="server" Text="Select a Player"></asp:Label>&nbsp;&nbsp;
             <asp:DropDownList ID="PlayerList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
             <asp:LinkButton ID="Search" runat="server" Font-Size="Large"
                 OnClick="Search_Click" CausesValidation="false">Search</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="Clear" runat="server" Font-Size="Large"
                 OnClick="Clear_Click" CausesValidation="false">Clear</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="AddPlayer" runat="server" Font-Size="Large"
                 OnClick="AddPlayer_Click">Add</asp:LinkButton>&nbsp;&nbsp;         
             <br /><br />
        <asp:DataList ID="Message" runat="server">
            <ItemTemplate>
                <%# Container.DataItem %>
            </ItemTemplate>
        </asp:DataList>
    </div>

    <%--  this will be the entity CRUD area--%>

    <div class="col-md-12">
        <fieldset class="form-horizontal">
            <legend>Player Information</legend>

            <%--each control group will consist of a label and the associated control--%>

            <asp:Label ID="Label1" runat="server" Text="Player ID"
                AssociatedControlID="PlayerID"></asp:Label>
            <asp:Label ID="PlayerID" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="First Name"
                AssociatedControlID="FirstName"></asp:Label>
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Last Name"
                AssociatedControlID="LastName"></asp:Label>
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Guardian"
                AssociatedControlID="GuardianList"></asp:Label>
            <asp:DropDownList ID="GuardianList" runat="server" Width="350px"></asp:DropDownList>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Team"
                AssociatedControlID="TeamList"></asp:Label>
            <asp:DropDownList ID="TeamList" runat="server" Width="350px"></asp:DropDownList>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Age"
                AssociatedControlID="Age"></asp:Label>
            <asp:TextBox ID="Age" runat="server" MaxLength="3"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Gender"
                AssociatedControlID="GenderList"></asp:Label>
            <asp:DropDownList ID="GenderList" runat="server" Width="350px">
                <asp:ListItem Text="Select..." Value=""></asp:ListItem>
                <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                <asp:ListItem Text="Female" Value="F"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Alberta Health Care Number"
                AssociatedControlID="AlbertaHealthCareNumber"></asp:Label>
            <asp:TextBox ID="AlbertaHealthCareNumber" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Medical Alert Details"
                AssociatedControlID="MedicalAlertDetails"></asp:Label>
            <asp:TextBox ID="MedicalAlertDetails" runat="server"></asp:TextBox>

        </fieldset>
    </div>

       
</asp:Content>
