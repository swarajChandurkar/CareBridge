<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/Patient.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="CareBridge.Patient.Prescriptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Your prescriptions</h1>
        <p>Everything a doctor has prescribed you.</p>
    </div>

    <div class="cb-content">
        <asp:Label ID="lblEmpty" runat="server" Text="No prescriptions yet." CssClass="text-muted" Visible="false"></asp:Label>

        <asp:Repeater ID="rptPrescriptions" runat="server">
            <ItemTemplate>
                <div class="cb-action-card mb-3">
                    <div class="d-flex justify-content-between align-items-start mb-2">
                        <div>
                            <h4 class="mb-0">Dr. <%# Eval("DoctorName") %></h4>
                            <span style="color: var(--color-muted); font-size: 0.85rem;"><%# Eval("PrescriptionDate", "{0:dd MMM yyyy}") %></span>
                        </div>
                    </div>

                    <table class="cb-table">
                        <thead>
                            <tr><th>Medicine</th><th>Dosage</th><th>Qty</th><th>Instructions</th></tr>
                        </thead>
                        <tbody>
                            <%# GetMedicineRows(Eval("PrescriptionID")) %>
                        </tbody>
                    </table>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>