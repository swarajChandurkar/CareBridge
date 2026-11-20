
<%@ Page Title="" Language="C#" MasterPageFile="~/MedicalStore/MedicalStore.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CareBridge.MedicalStore.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Medical store dashboard</h1>
        <p>Prescriptions waiting to be billed.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1>Bill it, print it, done</h1>
                <p>Open a prescription from the queue to price it and generate a bill.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1583912267550-d6c2ac3196c0?auto=format&fit=crop&w=400&q=80" alt="Pharmacy" />
        </div>

        <div class="cb-grid-2">
            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2h6v4H9z"/><path d="M9 6H5v16h14V6h-4M9 12h6M9 16h6"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litUnbilled" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Prescriptions to bill</div>
                </div>
            </div>

            <div class="cb-stat-card-v2">
                <div class="cb-stat-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M20 6L9 17l-5-5"/></svg>
                </div>
                <div>
                    <div class="cb-stat-value"><asp:Literal ID="litBilledToday" runat="server">0</asp:Literal></div>
                    <div class="cb-stat-label">Billed today</div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>