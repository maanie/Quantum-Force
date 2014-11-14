<%@ Page Title="" Language="C#" MasterPageFile="~/QuantumForce.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="QuantumForce.Site.Transactions" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="height: 55px" class=" wrapper">
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
        <asp:GridView ID="gvTransactions" DataKeyNames="ID" runat="server" CssClass="table table-hover table-bordered table-responsive table-striped"
            AutoGenerateColumns="False" ShowFooter="True" 
            OnRowCancelingEdit="gvTransactions_RowCancelingEdit"
            OnRowDeleting="gvTransactions_RowDeleting"
            OnRowEditing="gvTransactions_RowEditing"
            OnRowUpdating="gvTransactions_RowUpdating"
            OnRowCommand="gvTransactions_RowCommand"
            OnRowDataBound="gvTransactions_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Transaction Number" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="ID" runat="server" Width="100px" Text='<%#Eval("ID") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblID" runat="server" Width="100px" Text='<%#Eval("ID") %>' />
                    </EditItemTemplate>

                    <HeaderStyle Width="180px" />

                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Width="100px" Text='<%#Eval("TransactionDate") %>' ItemStyle-HorizontalAlign="Right" />
                    </ItemTemplate>
                    
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Width="150px" Text='<%#Eval("Category") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="txtCategory" Width="150px" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="inCategory" Width="150px" runat="server"  />
                        <!--<asp:RequiredFieldValidator ID="vCategory" runat="server" ControlToValidate="inCategory" Text="?" ValidationGroup="validaiton"/>-->
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Width="350px" Text='<%#Eval("Description") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDescription" Width="370px" runat="server" Text='<%#Eval("Description") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="inDescription" Width="350px" runat="server" CausesValidation ="true" ValidationGroup="validaiton" />
                        <asp:RequiredFieldValidator ID="vDescription" runat="server" ControlToValidate="inDescription" Text="?" ValidationGroup="validaiton"/>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblAmount" runat="server" Width="100px" Text='<%#Eval("Amount") %>' ItemStyle-HorizontalAlign="Right" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAmount" Width="120px" runat="server" Text='<%#Eval("Amount") %>' />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtAmount" ValidationExpression="(^([0-9]*\d*\d{1}?\d*)$)" runat="server" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="inAmount" Width="100px" runat="server" CausesValidation ="true" />
                        <asp:RequiredFieldValidator ID="vAmount" runat="server" ControlToValidate="inAmount" Text="?" ValidationGroup="validaiton" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="inAmount" ValidationExpression="(^([0-9]*\d*\d{1}?\d*)$)" runat="server" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
                    </FooterTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
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
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>

<HeaderStyle Font-Bold="True"></HeaderStyle>
        </asp:GridView>

    </div>

    <asp:Label ID="lblmsg" runat="server"></asp:Label>

    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;
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





