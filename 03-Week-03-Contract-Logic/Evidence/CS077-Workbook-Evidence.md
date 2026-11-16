# CS077 Week 3 - Attention First Workbook Evidence

## SEEK Framework (Chapter 4: Story-Enhanced Exploration and Knowledge)

* **Audience/Runner:** Jane (Human Field Medic — Broken Reach medicine and seed courier)
* **Environment & Genre:** Mars / The Ossuary Belt — Sci-Fi Survival Horror
* **Discovery:** Amid the scorching dirt and rock wasteland of Mars, Jane intercepts a medical distress warrant from the trapped Dark Veil crew. However, the isolated sector makes incoming Martian relay signals conflicting and unreliable.
* **Stakes:** Delivering medical supplies and perimeter defense is critical to the Dark Veil crew's survival, but acting on a spoofed or tampered signal risks leading Jane into a creature ambush that could destroy their base.

---

## AAA Framework (Chapter 2: Application, Action, Amplification)

* **Application (Start with a usable base):** 
  Started the project by engaging with the workable WPF visual layout and XAML UI template for Jane's verification console before understanding all the underlying C# mechanics.
* **Action (Introduce concepts after experience):** 
  Programmed the C# `if / else-if / else` logic within the `EvaluateContract` method to connect the visual checkbox states (Timestamp, Identity, Source) to the functional `HOLD`, `REVIEW`, and `CLEAR` verdicts.
* **Amplification (Expand into deeper theory and transfer):** 
  Tested edge cases on the physical whiteboard decision map to ensure the logic was sound. Specifically, ensured that checking all three boxes still forces the `timestampConflict` to take top priority, safely returning a `HOLD` verdict to protect the runner.