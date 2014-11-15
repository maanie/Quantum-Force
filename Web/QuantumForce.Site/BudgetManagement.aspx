<%@ Page Title="" Language="C#" MasterPageFile="~/QuantumForce.Master" AutoEventWireup="true" CodeBehind="BudgetManagement.aspx.cs" Inherits="QuantumForce.Site.BudgetManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Manage your Budgets</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <br />
    <asp:GridView ID="gvBudgets" runat="server"  CssClass="table table-hover table-bordered table-responsive table-striped">
    </asp:GridView>
</asp:Content>
