<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="RequestLabTest.aspx.cs" Inherits="CareBridge.Doctor.RequestLabTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Request a lab test</h1>
        <p>Send this patient for testing at a connected lab.</p>
    </div>

    <div class="cb-content">
        <div style="max-width: 480px;">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success d-block mb-3" Text=""></asp:Label>

            <div class="mb-3">
                <label class="form-label">Test name</label>
                <asp:TextBox ID="txtTestName" runat="server" CssClass="form-control" placeholder="e.g. Complete Blood Count"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Lab</label>
                <asp:DropDownList ID="ddlLab" runat="server" CssClass="form-select"
                    DataTextField="Name" DataValueField="LabID"></asp:DropDownList>
            </div>

            <asp:Button ID="btnSend" runat="server" Text="Send request" CssClass="btn-cb-primary" OnClick="btnSend_Click" />
        </div>
    </div>

</asp:Content>