<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="WritePrescription.aspx.cs" Inherits="CareBridge.Doctor.WritePrescription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Write prescription</h1>
        <p>Add each medicine one at a time.</p>
    </div>

    <div class="cb-content">
        <div class="cb-form-card" style="max-width: 680px;">
            <div class="cb-form-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2h6v4H9z"/><path d="M9 6H5v16h14V6h-4M9 12h6M9 16h6"/></svg>
            </div>

            <asp:Label ID="lblMessage" runat="server" CssClass="text-success d-block mb-3" Text=""></asp:Label>

            <div class="cb-input-row mb-3">
                <asp:TextBox ID="txtMedName" runat="server" CssClass="form-control" placeholder="Medicine name"></asp:TextBox>
                <asp:TextBox ID="txtDosage" runat="server" CssClass="form-control" placeholder="Dosage e.g. 500mg"></asp:TextBox>
                <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" placeholder="Qty"></asp:TextBox>
                <asp:TextBox ID="txtInstructions" runat="server" CssClass="form-control" placeholder="Instructions"></asp:TextBox>
            </div>

            <asp:Button ID="btnAddMedicine" runat="server" Text="+ Add medicine" CssClass="btn-cb-primary mb-4" OnClick="btnAddMedicine_Click" />

            <asp:Panel ID="pnlNoMedicines" runat="server" Visible="true">
                <div class="cb-empty-state mb-4">
                    <p>No medicines added yet. Add one above to get started.</p>
                </div>
            </asp:Panel>

            <table class="cb-table mb-4">
                <asp:Repeater ID="rptMedicines" runat="server">
                    <HeaderTemplate>
                        <tr><th>Medicine</th><th>Dosage</th><th>Qty</th><th>Instructions</th></tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("MedicineName") %></td>
                            <td><%# Eval("Dosage") %></td>
                            <td><%# Eval("Quantity") %></td>
                            <td><%# Eval("Instructions") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

            <asp:Button ID="btnFinish" runat="server" Text="Finish prescription" CssClass="btn-cb-primary" OnClick="btnFinish_Click" />
        </div>
    </div>

</asp:Content>