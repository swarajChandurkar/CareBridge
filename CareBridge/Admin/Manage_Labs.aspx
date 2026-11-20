<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Manage_Labs.aspx.cs" Inherits="CareBridge.Admin.Manage_Labs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Manage labs</h1>
        <p>Add labs connected to your hospital.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1 style="font-size: 1.25rem;">Diagnostic partners</h1>
                <p>Labs you add here can receive test requests directly from your doctors and upload results instantly.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1579154204601-01588f351e67?auto=format&fit=crop&w=400&q=80" alt="Lab technician" />
        </div>

        <div class="cb-action-card mb-4" style="max-width: 640px;">
    <div class="cb-action-icon">
        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2v6L4 20a1 1 0 001 1h14a1 1 0 001-1L15 8V2M9 2h6"/></svg>
    </div>
    <h4 class="mb-3">Add a new lab</h4>
    <asp:Label ID="lblMessage" runat="server" CssClass="d-block mb-3" Text=""></asp:Label>

    <div class="cb-field-row" style="margin-bottom: 20px;">
        <div class="cb-field-group" style="margin-bottom: 0;">
            <label>Lab name</label>
            <div class="cb-input-icon-group">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2v6L4 20a1 1 0 001 1h14a1 1 0 001-1L15 8V2M9 2h6"/></svg>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="e.g. City General Diagnostics"></asp:TextBox>
            </div>
        </div>
        <div class="cb-field-group" style="margin-bottom: 0;">
            <label>Contact number</label>
            <div class="cb-input-icon-group">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M22 16.92v3a2 2 0 01-2.18 2 19.79 19.79 0 01-8.63-3.07 19.5 19.5 0 01-6-6 19.79 19.79 0 01-3.07-8.67A2 2 0 014.11 2h3a2 2 0 012 1.72c.127.96.362 1.902.7 2.81a2 2 0 01-.45 2.11L8.09 9.91a16 16 0 006 6l1.27-1.27a2 2 0 012.11-.45c.908.338 1.85.573 2.81.7A2 2 0 0122 16.92z"/></svg>
                <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="10-digit number"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="cb-field-row" style="margin-bottom: 20px;">
        <div class="cb-field-group" style="margin-bottom: 0;">
            <label>Username</label>
            <div class="cb-input-icon-group">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="8" r="4"/><path d="M4 21c0-4 4-6 8-6s8 2 8 6"/></svg>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Login username"></asp:TextBox>
            </div>
        </div>
        <div class="cb-field-group" style="margin-bottom: 0;">
            <label>Password</label>
            <div class="cb-input-icon-group">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="11" width="18" height="11" rx="2"/><path d="M7 11V7a5 5 0 0110 0v4"/></svg>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Set a password"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="cb-field-group">
        <label>Address</label>
        <div class="cb-input-icon-group">
            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M21 10c0 7-9 12-9 12s-9-5-9-12a9 9 0 0118 0z"/><circle cx="12" cy="10" r="3"/></svg>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Street, city, pincode"></asp:TextBox>
        </div>
    </div>

    <asp:Button ID="btnAdd" runat="server" Text="Add lab" CssClass="btn-cb-primary" OnClick="btnAdd_Click" />
</div>

        <h2 style="font-size:1.1rem;" class="mb-3">Your labs</h2>

        <table class="cb-table" id="labsTable">
            <asp:Repeater ID="rptLabs" runat="server" OnItemCommand="rptLabs_ItemCommand">
                <HeaderTemplate>
                    <tr><th>Name</th><th>Contact</th><th>Address</th><th></th></tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="cb-name-cell"><%# Eval("Name") %></td>
                        <td><%# Eval("Contact") %></td>
                        <td><%# Eval("Address") %></td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Remove" CommandArgument='<%# Eval("LabID") %>' style="color: #C0553B; font-weight:600;">Remove</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

        <div class="cb-empty-state" id="labsEmpty" style="display:none;">
            <div class="cb-empty-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2v6L4 20a1 1 0 001 1h14a1 1 0 001-1L15 8V2M9 2h6"/></svg>
            </div>
            <p>No labs added yet. Use the form above to add your first one.</p>
        </div>
    </div>

    <script>
        (function () {
            var table = document.getElementById("labsTable");
            if (!table) return;
            var rows = table.querySelectorAll("tbody tr, tr");
            var dataRows = Array.prototype.slice.call(rows, 1);

            if (dataRows.length === 0) {
                table.style.display = "none";
                var empty = document.getElementById("labsEmpty");
                if (empty) empty.style.display = "block";
                return;
            }

            dataRows.forEach(function (row) {
                var cell = row.querySelector(".cb-name-cell");
                if (!cell) return;
                var name = cell.textContent.trim();
                var initial = name.charAt(0).toUpperCase() || "?";
                cell.innerHTML = '<div class="cb-patient-cell"><div class="cb-patient-avatar">' + initial + '</div><span>' + name + '</span></div>';
            });
        })();
    </script>

</asp:Content>