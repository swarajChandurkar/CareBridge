<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/Patient.Master" AutoEventWireup="true" CodeBehind="Appointment_History.aspx.cs" Inherits="CareBridge.Patient.Appointment_History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Appointment history</h1>
        <p>Everything you've booked, past and upcoming.</p>
    </div>

    <div class="cb-content">
        <asp:Label ID="lblEmpty" runat="server" Text="You haven't booked any appointments yet." CssClass="text-muted" Visible="false"></asp:Label>

        <table class="cb-table">
            <asp:Repeater ID="rptAppointments" runat="server">
                <HeaderTemplate>
                    <tr>
                        <th>Doctor</th>
                        <th>Hospital</th>
                        <th>Date</th>
                        <th>Time</th>
                        <th>Reason</th>
                        <th>Status</th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("DoctorName") %></td>
                        <td><%# Eval("HospitalName") %></td>
                        <td><%# Eval("AppointmentDate", "{0:dd MMM yyyy}") %></td>
                        <td><%# Eval("AppointmentTime") %></td>
                        <td><%# Eval("Symptoms") %></td>
                        <td>
                            <span class='<%# GetBadgeClass(Eval("Status").ToString()) %>'>
                                <%# Eval("Status") %>
                            </span>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>