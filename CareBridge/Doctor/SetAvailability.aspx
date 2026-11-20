
<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.master" AutoEventWireup="true" CodeBehind="SetAvailability.aspx.cs" Inherits="CareBridge.Doctor.SetAvailability" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Set your availability</h1>
        <p>Patients will only be able to book you within these hours.</p>
    </div>

    <div class="cb-content">
        <div class="cb-form-card">
            <div class="cb-form-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="12" r="9"/><path d="M12 7v5l3 3"/></svg>
            </div>

            <asp:Label ID="lblMessage" runat="server" CssClass="text-success d-block mb-3" Text=""></asp:Label>

            <div>
                <label class="form-label">Available days</label>
                <asp:TextBox ID="txtDays" runat="server" CssClass="form-control" placeholder="e.g. Mon, Wed, Fri"></asp:TextBox>
            </div>

            <div>
                <label class="form-label">Available time</label>
                <asp:TextBox ID="txtTime" runat="server" CssClass="form-control" placeholder="e.g. 10:00 AM - 2:00 PM"></asp:TextBox>
            </div>

            <asp:Button ID="btnSave" runat="server" Text="Save availability" CssClass="btn-cb-primary" OnClick="btnSave_Click" />
        </div>
    </div>

</asp:Content>