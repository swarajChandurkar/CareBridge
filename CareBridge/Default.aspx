<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CareBridge.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <section class="cb-hero2">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-6">
                    <div class="cb-eyebrow-pill">● Now live across 5 connected roles</div>
                    <h1>Healthcare that finally moves as one system.</h1>
                    <p class="lead">CareBridge brings patients, hospitals, doctors, labs and medical stores onto a single platform, so an appointment, a prescription, and a lab report never get stuck between departments.</p>
                    <div class="cb-hero2-ctas">
                        <a href="~/Register.aspx" runat="server" class="btn-cb-primary d-inline-block">Get started free</a>
                        <a href="~/About.aspx" runat="server" class="cb-link-ghost">See how it works →</a>
                    </div>
                </div>

                <div class="col-lg-6 mt-5 mt-lg-0">
    <div class="cb-mock-wrap">
        <div class="cb-blob-decor"></div>

        <img src="https://images.unsplash.com/photo-1550831107-1553da8c8464?auto=format&fit=crop&w=400&q=80"
             alt="Doctor"
             style="position:absolute; top:-40px; left:-30px; width:120px; height:120px; border-radius:50%; object-fit:cover; border:5px solid #FFFFFF; box-shadow: var(--shadow-md); z-index:3;" />

        <div class="cb-floating-badge top-right">
            <div>
                <div class="cb-badge-num">98%</div>
                <div class="cb-badge-label">On-time reports</div>
            </div>
        </div>

        <div class="cb-mock-card">
            <h4 style="font-size: 0.95rem; margin-bottom: 14px;">Today's appointments</h4>
            <div class="cb-mock-row">
                <div class="cb-mock-avatar"></div>
                <div>
                    <div class="cb-mock-line-primary">Aarav Mehta</div>
                    <div class="cb-mock-line-secondary">Dr. Anjali Mehta — 10:30 AM</div>
                </div>
                <div class="cb-mock-status">Confirmed</div>
            </div>
            <div class="cb-mock-row">
                <div class="cb-mock-avatar"></div>
                <div>
                    <div class="cb-mock-line-primary">Priya Singh</div>
                    <div class="cb-mock-line-secondary">Dr. Ravi Sharma — 11:15 AM</div>
                </div>
                <div class="cb-mock-status">Pending</div>
            </div>
            <div class="cb-mock-row">
                <div class="cb-mock-avatar"></div>
                <div>
                    <div class="cb-mock-line-primary">Karan Patel</div>
                    <div class="cb-mock-line-secondary">Dr. Sameer Kapoor — 1:00 PM</div>
                </div>
                <div class="cb-mock-status">Confirmed</div>
            </div>
        </div>

        <div class="cb-floating-badge bottom-left">
            <div>
                <div class="cb-badge-num">13</div>
                <div class="cb-badge-label">Specializations covered</div>
            </div>
        </div>
    </div>
</div>
            </div>
        </div>
    </section>

<section class="cb-stats-strip">
    <div class="container">
        <div class="cb-grid-4">
            <div class="cb-stat-block">
                <div class="cb-stat-num">5</div>
                <div class="cb-stat-caption">Connected roles</div>
            </div>
            <div class="cb-stat-block">
                <div class="cb-stat-num">13+</div>
                <div class="cb-stat-caption">Specializations</div>
            </div>
            <div class="cb-stat-block">
                <div class="cb-stat-num">0</div>
                <div class="cb-stat-caption">Paperwork required</div>
            </div>
            <div class="cb-stat-block">
                <div class="cb-stat-num">1</div>
                <div class="cb-stat-caption">Login for everything</div>
            </div>
        </div>
    </div>
</section>

    <section class="cb-role-section">
        <div class="container">
            <h2 class="mb-2" style="font-size:1.7rem;">Everything under one roof</h2>
            <p class="mb-5" style="color: var(--color-muted); max-width: 520px;">Every part of the visit, from booking to billing, lives in the same system.</p>

            <div class="row g-3">
                <div class="col-md-4 col-sm-6">
                    <div class="cb-role-card">
                        <div class="cb-feature-icon">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="8" r="4"/><path d="M4 21c0-4 4-6 8-6s8 2 8 6"/></svg>
                        </div>
                        <h4>Patients</h4>
                        <p>Enter symptoms, get matched to the right doctor, and download prescriptions and reports afterward.</p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="cb-role-card">
                        <div class="cb-feature-icon">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M3 21h18M5 21V7l7-4 7 4v14M9 21v-6h6v6"/></svg>
                        </div>
                        <h4>Hospitals</h4>
                        <p>Manage doctors, labs and medical stores under one roof, and see every appointment in one view.</p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="cb-role-card">
                        <div class="cb-feature-icon">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M4.5 4.5l4 4M19.5 4.5l-4 4M12 2v5M6 21h12l-1.5-7h-9L6 21z"/></svg>
                        </div>
                        <h4>Doctors</h4>
                        <p>Set availability, review history, write prescriptions, and request lab tests from one dashboard.</p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="cb-role-card">
                        <div class="cb-feature-icon">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2v6L4 20a1 1 0 001 1h14a1 1 0 001-1L15 8V2M9 2h6"/></svg>
                        </div>
                        <h4>Labs</h4>
                        <p>Get incoming test requests, track status, and upload reports patients see instantly.</p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="cb-role-card">
                        <div class="cb-feature-icon">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 2h6v4H9z"/><path d="M9 6H5v16h14V6h-4M9 12h6M9 16h6"/></svg>
                        </div>
                        <h4>Medical Stores</h4>
                        <p>Receive prescriptions directly, price them out, and print a bill. No stock paperwork involved.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="cb-role-section" style="padding-top: 0;">
    <div class="container">
        <div class="row align-items-center g-5">
            <div class="col-lg-6">
                <img src="https://images.unsplash.com/photo-1576091160399-112ba8d25d1d?auto=format&fit=crop&w=800&q=80"
                     alt="Hospital team"
                     style="width:100%; border-radius: 20px; box-shadow: var(--shadow-md);" />
            </div>
            <div class="col-lg-6">
                <h2 style="font-size:1.7rem;" class="mb-3">Built for how care actually happens</h2>
                <p style="color: var(--color-muted); line-height:1.7; margin-bottom:20px;">
                    Every hospital already has doctors, labs, and a pharmacy nearby, they just don't share one system. CareBridge doesn't replace how your hospital works, it just gives everyone in that chain the same real-time picture.
                </p>
                <a href="~/Register.aspx" runat="server" class="btn-cb-primary d-inline-block">Get started</a>
            </div>
        </div>
    </div>
</section>

    <section class="container">
        <div class="cb-cta-banner">
            <h2>Ready to bring your hospital onto CareBridge?</h2>
            <p>Set up your hospital account and start adding doctors in minutes.</p>
            <a href="~/Register.aspx" runat="server" class="btn-cb-primary d-inline-block">Create your account</a>
        </div>
    </section>



</asp:Content>