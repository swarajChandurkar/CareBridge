<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/Patient.Master" AutoEventWireup="true" CodeBehind="Enter_Symptoms.aspx.cs" Inherits="CareBridge.Patient.Enter_Symptoms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cb-topbar">
        <h1>Enter your symptoms</h1>
        <p>Select what you're experiencing and we'll match you to the right doctor.</p>
    </div>

    <style>
        .cb-symptom-hero {
            background: linear-gradient(135deg, var(--color-primary) 0%, var(--color-primary-dark) 100%);
            border-radius: 20px;
            padding: 34px 36px;
            color: #fff;
            position: relative;
            overflow: hidden;
            margin-bottom: 24px;
        }
        .cb-symptom-hero::after {
            content: "";
            position: absolute;
            width: 220px; height: 220px;
            border-radius: 50%;
            background: rgba(255,255,255,0.08);
            top: -80px; right: -60px;
        }
        .cb-symptom-hero h1 { color: #fff; font-size: 1.4rem; margin-bottom: 6px; position: relative; }
        .cb-symptom-hero p { color: rgba(255,255,255,0.85); margin: 0; max-width: 520px; position: relative; }

        .cb-symptom-searchbar {
            display: flex;
            align-items: center;
            gap: 10px;
            background: #fff;
            border: 1px solid var(--color-border);
            border-radius: 30px;
            padding: 12px 20px;
            max-width: 420px;
            margin-bottom: 22px;
            box-shadow: var(--shadow-sm);
        }
        .cb-symptom-searchbar svg { width: 18px; height: 18px; color: var(--color-muted); flex-shrink: 0; }
        .cb-symptom-searchbar input {
            border: none; outline: none; font-size: 0.92rem; width: 100%; background: transparent; color: var(--color-text);
        }

        /* Chip-style checkbox list, overrides the default grid card look */
        .cb-symptom-grid.cb-chip-mode {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
            list-style: none;
            padding: 0; margin: 0;
        }
        .cb-symptom-grid.cb-chip-mode li {
            border: 1.5px solid var(--color-border);
            border-radius: 24px;
            background-color: #fff;
            padding: 9px 8px 9px 8px;
            display: flex;
            align-items: center;
            gap: 8px;
            transition: all 0.15s ease;
            cursor: pointer;
        }
        .cb-symptom-grid.cb-chip-mode li:hover {
            border-color: var(--color-primary);
        }
        .cb-symptom-grid.cb-chip-mode li:has(input:checked) {
            background-color: var(--color-primary);
            border-color: var(--color-primary);
        }
        .cb-symptom-grid.cb-chip-mode li:has(input:checked) label {
            color: #fff;
        }
        .cb-symptom-grid.cb-chip-mode input[type="checkbox"] {
            display: none;
        }
        .cb-symptom-grid.cb-chip-mode label {
            font-size: 0.87rem;
            font-weight: 600;
            color: var(--color-text);
            cursor: pointer;
            padding: 0 6px;
            white-space: nowrap;
        }
        .cb-symptom-grid.cb-chip-mode li.cb-chip-hidden {
            display: none;
        }

        .cb-symptom-footer {
            position: sticky;
            bottom: 16px;
            margin-top: 26px;
            background: #fff;
            border: 1px solid var(--color-border);
            box-shadow: var(--shadow-md);
            border-radius: 16px;
            padding: 16px 22px;
            display: flex;
            align-items: center;
            justify-content: space-between;
            max-width: 900px;
        }
        .cb-symptom-count {
            font-size: 0.9rem;
            color: var(--color-muted);
        }
        .cb-symptom-count span {
            color: var(--color-primary-dark);
            font-weight: 700;
            font-size: 1.05rem;
        }
    </style>

    <div class="cb-content">

        <div class="cb-symptom-hero">
            <h1>What's bothering you today?</h1>
            <p>Search or scroll to find what you're feeling — pick as many as apply, then we'll match you to the right doctor.</p>
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger d-block mb-3" Text=""></asp:Label>

        <div class="cb-symptom-searchbar">
            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="11" cy="11" r="7"/><path d="M21 21l-4-4"/></svg>
            <input type="text" id="symptomSearch" placeholder="Search symptoms, e.g. 'cough' or 'joint pain'" />
        </div>

        <div style="max-width: 900px;" id="symptomWrap">
            <asp:CheckBoxList ID="cblSymptoms" runat="server" CssClass="cb-symptom-grid cb-chip-mode" RepeatLayout="UnorderedList">
                <asp:ListItem Text="Fever" Value="fever"></asp:ListItem>
                <asp:ListItem Text="Cold" Value="cold"></asp:ListItem>
                <asp:ListItem Text="Cough" Value="cough"></asp:ListItem>
                <asp:ListItem Text="Fatigue" Value="fatigue"></asp:ListItem>
                <asp:ListItem Text="Body ache" Value="body ache"></asp:ListItem>
                <asp:ListItem Text="Headache" Value="headache"></asp:ListItem>
                <asp:ListItem Text="Migraine" Value="migraine"></asp:ListItem>
                <asp:ListItem Text="Dizziness" Value="dizziness"></asp:ListItem>
                <asp:ListItem Text="Numbness" Value="numbness"></asp:ListItem>
                <asp:ListItem Text="Chest pain" Value="chest pain"></asp:ListItem>
                <asp:ListItem Text="Palpitations" Value="palpitations"></asp:ListItem>
                <asp:ListItem Text="Breathlessness" Value="breathlessness"></asp:ListItem>
                <asp:ListItem Text="Wheezing" Value="wheezing"></asp:ListItem>
                <asp:ListItem Text="Chronic cough" Value="chronic cough"></asp:ListItem>
                <asp:ListItem Text="Rash" Value="rash"></asp:ListItem>
                <asp:ListItem Text="Itching" Value="itching"></asp:ListItem>
                <asp:ListItem Text="Acne" Value="acne"></asp:ListItem>
                <asp:ListItem Text="Hair fall" Value="hair fall"></asp:ListItem>
                <asp:ListItem Text="Joint pain" Value="joint pain"></asp:ListItem>
                <asp:ListItem Text="Back pain" Value="back pain"></asp:ListItem>
                <asp:ListItem Text="Muscle pain" Value="muscle pain"></asp:ListItem>
                <asp:ListItem Text="Fracture" Value="fracture"></asp:ListItem>
                <asp:ListItem Text="Ear pain" Value="ear pain"></asp:ListItem>
                <asp:ListItem Text="Sore throat" Value="sore throat"></asp:ListItem>
                <asp:ListItem Text="Sinus congestion" Value="sinus"></asp:ListItem>
                <asp:ListItem Text="Hearing loss" Value="hearing loss"></asp:ListItem>
                <asp:ListItem Text="Stomach pain" Value="stomach pain"></asp:ListItem>
                <asp:ListItem Text="Acidity" Value="acidity"></asp:ListItem>
                <asp:ListItem Text="Vomiting" Value="vomiting"></asp:ListItem>
                <asp:ListItem Text="Diarrhea" Value="diarrhea"></asp:ListItem>
                <asp:ListItem Text="Eye pain" Value="eye pain"></asp:ListItem>
                <asp:ListItem Text="Blurred vision" Value="blurred vision"></asp:ListItem>
                <asp:ListItem Text="Red or itchy eyes" Value="red eyes"></asp:ListItem>
                <asp:ListItem Text="Tooth pain" Value="tooth pain"></asp:ListItem>
                <asp:ListItem Text="Gum bleeding" Value="gum bleeding"></asp:ListItem>
                <asp:ListItem Text="Anxiety" Value="anxiety"></asp:ListItem>
                <asp:ListItem Text="Insomnia" Value="insomnia"></asp:ListItem>
                <asp:ListItem Text="Frequent urination" Value="frequent urination"></asp:ListItem>
                <asp:ListItem Text="Urinary pain" Value="urinary pain"></asp:ListItem>
                <asp:ListItem Text="Excessive thirst" Value="excessive thirst"></asp:ListItem>
                <asp:ListItem Text="Irregular periods" Value="irregular periods"></asp:ListItem>
                <asp:ListItem Text="Pelvic pain" Value="pelvic pain"></asp:ListItem>
            </asp:CheckBoxList>
        </div>

        <div class="cb-symptom-footer">
            <div class="cb-symptom-count"><span id="symptomCounter">0</span> symptoms selected</div>
            <asp:Button ID="btnFindDoctor" runat="server" Text="Find a doctor" CssClass="btn-cb-primary" OnClick="btnFindDoctor_Click" />
        </div>
    </div>

    <script>
        (function () {
            var wrap = document.getElementById("symptomWrap");
            var search = document.getElementById("symptomSearch");
            var counter = document.getElementById("symptomCounter");
            if (!wrap) return;

            var items = wrap.querySelectorAll(".cb-symptom-grid li");

            function updateCounter() {
                var checked = wrap.querySelectorAll("input[type=checkbox]:checked").length;
                counter.textContent = checked;
            }

            search.addEventListener("input", function () {
                var q = search.value.trim().toLowerCase();
                items.forEach(function (li) {
                    var text = li.textContent.trim().toLowerCase();
                    li.classList.toggle("cb-chip-hidden", q.length > 0 && text.indexOf(q) === -1);
                });
            });

            wrap.addEventListener("change", function (e) {
                if (e.target && e.target.type === "checkbox") updateCounter();
            });

            updateCounter();
        })();
    </script>

</asp:Content>