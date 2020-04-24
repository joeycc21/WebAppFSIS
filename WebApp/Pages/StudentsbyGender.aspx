<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsByGender.aspx.cs" Inherits="WebApp.Pages.StudentsByGender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Students by Gender</h1>
    <div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Select Gender"></asp:Label>&nbsp;&nbsp;   
         <asp:DropDownList ID="GenderList" runat="server" Width="300px">
             <asp:ListItem Text="Select..." Value=""></asp:ListItem>
             <asp:ListItem Text="Male" Value="M"></asp:ListItem>
             <asp:ListItem Text="Female" Value="F"></asp:ListItem>
         </asp:DropDownList>&nbsp;&nbsp;   
        <asp:Button ID="Fetch" runat="server" Text="Search" CausesValidation="false" OnClick="Search_Click" />&nbsp;&nbsp;
         <asp:Label ID="MessageLabel" runat="server"></asp:Label>
        <br />
        <br />
    </div>
    <br />
    <div>

        <asp:GridView ID="StudentGridView" runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-striped" GridLines="Horizontal"
            BorderStyle="None" AllowPaging="True"
            OnPageIndexChanging="StudentGridView_PageIndexChanging" PageSize="15">

            <Columns>
                <asp:BoundField DataField="StudentNumber" HeaderText="Student Number" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="DisplayName" HeaderText="Display Name" />
                <asp:TemplateField HeaderText="Country" SortExpression="Gender">
                    <ItemTemplate>
                        <asp:DropDownList ID="CountryList" runat="server"
                            DataSourceID="DSCountry" DataTextField="CountryName" DataValueField="CountryCode"
                            SelectedValue='<%# Bind("CountryCode") %>'>
                        </asp:DropDownList>
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
                No data available at this time.
            </EmptyDataTemplate>
            <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="10" />
        </asp:GridView>

        <asp:ObjectDataSource ID="DSStudents" runat="server"
            SelectMethod="StudentList"
            TypeName="WebApp.Pages.StudentsByGender">
            <SelectParameters>
                <asp:ControlParameter Name="gender" ControlID="GenderList" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="DSCountry" runat="server"
            SelectMethod="CountryList"
            TypeName="WebApp.Pages.StudentsByGender">
            <SelectParameters>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
