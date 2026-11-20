<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="View_Appointments.aspx.cs" Inherits="CareBridge.Admin.View_Appointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>All appointments</h1>
        <p>Every appointment booked under your hospital.</p>
    </div>

    <div class="cb-content">

        <table class="cb-table">
            <asp:Repeater ID="rptAppointments" runat="server">
                <HeaderTemplate>
                    <tr>
                        <th>Patient</th>
                        <th>Doctor</th>
                        <th>Date</th>
                        <th>Time</th>
                        <th>Status</th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("PatientName") %></td>
                        <td>Dr. <%# Eval("DoctorName") %></td>
                        <td><%# Eval("AppointmentDate", "{0:dd MMM yyyy}") %></td>
                        <td><%# Eval("AppointmentTime") %></td>
                        <td>
                            <span class='<%# GetBadgeClass(Eval("Status").ToString()) %>'>
                                <%# Eval("Status") %>
                            </span>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

        <asp:Label ID="lblEmpty" runat="server" Text="No appointments yet." CssClass="text-muted" Visible="false"></asp:Label>
    </div>

</asp:Content>