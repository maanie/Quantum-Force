<%@ Page Title="" Language="C#" MasterPageFile="~/QuantumForce.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="QuantumForce.Site.Transactions" %>
 
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="height: 55px" class =" wrapper">
        <BR/>
        <h3><label>Amount Available:</label></h3>
        <h3>
            <label>Amount In Debt:</label><BR/><BR/>
        </h3>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div class ="wrapper">
          <table width ="60%">
            <tr>
               <td align="right" width ="60%"> <asp:Button ID="btnAddTransaction" runat="server" Text="Add Transaction" Width="122px" OnClick="btnAddTransaction_Click" style="text-align: right" /></td></tr>
        </table>
      
            <BR/><asp:GridView ID="gvTransactions" runat="server" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" ShowFooter="True" Width="60%" EmptyDataText="- No Transactions available-" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnRowCancelingEdit="gvTransactions_RowCancelingEdit" OnRowDeleting="gvTransactions_RowDeleting" OnRowEditing="gvTransactions_RowEditing" OnRowUpdating="gvTransactions_RowUpdating">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <EmptyDataTemplate>
                <div class="auto-style2">
                    <b>- No Transactions Available! -</b></div>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlCategory" runat="server" Width ="100px">
                            <asp:ListItem>Shopping</asp:ListItem>
                            <asp:ListItem>Transport</asp:ListItem>
                            <asp:ListItem>Bills and Utilies</asp:ListItem>
                            <asp:ListItem>Food</asp:ListItem>
                            <asp:ListItem>Entertainment</asp:ListItem>
                            <asp:ListItem>Home</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left" Width="80px"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Description">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" ></asp:TextBox>
                    </ItemTemplate>
                    <ControlStyle Width="600px" />

<HeaderStyle HorizontalAlign="Left" Width="600px"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Amount">
                    <ItemTemplate>
                        <asp:TextBox ID="txtAmount" runat="server" ></asp:TextBox>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left" Width="80px"></HeaderStyle>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
         </Columns>

        </asp:GridView><BR/>
      
    </div>
</asp:Content>


<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }

        .wrapper 
{
    width: 100%;
    min-height: 100%;
    height: auto !important;
    height: 100%;
    margin: 0 auto -20px;  /*the bottom margin is the negative value of the footer's height*/
}
.push
{
    height: 20px;  /*'.push' must be the same height as 'footer'*/
}
.footer
{ 
    position: absolute;
    height: 20px;
    width: 99%;
    margin: auto;
    bottom: 0px;
    text-align: center;
}
    </style>
</asp:Content>





