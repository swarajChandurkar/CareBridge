<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CareBridge.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="cb-auth-wrap">
        <div class="cb-auth-brand" style="background-image: linear-gradient(160deg, rgba(18,174,196,0.90) 0%, rgba(12,147,166,0.94) 100%), url('https://images.unsplash.com/photo-1550831107-1553da8c8464?auto=format&fit=crop&w=900&q=80'); background-size: cover; background-position: center;">
            <div class="cb-eyebrow-pill" style="background-color: rgba(255,255,255,0.18); color: #FFFFFF; width: fit-content;">● Now live across 5 connected roles</div>
            <h2>Join CareBridge.</h2>
            <p>Whether you're a patient, a hospital, a doctor, a lab or a medical store, one account gets you onto the platform.</p>
        </div>
        <div class="cb-auth-form">
            <div class="cb-auth-card">
             <h3 class="mb-4">Create your account</h3>
<asp:Label ID="lblMessage" runat="server" CssClass="d-block mb-3" Text=""></asp:Label>

<div class="mb-3">
    <label class="form-label">Register as</label>
    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select">
        <asp:ListItem Text="-- Select role --" Value=""></asp:ListItem>
        <asp:ListItem Text="Patient" Value="Patient"></asp:ListItem>
        <asp:ListItem Text="Hospital" Value="Hospital"></asp:ListItem>
    </asp:DropDownList>
</div>
<div class="mb-3">
    <label class="form-label">Full name</label>
    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="mb-3">
    <label class="form-label">Username</label>
    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="mb-3">
    <label class="form-label">Password</label>
    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
</div>

<div class="mb-3">
    <label class="form-label">Contact number</label>
    <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="mb-3">
    <label class="form-label">Email</label>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="mb-3">
    <label class="form-label">Address</label>
    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<asp:Button ID="btnRegister" runat="server" Text="Create account" CssClass="btn-cb-primary w-100 mt-2" OnClick="btnRegister_Click" />

<p class="mt-3 text-center" style="color: var(--color-muted); font-size: 0.9rem;">
    Already have an account? <a href="~/Login.aspx" runat="server" style="color: var(--color-primary-dark); font-weight: 600;">Log in</a>
</p>
            </div>
        </div>
    </div>
</asp:Content>