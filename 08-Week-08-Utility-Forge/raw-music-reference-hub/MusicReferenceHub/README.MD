# Music Reference Hub - CS077 Utility Forge

A C#/.NET desktop music player utility designed for viewing metadata, managing audio tracks, and controlling media playback.

**Team Members:** Luisa, Pascual, Roman, Vinh, and Kevin

---

## 🚀 Features & Implementation

- **Metadata Reading & Media Control:** Integrated `TagLibSharp` via NuGet for reading embedded ID3 track metadata and album artwork.
- **Media Controls:** Custom playback interface inspired by Windows Media Player and VLC.
- **Interactive Cover Art:** Auto-loads cover images from track metadata with options to temporarily override artwork without permanently overwriting the file's original data.
- **Track Progress Control:** Custom progress slider inspired by YouTube/VLC playback UI.

---

## 🛠️ Built With

- **Language / Framework:** C# / .NET (Visual Studio 2022)
- **Dependencies:** `TagLibSharp` (NuGet Package)

---

## 📂 Project Structure & Key Files

- `raw-music-reference-hub/MusicReferenceHub/`: Core C# solution and project files.
- `CS077 Music Player Utility Demo Vid.mkv`: Recorded walk-through demonstration of the utility in action.
- `PATTERN.md`: Documentation covering selection validation patterns.

---

## ⚙️ Getting Started

1. **Clone the Repository:**
   ```bash
   git clone <https://github.com/saines007/CS077-Fall-2026-Team/tree/main>

2. Open the Solution: 
Open MusicReferenceHub.sln inside Visual Studio 2022.

3. Restore NuGet Packages:
Ensure TagLibSharp is restored by building the solution (Ctrl + Shift + B).

4. Run the Project:
Press F5 or click Start in Visual Studio.

---

## 🤖 AI Prompt Engineering Summary

- Prompt 1: Cover Image & Metadata Display
"Allow utilization of metadata from music file to display already included track cover image. Set the choose image button function to also be able to replace current cover image display with an image of user choice similar to current code, without permanently overwriting the track's own cover image from metadata."

- Prompt 2: Progress Slider
"Create progress slider for track similar to youtube/VLC/WMP."