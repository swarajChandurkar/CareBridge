<%@ Page Title="" Language="C#" MasterPageFile="~/Lab/Lab.Master" AutoEventWireup="true" CodeBehind="Upload_Report.aspx.cs" Inherits="CareBridge.Lab.Upload_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Upload report</h1>
        <p>Once uploaded, this becomes visible to the patient and doctor.</p>
    </div>

    <div class="cb-content">
        <div class="cb-form-card">
            <div class="cb-form-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M12 3v12"/><path d="M7 8l5-5 5 5"/><path d="M5 21h14"/></svg>
            </div>
            <h4 style="font-size: 1rem; margin-bottom: 4px;">Attach the report</h4>
            <p style="color: var(--color-muted); font-size: 0.85rem; margin-bottom: 20px;">PDF only. This will be attached to the patient's original test request.</p>

            <asp:Label ID="lblMessage" runat="server" CssClass="text-success d-block mb-3" Text=""></asp:Label>

            <label class="form-label">Report file (PDF)</label>
            <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" />

            <asp:Button ID="btnUpload" runat="server" Text="Upload and mark complete" CssClass="btn-cb-primary w-100 mt-2" OnClick="btnUpload_Click" />
        </div>
    </div>

</asp:Content>