<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/Patient.Master" AutoEventWireup="true" CodeBehind="Book_Appointment.aspx.cs" Inherits="CareBridge.Patient.Book_Appointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Book an appointment</h1>
        <p>Pick a doctor, date, and time that works for you.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1 style="font-size: 1.25rem;">A few quick details</h1>
                <p>Tell us who you'd like to see and when — you'll get a confirmation once the doctor accepts.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1550831107-1553da8c8464?auto=format&fit=crop&w=400&q=80" alt="Doctor at desk" />
        </div>

        <div class="cb-form-card">
            <div class="cb-form-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="4" width="18" height="16" rx="2"/><path d="M3 9h18M8 4v3M16 4v3"/></svg>
            </div>

            <asp:Label ID="lblMessage" runat="server" CssClass="d-block mb-3" Text=""></asp:Label>

            <label class="form-label">Doctor</label>
            <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-select"
                DataTextField="DisplayName" DataValueField="DoctorID"></asp:DropDownList>

            <label class="form-label">Symptoms / reason for visit</label>
            <asp:TextBox ID="txtSymptoms" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>

            <label class="form-label">Date</label>
            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

            <label class="form-label">Time</label>
            <asp:TextBox ID="txtTime" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>

            <asp:Button ID="btnBook" runat="server" Text="Confirm booking" CssClass="btn-cb-primary" OnClick="btnBook_Click" />
        </div>
    </div>

</asp:Content>