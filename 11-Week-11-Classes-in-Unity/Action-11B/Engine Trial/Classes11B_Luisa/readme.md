# Action 11B: Unity Player & Beacon Interaction

## Overview

This repository contains the completed **Action 11B** assignment for `Classes11B_Luisa`. It demonstrates core C# object-oriented programming concepts in Unity by linking a custom 3D character (`PlayerMover.cs`) to an interactive environmental object (`StoryBeacon.cs`).

## Technical Features & Setup

* **Engine / Pipeline:** Unity 6 using the Universal Render Pipeline (URP).
* **Player Character:** Replaced the default 3D capsule runner with a custom 3D Neko Cat prefab (`Neko Cat Free Edition`).
* **Movement Logic:** `PlayerMover.cs` handles character controller input (WASD/Arrow keys) and distance checks relative to the target beacon.
* **Interactive Beacon:** `StoryBeacon.cs` dynamically converts and instantiates URP Lit shaders (`Universal Render Pipeline/Lit`), changing the beacon's material color from magenta to cyan upon user activation (`E` key).

## How to Run & Test

1. Clone the team repository and pull the latest changes from `main`.
2. Open the Unity project inside `Classes11B_Luisa/project/`.
3. Open `Assets/Scenes/VoidRunners11B.unity`.
4. Press **Play**.
5. Use **WASD** to move the cat character near the beacon and press **E** to activate it. Confirm the beacon turns cyan and prints the activation message in the Console.