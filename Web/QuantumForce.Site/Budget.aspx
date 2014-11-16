<%@ Page Title="" Language="C#" MasterPageFile="~/QuantumForce.Master" AutoEventWireup="true" CodeBehind="Budget.aspx.cs" Inherits="QuantumForce.Site.Budget" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <h1>Budget Calculator</h1>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <div class="panel panel-default">
        <div class="panel-heading">
            A) Domestic
        </div>
        <div class="panel-body">
            <div class="col-md-4">
                House rent/bond payment
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomHomePayments" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Rates
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomRates" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Water and Electricity
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomLevyExp" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Insurance
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomInsurance" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Telephone
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomTelephone" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                TV rental/license
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomTVExp" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                School expenses
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomSchoolExp" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Loans/credit card/HP
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomLoans" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Food and household expenses
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomHouseholdExp" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Entertainment
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomEntertainment" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Other
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="DomOther" runat="server" class="form-control cat-a-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
        </div>
        <div class="panel-footer">
            <div class="col-md-4">
                Subtotal A
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="cat-a-subtotal" class="form-control" disabled="disabled" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            B) Personal
        </div>
        <div class="panel-body">
            <div class="col-md-4">
                Life assurance
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="PersLifeAssurance" runat="server" class="form-control cat-b-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Pension/retirement contrbutions
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="PersProvidentFund" runat="server" class="form-control cat-b-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Medical expenses
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="PersMedicalAid" runat="server" class="form-control cat-b-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Transport (bus/train/taxi, etc.)
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="PersTransport" runat="server" class="form-control cat-b-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Clothing
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="PersClothing" runat="server" class="form-control cat-b-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Other
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="PersOther" runat="server" class="form-control cat-b-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
        </div>
        <div class="panel-footer">
            <div class="col-md-4">
                Subtotal B
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="cat-b-subtotal" class="form-control" disabled="disabled" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            C) Car Expenses
        </div>
        <div class="panel-body">
            <div class="col-md-4">
                Monthly payment
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="CarMonthlyPayments" runat="server" class="form-control cat-c-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Insurance
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="CarInsurance" runat="server" class="form-control cat-c-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Servicing/repairs
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="CarExpenses" runat="server" class="form-control cat-c-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
            <hr />
            <div class="col-md-4">
                Petrol
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="CarPetrol" runat="server" class="form-control cat-c-expense" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
        </div>
        <div class="panel-footer">
            <div class="col-md-4">
                Subtotal C
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="cat-c-subtotal" class="form-control" disabled="disabled" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Income Less Expenses</h3>
        </div>
        <div class="panel-heading">
            <div class="col-md-4">
                D) Monthly Income (After deductions)
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="MonthlyIncome" runat="server" class="form-control" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
        </div>
        <div class="panel-heading">
            <div class="col-md-4">
                E) Total Monthly Expenses (A + B + C)
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="total-expense" class="form-control" disabled="disabled" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
        </div>
        <div class="panel-heading">
            <div class="col-md-4">
                Amount Remaining (D - E)
            </div>
            <div class="col-md-8">
                <div class="input-group input-group-sm">
                    <span class="input-group-addon">R</span>
                    <input type="text" id="remainder" class="form-control" disabled="disabled" placeholder="0.0">
                </div>
            </div>
            <br style="clear: both" />
        </div>
    </div>

    <hr />
    <br />

    <div class="col-md-4">
        <input id="BudgetName" class="form-control" placeholder="Budget Name" runat="server" />
    </div>
    <div class="col-md-4">
        <asp:Button ID="SaveBudget" runat="server" Text="Save" CssClass="btn btn-default" OnClick="SaveBudget_Click" />
        <asp:Button ID="Back" runat="server" Text="Back" CssClass="btn btn-default" OnClick="Back_Click" />
    </div>

    <br />
    <br />
    <hr />

    <script type="text/javascript">

        $(document).ready(function () {
            CalcCatAExense();
            CalcCatBExense();
            CalcCatCExense();
            ApplyCalculations();
        });

        $(".cat-a-expense").change(function () {

            var total = 0;

            $(".cat-a-expense").each(function () {

                var num = parseFloat(this.value);
                if (isNumber(num)) {
                    total += num;
                }
            });

            $("#cat-a-subtotal").prop("value", total);
            ApplyCalculations();
        });

        $(".cat-b-expense").change(function () {

            var total = 0;

            $(".cat-b-expense").each(function () {

                var num = parseFloat(this.value);
                if (isNumber(num)) {
                    total += num;
                }
            });

            $("#cat-b-subtotal").prop("value", total);
            ApplyCalculations();
        });

        $(".cat-c-expense").change(function () {

            var total = 0;

            $(".cat-c-expense").each(function () {

                var num = parseFloat(this.value);
                if (isNumber(num)) {
                    total += num;
                }
            });

            $("#cat-c-subtotal").prop("value", total);
            ApplyCalculations();
        });

        $("#<%= MonthlyIncome.ClientID %>").change(function () {

            ApplyCalculations();
        });

        function CalcCatAExense() {
            var total = 0;

            $(".cat-a-expense").each(function () {

                var num = parseFloat(this.value);
                if (isNumber(num)) {
                    total += num;
                }
            });

            $("#cat-a-subtotal").prop("value", total);
        }

        function CalcCatBExense() {
            var total = 0;

            $(".cat-b-expense").each(function () {

                var num = parseFloat(this.value);
                if (isNumber(num)) {
                    total += num;
                }
            });

            $("#cat-b-subtotal").prop("value", total);
        }

        function CalcCatCExense() {
            var total = 0;

            $(".cat-c-expense").each(function () {

                var num = parseFloat(this.value);
                if (isNumber(num)) {
                    total += num;
                }
            });

            $("#cat-c-subtotal").prop("value", total);
        }

        function ApplyCalculations() {

            var catA = parseFloat($("#cat-a-subtotal").prop("value"));
            var catB = parseFloat($("#cat-b-subtotal").prop("value"));
            var catC = parseFloat($("#cat-c-subtotal").prop("value"));

            var totalExpense = 0;

            if (isNumber(catA)) {
                totalExpense += catA;
            }
            if (isNumber(catB)) {
                totalExpense += catB;
            }
            if (isNumber(catC)) {
                totalExpense += catC;
            }

            if (isNumber(totalExpense)) {
                $("#total-expense").prop("value", totalExpense);

                var income = $("#<%= MonthlyIncome.ClientID %>").prop("value");

                if (isNumber(income)) {
                    var remainder = income - totalExpense;

                    $("#remainder").prop("value", remainder);

                    if (remainder > 0) {
                        // Green
                        $("#remainder").css('background-color', '#5ED866');
                    }
                    else {
                        // Red
                        $("#remainder").css('background-color', '#FF8888');
                    }
                }
            }
        }

        function isNumber(n) {
            return !isNaN(parseFloat(n)) && isFinite(n);
        }

    </script>

</asp:Content>
