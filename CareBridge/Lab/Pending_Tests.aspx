<%@ Page Title="" Language="C#" MasterPageFile="~/Lab/Lab.Master" AutoEventWireup="true" CodeBehind="Pending_Tests.aspx.cs" Inherits="CareBridge.Lab.Pending_Tests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Test requests</h1>
        <p>Update status and upload reports as they're ready.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1 style="font-size: 1.25rem;">Incoming from your hospitals</h1>
                <p>Test requests land here the moment a doctor sends them — patients see results the instant you upload.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1579154204601-01588f351e67?auto=format&fit=crop&w=400&q=80" alt="Lab technician" />
        </div>

        <asp:Label ID="lblEmpty" runat="server" Text="No test requests yet." CssClass="text-muted" Visible="false"></asp:Label>

        <table class="cb-table" id="testsTable">
            <asp:Repeater ID="rptTests" runat="server" OnItemCommand="rptTests_ItemCommand">
                <HeaderTemplate>
                    <tr>
                        <th>Patient</th>
                        <th>Test</th>
                        <th>Requested by</th>
                        <th>Status</th>
                        <th></th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="cb-name-cell"><%# Eval("PatientName") %></td>
                        <td><%# Eval("TestName") %></td>
                        <td>Dr. <%# Eval("DoctorName") %></td>
                        <td>
                            <span class='<%# GetBadgeClass(Eval("Status").ToString()) %>'>
                                <%# Eval("Status") %>
                            </span>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="StartProgress" CommandArgument='<%# Eval("RequestID") %>'
                                CssClass="cb-table-link-muted"
                                style="margin-right:14px;"
                                Visible='<%# Eval("Status").ToString() == "Pending" %>'>Start</asp:LinkButton>
                            <a href='<%# "~/Lab/Upload_Report.aspx?requestId=" + Eval("RequestID") %>' runat="server" class="cb-table-link">Upload report</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <script>
        (function () {
            var table = document.getElementById("testsTable");
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