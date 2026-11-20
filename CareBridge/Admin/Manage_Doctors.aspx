<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Manage_Doctors.aspx.cs" Inherits="CareBridge.Admin.Manage_Doctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Manage doctors</h1>
        <p>Add doctors to your hospital.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1 style="font-size: 1.25rem;">Your medical staff</h1>
                <p>Every doctor you add gets their own dashboard for availability, prescriptions, and lab requests.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1631217868264-e5b90bb7e133?auto=format&fit=crop&w=400&q=80" alt="Doctor" />
        </div>

        <div class="cb-action-card mb-4" style="max-width: 640px;">
            <div class="cb-action-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M4.5 4.5l4 4M19.5 4.5l-4 4M12 2v5M6 21h12l-1.5-7h-9L6 21z"/></svg>
            </div>
            <h4 class="mb-3">Add a new doctor</h4>
            <asp:Label ID="lblMessage" runat="server" CssClass="d-block mb-3" Text=""></asp:Label>

            <div class="row g-2 mb-2">
                <div class="col-md-6">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Full name"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control" placeholder="Specialization"></asp:TextBox>
                </div>
            </div>
            <div class="row g-2 mb-2">
                <div class="col-md-6">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                </div>
            </div>
            <div class="row g-2 mb-3">
                <div class="col-md-6">
                    <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="Contact number"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                </div>
            </div>

            <asp:Button ID="btnAdd" runat="server" Text="Add doctor" CssClass="btn-cb-primary" OnClick="btnAdd_Click" />
        </div>

        <h2 style="font-size:1.1rem;" class="mb-3">Your doctors</h2>

        <table class="cb-table" id="doctorsTable">
            <asp:Repeater ID="rptDoctors" runat="server" OnItemCommand="rptDoctors_ItemCommand">
                <HeaderTemplate>
                    <tr><th>Name</th><th>Specialization</th><th>Contact</th><th></th></tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="cb-name-cell"><%# Eval("Name") %></td>
                        <td><%# Eval("Specialization") %></td>
                        <td><%# Eval("Contact") %></td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Remove" CommandArgument='<%# Eval("DoctorID") %>' style="color: #C0553B; font-weight:600;">Remove</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

        <div class="cb-empty-state" id="doctorsEmpty" style="display:none;">
            <div class="cb-empty-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M4.5 4.5l4 4M19.5 4.5l-4 4M12 2v5M6 21h12l-1.5-7h-9L6 21z"/></svg>
            </div>
            <p>No doctors added yet. Use the form above to add your first one.</p>
        </div>
    </div>

    <script>
        (function () {
            function decorate(tableId, emptyId) {
                var table = document.getElementById(tableId);
                if (!table) return;
                var rows = table.querySelectorAll("tbody tr, tr");
                var dataRows = Array.prototype.slice.call(rows, 1); // skip header row

                if (dataRows.length === 0) {
                    table.style.display = "none";
                    var empty = document.getElementById(emptyId);
                    if (empty) empty.style.display = "block";
                    return;
                }

                dataRows.forEach(function (row) {
                    var nameCell = row.querySelector(".cb-name-cell");
                    if (!nameCell || nameCell.querySelector(".cb-patient-avatar")) return;
                    var name = nameCell.textContent.trim();
                    var initial = name.charAt(0).toUpperCase() || "?";
                    nameCell.innerHTML =
                        '<div class="cb-patient-cell"><div class="cb-patient-avatar">' + initial + '</div><span>' + name + '</span></div>';
                });
            }
            decorate("doctorsTable", "doctorsEmpty");
        })();
    </script>

</asp:Content>