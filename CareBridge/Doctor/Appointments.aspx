<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="CareBridge.Doctor.Appointments" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Your appointments</h1>
        <p>Confirm bookings and open patient records.</p>
    </div>

    <div class="cb-content">

        <asp:Panel ID="pnlEmpty" runat="server" Visible="false">
            <div class="cb-empty-state">
                <div class="cb-empty-icon">
                    <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="5" width="18" height="16" rx="2"/><path d="M16 3v4M8 3v4M3 10h18"/></svg>
                </div>
                <p>No appointments yet. New bookings will show up here.</p>
            </div>
        </asp:Panel>

        <table class="cb-table">
            <asp:Repeater ID="rptAppointments" runat="server" OnItemCommand="rptAppointments_ItemCommand">
                <HeaderTemplate>
                    <tr>
                        <th>Patient</th>
                        <th>Date</th>
                        <th>Time</th>
                        <th>Reason</th>
                        <th>Status</th>
                        <th></th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                      <td>
    <div class="cb-patient-cell">
        <div class="cb-patient-avatar">
            <%# string.IsNullOrEmpty(Convert.ToString(Eval("PatientName"))) 
                ? "?" 
                : Convert.ToString(Eval("PatientName")).Trim().Substring(0, 1).ToUpper() %>
        </div>

        <%# Eval("PatientName") %>
    </div>
</td>
                        <td><%# Eval("AppointmentDate", "{0:dd MMM yyyy}") %></td>
                        <td><%# Eval("AppointmentTime") %></td>
                        <td><%# Eval("Symptoms") %></td>
                        <td>
                            <span class='<%# GetBadgeClass(Eval("Status").ToString()) %>'>
                                <%# Eval("Status") %>
                            </span>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Confirm" CommandArgument='<%# Eval("AppointmentID") %>' CssClass="cb-table-link" style="margin-right:14px;">Confirm</asp:LinkButton>
                            <a href='<%# "~/Doctor/PatientRecord.aspx?appointmentId=" + Eval("AppointmentID") %>' runat="server" class="cb-table-link-muted">Open</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>