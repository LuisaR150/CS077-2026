# CS077 Week 3 — Contract Verification Console (`Jane` // The Ossuary Belt)

> A C# WPF desktop application built for CS077 Week 3 (*Contract Logic: The Impossible Warrant*). This console evaluates three evidence states—**Timestamp Conflict**, **Identity Confirmed**, and **Source Verified**—and returns a traceable **HOLD**, **REVIEW**, or **CLEAR** verdict for Field Medic **Jane** on Mars.

---

## 📖 Runner & Mission Summary (SEEK)

* **Runner:** Jane (Human Field Medic — Broken Reach medicine & seed courier)
* **Location & Genre:** Mars / The Ossuary Belt — Sci-Fi Survival Horror
* **Strength & Limitation:** Repairs damaged equipment quickly, but replacement parts and power are scarce.
* **Discovery:** Amid the scorching dirt and rock wasteland of Mars, Jane intercepts an emergency contract for the injured Dark Veil crew, complicated by isolated and unreliable Martian relay signals.
* **What Is at Stake:** Delivering medical aid and perimeter defense is critical to the Dark Veil crew's survival, but acting on a spoofed signal risks leading Jane into a creature raid that destroys their base.

---

## ⚙️ Decision Logic & Pseudocode

```text
FUNCTION EvaluateContract(timestampConflict, identityConfirmed, sourceVerified):
    IF timestampConflict IS TRUE THEN
        RETURN "HOLD"
    ELSE IF identityConfirmed IS FALSE OR sourceVerified IS FALSE THEN
        RETURN "REVIEW"
    ELSE
        RETURN "CLEAR"
    END IF
END FUNCTION
```

---

## 🧪 Verification Test Results (RR6)

| Conflict (`TimestampConflict`) | Identity (`IdentityConfirmed`) | Source (`SourceVerified`) | Expected | Observed | Status |
| :--- | :--- | :--- | :--- | :--- | :--- |
| Yes (`Checked`) | Yes (`Checked`) | Yes (`Checked`) | **HOLD** | **HOLD** | ✅ Pass |
| No (`Unchecked`) | No (`Unchecked`) | Yes (`Checked`) | **REVIEW** | **REVIEW** | ✅ Pass |
| No (`Unchecked`) | Yes (`Checked`) | Yes (`Checked`) | **CLEAR** | **CLEAR** | ✅ Pass |

*(Screenshots of all observed verdicts are saved in the `Evidence/` folder.)*

---

## 🤖 AI Verification Record (RR7)

* **Focused Question Submitted:** 
  > *"In C# WPF, why should `if (timestampConflict)` be checked before `else if (!identityConfirmed || !sourceVerified)` inside `EvaluateContract`, and how does separating `EvaluateContract` from `ExplainVerdict` improve maintainability?"*
* **Verification & Check:** Cross-referenced against Microsoft's C# Selection Statements (`if-else`) and C# Methods documentation, and tested all checkbox combinations in the running WPF window. Confirmed that checking `timestampConflict` first guarantees any tampered or conflicting timestamp immediately triggers `HOLD` even if identity and source boxes are checked.
* **Decision:** **KEPT & INTEGRATED** into `MainWindow.xaml.cs`.

---

## 👥 Collaboration & Peer Feedback (RR7)

* **Whiteboard Challenge & Revision:** During the Action 3A whiteboard mapping session, a teammate challenged the edge case where all three checkboxes are checked simultaneously (`Conflict = Yes`, `Identity = Yes`, `Source = Yes`). We updated our decision map and `if / else-if / else` order so `timestampConflict` takes top priority and always forces `HOLD` rather than allowing `CLEAR`.
* **Discord Peer Test:** Shared the repository link in the CS077 Discord channel for peer verification; confirmed the WPF project builds cleanly in Visual Studio and produces `HOLD`, `REVIEW`, and `CLEAR` accurately.

---

## 🎨 Assets & Image Credits

* `Assets/CS077-Mission-Reference.png` — Course-provided starter reference artwork.
* `Assets/CS077-Runner-Story-Brief.pdf` — Completed runner profile and SEEK story brief.

---

## 📁 Evidence Checklist (`Evidence/`)

* `Evidence/CS077-WHITEBOARD.jpeg` — Whiteboard decision map and planning photograph
* `Evidence/CS077-CAPTURE-NOT-TESTED.PNG` — Screenshot of the initial application state
* `Evidence/CS077-CAPTURE-HOLD.PNG` — Screenshot of the WPF verification test returning HOLD
* `Evidence/CS077-CAPTURE-REVIEW.PNG` — Screenshot of the WPF verification test returning REVIEW
* `Evidence/CS077-CAPTURE-CLEAR.PNG` — Screenshot of the WPF verification test returning CLEAR
* `Evidence/CS077-Workbook-Evidence.md` — Digital SEEK and AAA workbook evidence
