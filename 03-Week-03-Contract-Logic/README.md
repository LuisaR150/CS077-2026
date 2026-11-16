# CS077 Week 3 — Contract Verification Console (`Jane` // The Ossuary Belt)

A C# WPF desktop application built for CS077 Week 3 (*Contract Logic: The Impossible Warrant*). This console evaluates three evidence states—**Timestamp Conflict**, **Identity Confirmed**, and **Source Verified**—and returns a traceable **HOLD**, **REVIEW**, or **CLEAR** verdict for Field Medic **Jane** on Mars.

---

## Runner & Mission Summary (SEEK)

* **Runner:** Jane (Human Field Medic — Broken Reach medicine & seed courier)
* **Location & Genre:** Mars / The Ossuary Belt — Sci-Fi Survival Horror
* **Strength & Limitation:** Repairs damaged equipment quickly, but replacement parts and power are scarce.
* **Discovery:** Amid the scorching dirt and rock wasteland of Mars, Jane intercepts an emergency contract for the injured Dark Veil crew, complicated by isolated and unreliable Martian relay signals.
* **What Is at Stake:** Delivering medical aid and perimeter defense is critical to the Dark Veil crew's survival, but acting on a spoofed signal risks leading Jane into a creature raid that destroys their base.

---

## Decision Logic & Pseudocode

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
