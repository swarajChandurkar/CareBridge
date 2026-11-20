<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CareBridge.Doctor.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="cb-topbar">
        <h1>Welcome back, Dr. <asp:Literal ID="litDoctorName" runat="server"></asp:Literal></h1>
        <p>Here's your day at a glance.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1>Your day starts here</h1>
                <p>Review today's appointments or update your availability.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1622253692010-333f2da6031d?auto=format&fit=crop&w=400&q=80" alt="Doctor" />
        </div>

        <div class="cb-grid-3 mb-4">
            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="5" width="18" height="16" rx="2"/><path d="M16 3v4M8 3v4M3 10h18"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litToday" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Today's appointments</div>
                </div>
            </div>

            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="12" r="9"/><path d="M12 7v5l3 3"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litPending" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Pending confirmations</div>
                </div>
            </div>

            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M20 6L9 17l-5-5"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litCompleted" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Completed this month</div>
                </div>
            </div>
        </div>

        <div class="cb-grid-2">
            <div class="cb-action-card">
                <div class="cb-action-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="12" r="9"/><path d="M12 7v5l3 3"/></svg>
                </div>
                <h4>Set your availability</h4>
                <p>Update the days and times patients can book with you.</p>
                <a href="~/Doctor/SetAvailability.aspx" runat="server">Update now</a>
            </div>

            <div class="cb-action-card">
                <div class="cb-action-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="5" width="18" height="16" rx="2"/><path d="M16 3v4M8 3v4M3 10h18"/></svg>
                </div>
                <h4>View appointments</h4>
                <p>See your full list, confirm bookings, and open patient records.</p>
                <a href="~/Doctor/Appointments.aspx" runat="server">View all</a>
            </div>
        </div>
    </div>



</asp:Content>