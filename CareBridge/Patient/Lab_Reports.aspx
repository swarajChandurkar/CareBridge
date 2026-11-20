<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/Patient.Master" AutoEventWireup="true" CodeBehind="Lab_Reports.aspx.cs" Inherits="CareBridge.Patient.Lab_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Lab reports</h1>
        <p>Download reports once your lab marks them complete.</p>
    </div>

    <div class="cb-content">
        <asp:Label ID="lblEmpty" runat="server" Text="No lab reports yet." CssClass="text-muted" Visible="false"></asp:Label>

        <table class="cb-table">
            <asp:Repeater ID="rptReports" runat="server">
                <HeaderTemplate>
                    <tr>
                        <th>Test</th>
                        <th>Lab</th>
                        <th>Uploaded</th>
                        <th></th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("TestName") %></td>
                        <td><%# Eval("LabName") %></td>
                        <td><%# Eval("UploadDate", "{0:dd MMM yyyy}") %></td>
                        <td>
                            <a href='<%# Eval("ReportFilePath") %>' target="_blank" runat="server" style="color: var(--color-clay); font-weight:500;">Download</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>