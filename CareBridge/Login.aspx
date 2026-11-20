<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CareBridge.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="cb-auth-wrap">
        <div class="cb-auth-brand" style="background-image: linear-gradient(160deg, rgba(18,174,196,0.90) 0%, rgba(12,147,166,0.94) 100%), url('https://images.unsplash.com/photo-1576091160399-112ba8d25d1d?auto=format&fit=crop&w=900&q=80'); background-size: cover; background-position: center;">
            <div class="cb-eyebrow-pill" style="background-color: rgba(255,255,255,0.18); color: #FFFFFF; width: fit-content;">● 5 roles, 1 login</div>
            <h2>Welcome back.</h2>
            <p>Log in to pick up where you left off, whether that's an appointment, a prescription, or a report waiting for you.</p>
        </div>
        <div class="cb-auth-form">
            <div class="cb-auth-card">
               <h3 class="mb-4">Log in</h3>
<asp:Label ID="lblMessage" runat="server" CssClass="text-danger d-block mb-3" Text=""></asp:Label>

<div class="mb-3">
    <label class="form-label">Username</label>
    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
</div>

<div class="mb-3">
    <label class="form-label">Password</label>
    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
</div>

<asp:Button ID="btnLogin" runat="server" Text="Log in" CssClass="btn-cb-primary w-100 mt-2" OnClick="btnLogin_Click" />

<p class="mt-3 text-center" style="color: var(--color-muted); font-size: 0.9rem;">
    Don't have an account? <a href="~/Register.aspx" runat="server" style="color: var(--color-primary-dark); font-weight: 600;">Register</a>
</p>
            </div>
        </div>
    </div>
</asp:Content>