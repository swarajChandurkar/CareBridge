<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="CareBridge.Admin.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Reports</h1>
        <p>A snapshot of your hospital's activity.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1 style="font-size: 1.25rem;">Everything at a glance</h1>
                <p>Live numbers from appointments, prescriptions, labs, and billing across your hospital.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1576091160550-2173dba999ef?auto=format&fit=crop&w=400&q=80" alt="Hospital reports" />
        </div>

        <div class="row g-3">
            <div class="col-md-4 col-6">
                <div class="cb-stat-card-v2">
                    <div class="cb-stat-icon">
                        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="5" width="18" height="16" rx="2"/><path d="M16 3v4M8 3v4M3 10h18"/></svg>
                    </div>
                    <div>
                        <div class="cb-stat-value"><asp:Literal ID="litTotalAppointments" runat="server">0</asp:Literal></div>
                        <div class="cb-stat-label">Total appointments</div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-6">
                <div class="cb-stat-card-v2">
                    <div class="cb-stat-icon">
                        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 11l3 3L22 4"/><path d="M21 12v7a2 2 0 01-2 2H5a2 2 0 01-2-2V5a2 2 0 012-2h11"/></svg>
                    </div>
                    <div>
                        <div class="cb-stat-value"><asp:Literal ID="litCompletedAppointments" runat="server">0</asp:Literal></div>
                        <div class="cb-stat-label">Completed</div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-6">
                <div class="cb-stat-card-v2">
                    <div class="cb-stat-icon">
                        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2h6v4H9z"/><path d="M9 6H5v16h14V6h-4M9 12h6M9 16h6"/></svg>
                    </div>
                    <div>
                        <div class="cb-stat-value"><asp:Literal ID="litPrescriptions" runat="server">0</asp:Literal></div>
                        <div class="cb-stat-label">Prescriptions issued</div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-6">
                <div class="cb-stat-card-v2">
                    <div class="cb-stat-icon">
                        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2v6L4 20a1 1 0 001 1h14a1 1 0 001-1L15 8V2M9 2h6"/></svg>
                    </div>
                    <div>
                        <div class="cb-stat-value"><asp:Literal ID="litLabTests" runat="server">0</asp:Literal></div>
                        <div class="cb-stat-label">Lab tests requested</div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-6">
                <div class="cb-stat-card-v2">
                    <div class="cb-stat-icon">
                        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M3 3v18h18"/><path d="M7 15l4-6 3 3 5-8"/></svg>
                    </div>
                    <div>
                        <div class="cb-stat-value"><asp:Literal ID="litBills" runat="server">0</asp:Literal></div>
                        <div class="cb-stat-label">Bills generated</div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>