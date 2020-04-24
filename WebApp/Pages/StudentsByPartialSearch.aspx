<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsByPartialSearch.aspx.cs" Inherits="WebApp.Pages.StudentsByPartialSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Students by Partial Search</h1>
    <br />
    <div>
        <asp:DataList ID="Message" runat="server" Enabled="False">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
        </asp:DataList>
        
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>&nbsp;&nbsp
        <asp:TextBox ID="StudentName" runat="server"></asp:TextBox>&nbsp;&nbsp
        <asp:Button ID="SearchStudent" runat="server" Text="Students?"
            OnClick="Search_Click" />
        <br />
        <br />
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        <br />
        <asp:GridView ID="StudentGridView" runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-striped" GridLines="Horizontal"
            BorderStyle="None" AllowPaging="True"
            OnPageIndexChanging="StudentGridView_PageIndexChanging" PageSize="5"
            OnSelectedIndexChanged="StudentGridView_SelectedIndexChanged">

            <Columns>
                <asp:CommandField SelectText="Select" ShowSelectButton="True" 
                    ButtonType="Button" CausesValidation="false">
                </asp:CommandField>
                <asp:TemplateField HeaderText="Student Number" Visible="True">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="StudentNumber" runat="server" 
                            Text='<%# Eval("StudentNumber") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" Visible="True">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="FullName" runat="server" 
                            Text='<%# Eval("FullName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="BirthDate">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="BirthDate" runat="server" 
                            Text='<%# DateTime.Parse(Eval("BirthDate").ToString()).ToString("MM-dd-yyyy") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
            <EmptyDataTemplate>
                No data to display
            </EmptyDataTemplate>
            <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="3" />
        </asp:GridView>
    </div>
</asp:Content>