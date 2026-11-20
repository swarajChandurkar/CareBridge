<%@ Page Title="" Language="C#" MasterPageFile="~/Lab/Lab.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CareBridge.Lab.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Lab dashboard</h1>
        <p>Track incoming test requests.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1>Keep tests moving</h1>
                <p>Update status as tests progress and upload results the moment they're ready.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1579154204601-01588f351e67?auto=format&fit=crop&w=400&q=80" alt="Lab" />
        </div>

        <div class="cb-grid-3">
            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="12" r="9"/><path d="M12 7v5l3 3"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litPending" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Pending</div>
                </div>
            </div>

            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M12 2v20M2 12h20"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litInProgress" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">In progress</div>
                </div>
            </div>

            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M20 6L9 17l-5-5"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litCompleted" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Completed</div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>