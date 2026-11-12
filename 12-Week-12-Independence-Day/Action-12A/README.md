# 🐈 Pilot Cat — Action 12A: Independence Day

[![Engine](https://img.shields.io/badge/Engine-Unity%206%20%28URP%29-blue.svg)](https://unity.com/)
[![Course](https://img.shields.io/badge/Course-CS077%20Action%2012A-orange.svg)]()
[![Status](https://img.shields.io/badge/Pipeline-Action%2013A%20Prep-green.svg)]()
[![Team](https://img.shields.io/badge/Team-Gateroller-purple.svg)]()

> **Project:** Pilot Cat  
> **Team:** Gateroller (Vinh — Lead, Pascual — Coordinator, Luisa, Roman)  
> **Course:** CS077 — Action 12A: Independence Day  
> **Due Date:** Monday, November 9, 2026 at 12:35 PM Pacific  

---

## 🐾 1. Game Overview & Backstory

**Pilot Cat** is an original side-scroller game developed by the **Gateroller** team, born from a collaborative 10-minute whiteboard brainstorming session during Action 11B. Moving away from the *VOID RUNNERS* framework, the team built an original world, character concept, and central conflict.

### The Story
Duke (known as **Pilot Cat**) is one of the most infamous felines in Catlandia. Under the tutelage of the legendary ace *"Trigger"* from Strangereal (by request of Rose), Duke became an expert aviator. He operates as an international Cat Nip smuggler flying across the Catlantic into Catmerica.

Despite being relentlessly pursued by the **Watch Dogs Order** and the International Cat Police, Duke stays true to his feline roots. He loves three things above all else:
1. **Sleeping**
2. **Flying**
3. **His precious Cat Nip**

*Behind the scenes:* Though branded a criminal, Duke operates anonymous charity accounts to fund local orphanages across Settaria—making him a hidden role model to the youth he supports.

### Fictional World Reference

| Location / Element | Category | Description |
| :--- | :--- | :--- |
| **Settaria** | World | The overarching fictional world containing all continents and oceans. |
| **Catlandia** | Continent | Duke the Pilot Cat's home continent and primary base of operation. |
| **Catlantic** | Environment | The vast ocean Duke navigates while smuggling cargo. |
| **Viridescent Claw** | Vehicle | Duke's custom vintage biplane used for aerial maneuvering. |
| **Watch Dogs Order** | Faction / Enemy | The international police authority pursuing Duke. |
| **Cat Nip** | Item / Resource | The central high-value product driving the game's narrative conflict. |

---

## 👥 2. Team & Working Arrangements

* **Team Name:** Gateroller (Gaterollin)
* **Team Lead:** Vinh
* **Coordinator:** Pascual
* **Team Members:** Luisa, Pascual, Roman, Vinh

### Course Requirement Index (R1–R4 Ownership)

| Req | Focus | Owner | Core Contribution |
| :---: | :--- | :--- | :--- |
| **R1** | Entire Pipeline & Story Concept | All Members | Created original Pilot Cat story, character design, and world lore during 11B. |
| **R2** | Attention First Pipelines | All Members | Structured documentation into Pipelines 01–04 per Chapter 3 standards. |
| **R3** | Video & Engine Evidence | All Members | Completed 9 video logs, Unity Play Mode screenshots, and project logs. |
| **R4** | Story Development | Luisa | Led character narrative refinement and GDD documentation entries. |
| **R4** | Team Coordination | Pascual | Managed task delegation, whiteboard evidence, and repository structure. |
| **R4** | Story & Evidence Logs | Roman | Compiled evidence tables, Discord records, and scene metadata. |
| **R4** | Team Leadership | Vinh | Directed overall technical architecture and Unity movement integration. |
| **R5** | AI Verification & Next Plan | Every Learner | Executed C# code verification, documentation checks, and 13A test roadmap. |
| **R6** | Personal GitHub Handoff | Every Learner | Pushed complete repository, evidence folder, and Canvas receipt submission. |

---

## 🏭 3. Production Pipelines (Attention First Standard)

Per **R2 standards**, documentation is organized around four distinct production pipelines.

### Pipeline 01 / Story and Player Plan
* **Goal:** Establish original game narrative, player identity, and intended gameplay loop.
* **Input:** Action 11B Attention Accord, team whiteboard, and Discord planning.
* **Actions & Data Mapping:**

```
  [ Player Input ] ──► [ Player Mover Script ] ──► [ Viridescent Claw Transform ]
                              │
                              ▼
                  [ Position / Altitude Data ] ──► [ Game Boundaries Check ]
```

* **Finished Output:** Backstory, character concept, player goals, and world parameters.
* **Testing & Evidence:** Whiteboard screenshots, Attention Accord, and team Discord records.

### Pipeline 02 / Scene, Assets and Game Design
* **Goal:** Translate lore into visual Unity engine structures and organized folder hierarchies.
* **Input:** Pipeline 01 backstory and entity requirements.
* **Repository Architecture:**

```text
PilotCat/
├── Assets/
│   ├── Audio/
│   ├── Materials/
│   ├── Models/         <-- Duke & Viridescent Claw assets
│   ├── Prefabs/
│   ├── Scenes/         <-- MainScene.unity
│   ├── Scripts/        <-- PlayerMover.cs, GameManager.cs
│   ├── Textures/
│   └── UI/
├── Evidence/           <-- R6 Submission screenshots & receipts
├── Next-Class Plan/    <-- NEXT_CLASS_PLAN.md
└── README.md
```

* **Finished Output:** Formalized GDD, Unity project tree, and scene layout plan.

### Pipeline 03 / Behavior, Gameplay and C#
* **Goal:** Implement flight mechanics and event handling via Unity C# MonoBehaviours.
* **Input:** Pipeline 02 project structure, scenes, and imported 3D models.
* **Core Movement Implementation (`PlayerMover.cs`):**

```csharp
using UnityEngine;

/// <summary>
/// Controls constant forward velocity and vertical altitude shifts for Duke's biplane.
/// </summary>
public class PlayerMover : MonoBehaviour
{
    [Header("Flight Parameters")]
    [Tooltip("Forward velocity in units per second.")]
    public float forwardSpeed = 12.0f;

    [Tooltip("Vertical ascent/descent speed.")]
    public float verticalSpeed = 8.0f;

    void Update()
    {
        // 1. Maintain constant forward movement along Z-axis
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // 2. Process vertical pitch control from Vertical axis (W/S or Arrow Keys)
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * verticalSpeed * Time.deltaTime);
    }
}
```

* **Finished Output:** Functional Unity scene featuring playable aircraft movement.
* **Testing & Evidence:** Play Mode runtime screenshots and verified transform values in the Inspector.

### Pipeline 04 / Testing, Documentation and Release
* **Goal:** Validate gameplay systems, compile evidence, and execute individual GitHub handoff.
* **Input:** Pipeline 03 functional project build.
* **QA Test Matrix Summary:**

| TC # | Test Area | Procedure | Expected Result | Result |
| :---: | :--- | :--- | :--- | :---: |
| **TC-01** | Scene Load | Launch `MainScene.unity` in Play Mode. | Engine loads without console errors. | **N/A** |
| **TC-02** | Movement | Apply `W` / `S` vertical input keys. | Plane shifts altitude smoothly along Y-axis. | **N/A** |
| **TC-03** | Texture Check | Inspect biplane mesh in Game View. | UV materials render without pink missing-shader fallbacks. | **N/A** |
| **TC-04** | Frame Timing | Measure movement across fluctuating frame rates. | `Time.deltaTime` prevents physics warping. | **N/A** |

---

## 🎬 4. Required Tutorial Video Log (Videos 1–9)

| # | Video Title | Target Focus | Output / Evidence |
| :---: | :--- | :--- | :--- |
| **1** | Game Development Intro | Lore & Player Goal | Documented story, Duke's identity, and Catlandia background. |
| **2** | Dev Mindset & Planning | Gateroller Workflow | Established team pipeline communication and task ownership. |
| **3** | Folders & Setup | Project Architecture | Initialized Unity project structure and saved Git checkpoints. |
| **4** | Documentation | GDD Formulation | Built comprehensive Game Design Document (`CS077_GDD_PILOT_CAT.md`). |
| **5** | Unity Editor Overview | Scene Hierarchy | Configured GameObjects, cameras, lighting, and basic transforms. |
| **6** | Custom Player Import | Asset Pipeline | Imported 3D player stand-in into `MainScene.unity`. |
| **7** | Blender 3D Workflow | Asset Creation | Modeled/processed biplane geometry for engine export. |
| **8** | Textures & Materials | Visual Shaders | Applied diffuse maps and textures to biplane model. |
| **9** | C# Scripting & Logic | Player Movement | Authored `PlayerMover.cs` and verified runtime response. |

---

## 🤖 5. Required AI Interaction & Code Verification (R5)

* **Prompt Submitted:**  
  > *"Explain a small C# Unity player movement script for our Pilot Cat game. Identify the class, variables, methods, properties, and input or lifecycle events. Explain how the behavior connects to the Unity GameObject and suggest one practical test to verify that the player responds correctly to input."*

* **Technical Verification Record:**
  * **Claim Checked:** `transform.Translate(Vector3.forward * speed * Time.deltaTime)` ensures frame-rate-independent movement.
  * **Documentation Source:** Verified against official Unity `Transform.Translate` and `Time.deltaTime` API documentation.
  * **Test Outcome:** Applied vertical input during Play Mode execution. Object transformed along the Y-axis smoothly without jitter.
  * **Decision:** **KEPT**. Code integrated into `PlayerMover.cs`.

---

## 📋 6. R1–R6 Checklist

- [] **R1:** Completed all 9 tutorial video entries and engine tasks.
- [x] **R2:** Applied Attention First pipeline structure (Pipelines 01–04).
- [] **R3:** Archived screenshots, C# scripts, and QA test matrices.
- [x] **R4:** Documented individual task ownership across all Gateroller team members.
- [] **R5:** Verified AI C# claims against Unity documentation and included Next-Class Plan.
- [x] **R6:** Committed project files to individual GitHub repository and verified Canvas URL submission.

---

*Pilot Cat — A Gateroller Original.*  
*"Meow!" 🐈✈️*