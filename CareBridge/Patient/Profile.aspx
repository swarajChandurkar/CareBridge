<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/Patient.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CareBridge.Patient.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Your profile</h1>
        <p>Keep your details up to date.</p>
    </div>

    <div class="cb-content">

        <div class="cb-welcome-banner">
            <div class="cb-welcome-text">
                <h1 style="font-size: 1.25rem;">Keep this current</h1>
                <p>Your contact details are what doctors and labs use to reach you about appointments and reports.</p>
            </div>
            <img class="cb-welcome-img" src="https://images.unsplash.com/photo-1576091160399-112ba8d25d1d?auto=format&fit=crop&w=400&q=80" alt="Care team" />
        </div>

        <div class="cb-form-card">
            <div class="cb-form-icon">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="8" r="4"/><path d="M4 21c0-4 4-6 8-6s8 2 8 6"/></svg>
            </div>

            <asp:Label ID="lblMessage" runat="server" CssClass="text-success d-block mb-3" Text=""></asp:Label>

            <label class="form-label">Full name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>

            <label class="form-label">Contact number</label>
            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>

            <label class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>

            <label class="form-label">Address</label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>

            <label class="form-label">Date of birth</label>
            <asp:TextBox ID="txtDob" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

            <label class="form-label">Gender</label>
            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-select">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="btnSave" runat="server" Text="Save changes" CssClass="btn-cb-primary" OnClick="btnSave_Click" />
        </div>
    </div>

</asp:Content>