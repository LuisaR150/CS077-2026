# PILOT CAT — GAME DEVELOPMENT DOCUMENT (GDD) 

**Course:** CS077 — Action 12A: Independence Day  
**Team Name:** Gateroller / Gaterollin  
**Contributors:** Luisa, Pascual, Roman, Vinh  
**Team Lead:** Vinh | **Coordinator:** Pascual  

---

## 🖼️ VISUAL ARTWORK & CONCEPT SHOWCASE

| FIGURE 1: DUKE PORTRAIT | FIGURE 2: SIDE-SCROLLER GAMEPLAY |
| :---: | :---: |
| <img width="169" height="168" alt="CS077_DUKE_PORTRAIT" src="https://github.com/user-attachments/assets/c88887f9-5d68-4862-a6c6-5f807d574e3f" /> | <img width="626" height="352" alt="CS077_SIDE_SCROLLER_GAMEPLAY" src="https://github.com/user-attachments/assets/99751aa2-2d7d-484a-a82c-98c7cb5dd158" /> |
| **Duke "Pilot Cat"** *(Rogue Smuggler with a Heart of Gold)* | **3D Side-Scroller Flight & Collectibles** |

---

## 📌 TABLE OF CONTENTS
1. [Game Overview & Narrative](#1-game-overview--narrative)
2. [Gameplay Mechanics & Controls](#2-gameplay-mechanics--controls)
3. [Level Design & Technical Architecture](#3-level-design--technical-architecture)
4. [Testing & Quality Assurance](#4-testing--quality-assurance)
5. [Team Matrix & Evidence Appendices](#5-team-matrix--evidence-appendices)

---

## 1. GAME OVERVIEW & NARRATIVE

### 1.1 Premise & Vision
*Pilot Cat* is an original 3D side-scrolling arcade action game built in **Unity 6 (URP)**. Evolved from our Action 11B whiteboard planning, the game features **Duke "Pilot Cat"**, an ace aviator flying his biplane (*The Viridescent Claw*) across the floating sky islands of **Catlandia**.

### 1.2 Story & Lore
Trained by the legendary pilot "Trigger" from Strangereal, Duke operates as an independent aviator delivering vital Cat Nip supplies while evading the oppressive **Watch Dogs Order**. Though labeled a rogue by the dog police, Duke uses his earnings to anonymously support youth orphanages across Settaria.

* **Genre:** 3D Arcade Side-Scroller / Flight Action
* **Target Audience:** Casual gamers and arcade flight fans
* **Engine / Stack:** Unity 6 (6000.0.7f1) | URP | C# | Blender 3D

---

## 2. GAMEPLAY MECHANICS & CONTROLS

### 2.1 Core Gameplay Loop
```
[ Launch Level ] ➔ [ Navigate Skyways ] ➔ [ Collect Cat Nip ] ➔ [ Dodge Hazards ] ➔ [ Reach Extraction Beacon ]
```

### 2.2 Player Controls
| Control Input | In-Game Action | Engine Mechanics / Logic |
| :--- | :--- | :--- |
| **W / Up Arrow** | Ascend Aircraft | Translates Y-axis (+Transform.up * speed) |
| **S / Down Arrow** | Descend Aircraft | Translates Y-axis (-Transform.up * speed) |
| **A / D Keys** | Pitch / Roll Adjustment | Modifies Z-axis tilt rotation |
| **Spacebar** | Engine Boost | Temporarily increases forward velocity |

---

## 3. LEVEL DESIGN & TECHNICAL ARCHITECTURE

### 3.1 Scene Hierarchy (`MainScene.unity`)
* **Environment:** Skybox, directional lighting, cloud layers, terrain floating islands.
* **Player:** `PilotCat_Aircraft` GameObject with Rigidbody and `PlayerMover.cs` script.
* **Collectibles:** Floating Cat Nip gems with `SphereCollider` set to `Is Trigger`.
* **System:** Main Camera follow script and Audio Systems.

### 3.2 C# Player Movement Script (`PlayerMover.cs`)
```csharp
using UnityEngine;

public class PlayerMover : MonoBehaviour 
{
    [Header("Flight Parameters")]
    public float forwardSpeed = 12.0f;
    public float verticalSpeed = 8.0f;
    
    [Header("Audio Settings")]
    public AudioSource pickupAudio;

    void Update() 
    {
        // Continuous forward flight
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Vertical movement control
        float vInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * vInput * verticalSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("CatNip")) 
        {
            if (pickupAudio != null) pickupAudio.Play();
            Destroy(other.gameObject);
        }
    }
}
```

---

## 4. TESTING & QUALITY ASSURANCE

| Test ID | Component | Expected Result | Observed Result | Status |
| :---: | :--- | :--- | :--- | :---: |
| **TC-01** | Project Launch | Loads `MainScene` without errors | Loaded cleanly with zero warnings | **N/A** |
| **TC-02** | Flight Input | W/S keys adjust vertical position | Smooth vertical movement response | **N/A** |
| **TC-03** | Item Collision | Pickup destroys Cat Nip & plays audio | Trigger activated and object destroyed | **N/A** |
| **TC-04** | URP Shader | 3D models render textures cleanly | Fixed pink shaders using URP Lit material | **N/A** |

---

## 5. TEAM MATRIX & EVIDENCE APPENDICES

### 5.1 Production Team Roles & Ownership
| Contributor | Role | Deliverables & Responsibilities |
| :--- | :--- | :--- |
| **Vinh** | Team Lead | C# Engine architecture, Unity project setup, build sync |
| **Pascual** | Coordinator | Task tracking, whiteboard facilitation, Git repo initialization |
| **Luisa** | Support Lead | Story development, narrative lore, Attention Accord docs |
| **Roman** | Support Lead | Story evidence documentation, video learning records, QA checks |
| **User (You)** | Pipeline Owner | Code synchronization, Markdown GDD formatting, Git handoff |

### 5.2 AI Assistance & Verification (Course Requirement R5)
* **Prompt Submitted:** *"Explain a small C# Unity player movement script for our Pilot Cat game. Identify the class, variables, methods, properties, and input events."*
* **Verification Check:** Verified `Input.GetAxis("Vertical")` against official Unity API documentation. Confirmed that returning values between `-1.0` and `1.0` matches engine behavior.
* **Status:** **VERIFIED & ACTIVE** in `PlayerMover.cs`.

---

## 📁 APPENDICES

* **Appendix A – Whiteboard Planning:** Collaborative planning based on *Attention First* principles.  
  👉 [View Whiteboard Evidence](https://github.com/saines007/CS077-Fall-2026-Team/tree/main/12-Week-12-Independence-Day/Action-12A/Evidence)
* **Appendix B – Workflow & Pipeline Structure:** Pre-planning ➔ Whiteboard Session ➔ Task Delegation ➔ Working Checkpoint Loops.
* **Appendix C – Credits & References:** Character concept and third-party asset credits.  
  👉 [View Credits Page](https://github.com/saines007/CS077-Fall-2026-Team/blob/main/12-Week-12-Independence-Day/Action-12A/CREDITS.md)
* **Appendix D – Screenshots & Media:** Play Mode tests, inspector setups, and console logs.
