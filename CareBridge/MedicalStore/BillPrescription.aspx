<%@ Page Title="" Language="C#" MasterPageFile="~/MedicalStore/MedicalStore.Master" AutoEventWireup="true" CodeBehind="BillPrescription.aspx.cs" Inherits="CareBridge.MedicalStore.BillPrescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Bill prescription</h1>
        <p>Enter a price for each medicine. Total updates as you type.</p>
    </div>

    <div class="cb-content">

        <div class="cb-form-icon" style="margin-bottom: 16px;">
            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2h6v4H9z"/><path d="M9 6H5v16h14V6h-4M9 12h6M9 16h6"/></svg>
        </div>

        <table class="cb-table mb-3">
            <thead>
                <tr>
                    <th>Medicine</th>
                    <th>Dosage</th>
                    <th>Qty</th>
                    <th style="width:140px;">Price (₹)</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptItems" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("MedicineName") %></td>
                            <td><%# Eval("Dosage") %></td>
                            <td><%# Eval("Quantity") %></td>
                            <td>
                                <asp:HiddenField runat="server" ID="hidMedName" Value='<%# Eval("MedicineName") %>' />
                                <asp:HiddenField runat="server" ID="hidQty" Value='<%# Eval("Quantity") %>' />
                                <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control cb-price-input" placeholder="0.00"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <div class="text-end mb-3" style="font-family:'Poppins',sans-serif; font-weight:700; font-size:1.3rem; color: var(--color-primary-dark);">
            Total: ₹<span id="totalDisplay">0.00</span>
        </div>

        <asp:HiddenField ID="hidTotal" runat="server" />
        <asp:Button ID="btnGenerateBill" runat="server" Text="Generate bill" CssClass="btn-cb-primary" OnClick="btnGenerateBill_Click" OnClientClick="return calculateTotal();" />
    </div>

    <script>
        function calculateTotal() {
            var inputs = document.querySelectorAll('.cb-price-input');
            var total = 0;
            inputs.forEach(function (input) {
                var val = parseFloat(input.value);
                if (!isNaN(val)) total += val;
            });
            document.getElementById('totalDisplay').innerText = total.toFixed(2);
            document.getElementById('<%= hidTotal.ClientID %>').value = total.toFixed(2);
            return true;
        }

        document.addEventListener('DOMContentLoaded', function () {
            document.querySelectorAll('.cb-price-input').forEach(function (input) {
                input.addEventListener('input', calculateTotal);
            });
        });
    </script>

</asp:Content>