<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="PatientRecord.aspx.cs" Inherits="CareBridge.Doctor.PatientRecord" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1><asp:Literal ID="litPatientName" runat="server"></asp:Literal></h1>
        <p>Patient record</p>
    </div>

    <div class="cb-content">

        <div class="cb-form-card mb-4" style="max-width: none; display:flex; align-items:center; gap:16px;">
            <div class="cb-patient-avatar" style="width:52px; height:52px; font-size:1.2rem;">
                <asp:Literal ID="litPatientInitial" runat="server"></asp:Literal>
            </div>
            <div>
                <div style="font-weight:600; font-size:1.02rem; color: var(--color-text);">
                    Visit on <asp:Literal ID="litVisitDate" runat="server"></asp:Literal>
                </div>
                <div style="color: var(--color-muted); font-size:0.9rem; margin-top:3px;">
                    <asp:Literal ID="litSymptoms" runat="server"></asp:Literal>
                </div>
            </div>
        </div>

        <div class="cb-grid-2 mb-4">
            <div class="cb-action-card">
                <div class="cb-action-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2h6v4H9z"/><path d="M9 6H5v16h14V6h-4M9 12h6M9 16h6"/></svg>
                </div>
                <h4>Write a prescription</h4>
                <p>Add medicines, dosage, and instructions for this visit.</p>
                <asp:HyperLink ID="lnkWritePrescription" runat="server" Text="Write now" CssClass="cb-table-link" />
            </div>

            <div class="cb-action-card">
                <div class="cb-action-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2v6L4 20a1 1 0 001 1h14a1 1 0 001-1L15 8V2M9 2h6"/></svg>
                </div>
                <h4>Request a lab test</h4>
                <p>Send this patient for a lab test from a connected lab.</p>
                <asp:HyperLink ID="lnkRequestLabTest" runat="server" Text="Request now" CssClass="cb-table-link" />
            </div>
        </div>

        <h2 style="font-size:1.15rem;" class="mb-3">Past visits</h2>

        <asp:Panel ID="pnlNoHistory" runat="server" Visible="false">
            <div class="cb-empty-state">
                <div class="cb-empty-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="12" r="9"/><path d="M12 7v5l3 3"/></svg>
                </div>
                <p>No previous visits on record.</p>
            </div>
        </asp:Panel>

        <table class="cb-table">
            <asp:Repeater ID="rptHistory" runat="server">
                <HeaderTemplate>
                    <tr><th>Date</th><th>Symptoms</th><th>Status</th></tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("AppointmentDate", "{0:dd MMM yyyy}") %></td>
                        <td><%# Eval("Symptoms") %></td>
                        <td>
                            <span class='<%# Eval("BadgeClass") %>'>
    <%# Eval("Status") %>
</span>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>