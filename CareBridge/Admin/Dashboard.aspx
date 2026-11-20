<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CareBridge.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Hospital overview</h1>
        <p>Everything running under your hospital.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1>Your hospital, at a glance</h1>
                <p>Manage doctors, labs, and stores, all from one place.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1519494026892-80bbd2d6fd0d?auto=format&fit=crop&w=400&q=80" alt="Hospital" />
        </div>

        <div class="cb-grid-4 mb-4">
            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M4.5 4.5l4 4M19.5 4.5l-4 4M12 2v5M6 21h12l-1.5-7h-9L6 21z"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litDoctors" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Doctors</div>
                </div>
            </div>

            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2v6L4 20a1 1 0 001 1h14a1 1 0 001-1L15 8V2M9 2h6"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litLabs" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Labs</div>
                </div>
            </div>

            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2h6v4H9z"/><path d="M9 6H5v16h14V6h-4M9 12h6M9 16h6"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litStores" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Medical stores</div>
                </div>
            </div>

            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="5" width="18" height="16" rx="2"/><path d="M16 3v4M8 3v4M3 10h18"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litAppointmentsToday" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Appointments today</div>
                </div>
            </div>
        </div>

        <div class="cb-grid-3">
            <div class="cb-action-card">
                <div class="cb-action-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M4.5 4.5l4 4M19.5 4.5l-4 4M12 2v5M6 21h12l-1.5-7h-9L6 21z"/></svg>
                </div>
                <h4>Manage doctors</h4>
                <p>Add or remove doctors under your hospital.</p>
                <a href="~/Admin/Manage_Doctors.aspx" runat="server">Open</a>
            </div>

            <div class="cb-action-card">
                <div class="cb-action-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="5" width="18" height="16" rx="2"/><path d="M16 3v4M8 3v4M3 10h18"/></svg>
                </div>
                <h4>View appointments</h4>
                <p>See every appointment across your hospital.</p>
                <a href="~/Admin/View_Appointments.aspx" runat="server">Open</a>
            </div>

            <div class="cb-action-card">
                <div class="cb-action-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M3 3v18h18"/><path d="M7 15l4-6 3 3 5-8"/></svg>
                </div>
                <h4>Reports</h4>
                <p>Summary stats for your hospital's activity.</p>
                <a href="~/Admin/Reports.aspx" runat="server">Open</a>
            </div>
        </div>
    </div>

</asp:Content>