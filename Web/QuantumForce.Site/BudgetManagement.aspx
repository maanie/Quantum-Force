<%@ Page Title="" Language="C#" MasterPageFile="~/QuantumForce.Master" AutoEventWireup="true" CodeBehind="BudgetManagement.aspx.cs" Inherits="QuantumForce.Site.BudgetManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Manage your Budgets</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <br />
    <asp:GridView ID="gvBudgets" runat="server" CssClass="table table-hover table-bordered table-responsive table-striped" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="User Budget ID">
                <ItemTemplate>
                    <asp:Label ID="userBudgetId" runat="server" Text='<%#Eval("UserBudgetID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Budget Name">
                <ItemTemplate>
                    <asp:Label ID="budgetName" runat="server" Text='<%#Eval("BudgetName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="editButton" runat="server" CssClass="btn btn-default" Text="Edit" ToolTip='<%#Eval("BudgetID") %>' OnClick="editButton_Click" />
                    <asp:Button ID="deleteButton" runat="server" CssClass="btn btn-default" Text="Delete" ToolTip='<%#Eval("BudgetID") %>' OnClick="deleteButton_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />
    <asp:Button ID="CreateBudget" runat="server" Text="Create Budget" OnClick="CreateBudget_Click" CssClass="btn btn-default" />
</asp:Content>
