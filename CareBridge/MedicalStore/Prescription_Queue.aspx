<%@ Page Title="" Language="C#" MasterPageFile="~/MedicalStore/MedicalStore.master" AutoEventWireup="true" CodeBehind="Prescription_Queue.aspx.cs" Inherits="CareBridge.MedicalStore.Prescription_Queue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Prescription queue</h1>
        <p>Open a prescription to price it and generate a bill.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1 style="font-size: 1.25rem;">Ready to bill</h1>
                <p>Prescriptions land here the moment a doctor writes them — price each item and generate a printable bill.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1587854692152-cbe660dbde88?auto=format&fit=crop&w=400&q=80" alt="Pharmacy shelves" />
        </div>

        <asp:Label ID="lblEmpty" runat="server" Text="Nothing to bill right now." CssClass="text-muted" Visible="false"></asp:Label>

        <table class="cb-table" id="queueTable">
            <asp:Repeater ID="rptQueue" runat="server">
                <HeaderTemplate>
                    <tr>
                        <th>Patient</th>
                        <th>Doctor</th>
                        <th>Date</th>
                        <th></th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="cb-name-cell"><%# Eval("PatientName") %></td>
                        <td>Dr. <%# Eval("DoctorName") %></td>
                        <td><%# Eval("PrescriptionDate", "{0:dd MMM yyyy}") %></td>
                        <td>
                            <a href='<%# "~/MedicalStore/BillPrescription.aspx?prescriptionId=" + Eval("PrescriptionID") %>' runat="server" class="cb-table-link">Bill this →</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <script>
        (function () {
            var table = document.getElementById("queueTable");
            if (!table) return;
            var rows = table.querySelectorAll("tbody tr, tr");
            var dataRows = Array.prototype.slice.call(rows, 1);
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