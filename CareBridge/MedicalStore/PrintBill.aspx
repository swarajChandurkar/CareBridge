<%@ Page Title="" Language="C#" MasterPageFile="~/MedicalStore/MedicalStore.Master" AutoEventWireup="true" CodeBehind="PrintBill.aspx.cs" Inherits="CareBridge.MedicalStore.PrintBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-bill">
        <div class="cb-bill-header">
            <h2>CareBridge</h2>
            <p>Medicine Bill</p>
        </div>

        <div class="cb-bill-meta">
            <span>Patient: <asp:Literal ID="litPatientName" runat="server"></asp:Literal></span>
            <span><asp:Literal ID="litBillDate" runat="server"></asp:Literal></span>
        </div>

        <table class="cb-bill-table">
            <thead>
                <tr><th>Medicine</th><th>Qty</th><th style="text-align:right;">Price</th></tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptItems" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("MedicineName") %></td>
                            <td><%# Eval("Quantity") %></td>
                            <td style="text-align:right;">₹<%# Eval("Price", "{0:0.00}") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <div class="cb-bill-total">
            Total: ₹<asp:Literal ID="litTotal" runat="server"></asp:Literal>
        </div>
    </div>

    <div class="cb-print-btn">
        <asp:Button ID="btnPrint" runat="server" Text="Print bill" CssClass="btn-cb-primary" OnClientClick="window.print(); return false;" />
    </div>

</asp:Content>