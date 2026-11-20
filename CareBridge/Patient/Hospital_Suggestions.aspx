<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/Patient.Master" AutoEventWireup="true" CodeBehind="Hospital_Suggestions.aspx.cs" Inherits="CareBridge.Patient.Hospital_Suggestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="cb-topbar">
        <h1>Suggested doctors</h1>
        <p>Based on your symptoms, here's who we'd recommend.</p>
    </div>

    <div class="cb-content">
        <asp:Label ID="lblEmpty" runat="server" Text="No matching doctors found right now. Try booking directly instead." CssClass="text-muted" Visible="false"></asp:Label>

        <table class="cb-table">
            <asp:Repeater ID="rptDoctors" runat="server">
                <HeaderTemplate>
                    <tr>
                        <th>Doctor</th>
                        <th>Specialization</th>
                        <th>Hospital</th>
                        <th>Available</th>
                        <th></th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("DoctorName") %></td>
                        <td><%# Eval("Specialization") %></td>
                        <td><%# Eval("HospitalName") %></td>
                        <td><%# Eval("AvailableDays") %>, <%# Eval("AvailableTime") %></td>
                       <td>
    <a href='<%# GetBookLink(Eval("DoctorID")) %>' runat="server" style="color: var(--color-clay); font-weight:500;">Book</a>
</td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>