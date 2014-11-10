<%@ Page Title="" Language="C#" MasterPageFile="~/QuantumForce.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="QuantumForce.Site.Transactions" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="height: 55px" class=" wrapper">
        <br />
        <h3>
            <label>Amount Available:</label></h3>
        <h3>
            <label>Amount In Debt:</label><br />
            <br />
        </h3>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script type="text/javascript">
        function deleteConfirm(pubid) {
            var result = confirm('Do you want to delete Transaction ' + pubid + ' ?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <div class="wrapper">
        <table width="60%">
            <tr>
                <td align="right" width="60%">&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvTransactions" DataKeyNames="ID" runat="server"
            AutoGenerateColumns="False" ShowFooter="True" HeaderStyle-Font-Bold="true"
            OnRowCancelingEdit="gvTransactions_RowCancelingEdit"
            OnRowDeleting="gvTransactions_RowDeleting"
            OnRowEditing="gvTransactions_RowEditing"
            OnRowUpdating="gvTransactions_RowUpdating"
            OnRowCommand="gvTransactions_RowCommand"
            OnRowDataBound="gvTransactions_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Transaction ID" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="ID" runat="server" Width="40px" Text='<%#Eval("ID") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblID" runat="server" Width="40px" Text='<%#Eval("ID") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Width="150px" Text='<%#Eval("Category") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="txtCategory" Width="150px" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="inCategory" Width="150px" runat="server" />
                        <!--<asp:RequiredFieldValidator ID="vCategory" runat="server" ControlToValidate="inCategory" Text="?" ValidationGroup="validaiton"/>-->
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Width="350px" Text='<%#Eval("Description") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDescription" Width="350px" runat="server" Text='<%#Eval("Description") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="inDescription" Width="350px" runat="server" />
                        <asp:RequiredFieldValidator ID="vDescription" runat="server" ControlToValidate="inDescription" Text="?" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblAmount" runat="server" Width="100px" Text='<%#Eval("Amount") %>' ItemStyle-HorizontalAlign="Right" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAmount" Width="100px" runat="server" Text='<%#Eval("Amount") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="inAmount" Width="100px" runat="server" />
                        <asp:RequiredFieldValidator ID="vAmount" runat="server" ControlToValidate="inAmount" Text="?" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="ButtonAdd" runat="server" CommandName="AddNew" Text="Add New Transaction" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

            <HeaderStyle Font-Bold="True" BackColor="#5D7B9D" ForeColor="White"></HeaderStyle>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

    </div>

    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <br />
</asp:Content>


<%--<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .wrapper {
            width: 100%;
            min-height: 100%;
            height: auto !important;
            height: 100%;
            margin: 0 auto -20px; /*the bottom margin is the negative value of the footer's height*/
        }

        .push {
            height: 20px; /*'.push' must be the same height as 'footer'*/
        }

        .footer {
            position: absolute;
            height: 20px;
            width: 99%;
            margin: auto;
            bottom: 0px;
            text-align: center;
        }
    </style>
</asp:Content>--%>





