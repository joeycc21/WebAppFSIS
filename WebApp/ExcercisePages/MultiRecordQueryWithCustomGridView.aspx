<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiRecordQueryWithCustomGridView.aspx.cs" Inherits="WebApp.Pages.MultiRecordQueryWithCustomGridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1> Multi Record Query Dropdown to Custom GridView (Ex06)</h1>
    <div class="offset-2">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Teams "></asp:Label>&nbsp;&nbsp;   
        <asp:DropDownList ID="List01" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Fetch" runat="server" Text="Search" CausesValidation="false" OnClick="Fetch_Click"/>&nbsp;&nbsp;
         <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        <br />
        <br />
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="CoachLabel01" runat="server" ></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:Label ID="CoachLabel02" runat="server" ></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="AssistantCoachLabel01" runat="server" ></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:Label ID="AssistantCoachLabel02" runat="server" ></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="WinsLabel01" runat="server" ></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:Label ID="WinsLabel02" runat="server" ></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="LossesLabel01" runat="server" ></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:Label ID="LossesLabel02" runat="server" ></asp:Label>
        </div>
    </div>   
    <br />
    <div>
        <div class="col-md-12 text-center" style="padding: 10px 0px">
            <h3>Team Roster</h3> 
        </div>
        <asp:GridView ID="List02" runat="server" 
            AutoGenerateColumns="False"
            CssClass="table table-striped" GridLines="Horizontal"
            BorderStyle="None" AllowPaging="True"
            OnPageIndexChanging="List02_PageIndexChanging" PageSize="5">

            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="PlayerID" runat="server" 
                            Text='<%# Eval("PlayerID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="Name" runat="server" 
                            Text='<%# Eval("PlayerName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="Age" runat="server" 
                            Text='<%# Eval("Age") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="Gender" runat="server" 
                            Text='<%# Convert.ToString(Eval("Gender")) == "M" ? "Male" : "Female" %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Med Alert">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="MedicalAlertDetails" runat="server" 
                            Text='<%# Eval("MedicalAlertDetails") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
            <EmptyDataTemplate>
                No data available at this time.
            </EmptyDataTemplate>
            <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="3" />
        </asp:GridView>
    </div>
</asp:Content>