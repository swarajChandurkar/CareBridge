<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CareBridge.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="cb-hero" style="padding-bottom: 30px;">
        <div class="row align-items-center">
            <div class="col-lg-7">
                <div class="cb-eyebrow-pill">● Our story</div>
                <h1 style="font-size: 2.2rem;">Why we built CareBridge.</h1>
                <p class="lead">
                    Healthcare runs on five separate parties who rarely talk to each other directly: patients, hospitals, doctors, labs, and medical stores. A prescription gets handed over on paper. A lab report sits in a drawer. An appointment gets confirmed over a phone call nobody wrote down. CareBridge puts all five in one place so information moves as fast as care should.
                </p>
            </div>
            <div class="col-lg-5 mt-4 mt-lg-0">
                <img src="https://images.unsplash.com/photo-1666214280391-8ff5bd3c0bf0?auto=format&fit=crop&w=700&q=80"
                     alt="Medical team collaborating"
                     style="width:100%; height: 320px; object-fit: cover; border-radius: 20px; box-shadow: var(--shadow-md);" />
            </div>
        </div>
    </section>

    <section class="cb-role-section" style="padding-top: 0;">
        <div class="container-fluid px-0">
            <h2 class="mb-4" style="font-size:1.4rem;">How the pieces connect</h2>
            <div class="row g-3 mb-5">
                <div class="col-md-6">
                    <div class="cb-role-card">
                        <div class="cb-feature-icon">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M9 12h6M12 9v6"/><circle cx="12" cy="12" r="9"/></svg>
                        </div>
                        <h4>One record, not five</h4>
                        <p>A patient's appointment, prescription, and lab report all trace back to the same visit, so nothing gets lost between departments or handed off on paper.</p>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="cb-role-card">
                        <div class="cb-feature-icon">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="4" width="18" height="16" rx="2"/><path d="M3 9h18M8 4v3M16 4v3"/></svg>
                        </div>
                        <h4>Built around real roles</h4>
                        <p>Each side of the system, patient, hospital, doctor, lab, and store, gets its own dashboard built around what that role actually needs to do, not a generic one-size-fits-all screen.</p>
                    </div>
                </div>
            </div>

            <h2 class="mb-2" style="font-size:1.4rem;">What you can do here</h2>
            <p class="mb-4" style="color: var(--color-muted); max-width: 520px;">Every role gets a workflow built for exactly what it needs to do.</p>
            <div class="row g-3">
                <div class="col-md-4 col-sm-6">
                    <div class="cb-role-card">
                        <div class="cb-feature-icon">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="8" r="4"/><path d="M4 21c0-4 4-6 8-6s8 2 8 6"/></svg>
                        </div>
                        <h4>As a patient</h4>
                        <p>Describe your symptoms, get matched to a doctor, book the appointment, and pick up your prescription and lab report from the same account afterward.</p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="cb-role-card">
                        <div class="cb-feature-icon">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M3 21h18M5 21V7l7-4 7 4v14M9 21v-6h6v6"/></svg>
                        </div>
                        <h4>As a hospital</h4>
                        <p>Bring your doctors, labs, and medical stores onto one platform and see every appointment happening under your roof in one view.</p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6">
                    <div class="cb-role-card">
                        <div class="cb-feature-icon">
                            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M4.5 4.5l4 4M19.5 4.5l-4 4M12 2v5M6 21h12l-1.5-7h-9L6 21z"/></svg>
                        </div>
                        <h4>As a doctor, lab, or store</h4>
                        <p>Doctors write prescriptions and request tests. Labs upload results the moment they're ready. Stores bill a prescription and print it, no stock paperwork involved.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>