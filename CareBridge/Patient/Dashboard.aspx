<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/Patient.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CareBridge.Patient.Dashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Welcome back, <asp:Literal ID="litPatientName" runat="server"></asp:Literal></h1>
        <p>Here's what's happening with your care.</p>
    </div>

 <div class="cb-content">

    <div class="cb-welcome-banner">
        <div class="cb-welcome-text">
            <h1>Feeling okay today?</h1>
            <p>Check your appointments or start a new symptom check below.</p>
        </div>
        <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1631217868264-e5b90bb7e133?auto=format&fit=crop&w=400&q=80" alt="Care" />
    </div>

    <div class="cb-grid-4 mb-4">
        <div class="cb-stat-card-v2">
            <div class="cb-stat-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="5" width="18" height="16" rx="2"/><path d="M16 3v4M8 3v4M3 10h18"/></svg>
            </div>
            <div>
                <div class="cb-stat-value"><asp:Literal ID="litUpcoming" runat="server">0</asp:Literal></div>
                <div class="cb-stat-label">Upcoming appointments</div>
            </div>
        </div>

        <div class="cb-stat-card-v2">
            <div class="cb-stat-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2h6v4H9z"/><path d="M9 6H5v16h14V6h-4M9 12h6M9 16h6"/></svg>
            </div>
            <div>
                <div class="cb-stat-value"><asp:Literal ID="litPrescriptions" runat="server">0</asp:Literal></div>
                <div class="cb-stat-label">Active prescriptions</div>
            </div>
        </div>

        <div class="cb-stat-card-v2">
            <div class="cb-stat-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2v6L4 20a1 1 0 001 1h14a1 1 0 001-1L15 8V2M9 2h6"/></svg>
            </div>
            <div>
                <div class="cb-stat-value"><asp:Literal ID="litReports" runat="server">0</asp:Literal></div>
                <div class="cb-stat-label">Lab reports ready</div>
            </div>
        </div>

        <div class="cb-stat-card-v2">
            <div class="cb-stat-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="12" r="9"/><path d="M12 7v5l3 3"/></svg>
            </div>
            <div>
                <div class="cb-stat-value"><asp:Literal ID="litTotalVisits" runat="server">0</asp:Literal></div>
                <div class="cb-stat-label">Total visits</div>
            </div>
        </div>
    </div>

    <h2 style="font-size:1.2rem;" class="mb-3">Quick actions</h2>
    <div class="cb-grid-3">
        <div class="cb-action-card">
            <div class="cb-action-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M12 21s-7-4.5-9.5-9C1 8 2 4 6 4c2 0 4 1.5 6 4 2-2.5 4-4 6-4 4 0 5 4 3.5 8-2.5 4.5-9.5 9-9.5 9z"/></svg>
            </div>
            <h4>Enter symptoms</h4>
            <p>Tell us what you're experiencing and get matched to the right doctor.</p>
            <a href="~/Patient/Enter_Symptoms.aspx" runat="server">Start now</a>
        </div>

        <div class="cb-action-card">
            <div class="cb-action-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="5" width="18" height="16" rx="2"/><path d="M16 3v4M8 3v4M3 10h18"/></svg>
            </div>
            <h4>Book an appointment</h4>
            <p>Already know who you want to see? Book directly with a doctor.</p>
            <a href="~/Patient/Book_Appointment.aspx" runat="server">Book now</a>
        </div>

        <div class="cb-action-card">
            <div class="cb-action-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2h6v4H9z"/><path d="M9 6H5v16h14V6h-4M9 12h6M9 16h6"/></svg>
            </div>
            <h4>View prescriptions</h4>
            <p>Download prescriptions from your past visits any time.</p>
            <a href="~/Patient/Prescriptions.aspx" runat="server">View all</a>
        </div>
    </div>
</div>

</asp:Content>