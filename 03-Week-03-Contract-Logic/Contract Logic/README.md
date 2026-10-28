# CS077 Week 3 — Your runner's contract console

This is a WPF desktop project for Visual Studio on Windows, not Visual Studio Code or a web page. Install the .NET desktop development workload and .NET 8 support.

## Start

1. Unzip the whole folder into your local Week 3 workspace.
2. Open CS077.ContractVerification.csproj in Visual Studio.
3. Run it. The button always returns REVIEW until you replace the placeholder in EvaluateContract. This is intentional.
4. Use Git > Create Git Repository to preserve this starting point.

## Action 3A — Story, map, interface

Use Context on the Week 3 site to choose a location and genre and create an original runner. Export the story brief into Evidence. Complete the assigned Attention First SEEK and AAA work in your own copy; add the completed forms to Evidence.

With your group, map HOLD / REVIEW / CLEAR on the whiteboard. Photograph the map. Customize MissionTitle, RunnerName, RunnerRole, DiscoveryText, and StoryConsequence in MainWindow.xaml.

Add your original character or mission illustration to Assets and update MissionImage's Source. PNG files in Assets are included as WPF resources by this project. If using another format, set its Build Action to Resource in Properties. Keep text readable. The provided mission-reference.png is AI-generated course reference artwork, not your original character submission. Credit image sources and tools in your README.

## Action 3B — Conditions, functions, verification

Replace the placeholder return in EvaluateContract with if / else-if / else:

- Timestamp conflict: HOLD, regardless of the other inputs.
- No conflict, but identity or source verification missing: REVIEW.
- No conflict and both checks verified: CLEAR.

Keep the button event, EvaluateContract, and ExplainVerdict separate. Rewrite ExplainVerdict so each status describes your runner's next action. CLEAR confirms these evidence checks, not guilt.

## Preserve evidence

Create an Evidence folder. Keep the story brief, Attention First forms, whiteboard photo, illustration/source notes, and screenshots of all three tests there.

| Conflict | Identity | Source | Expected | Observed |
| --- | --- | --- | --- | --- |
| Yes | Yes | Yes | HOLD | |
| No | No | Yes | REVIEW | |
| No | Yes | Yes | CLEAR | |

Record your required AI question, the check you performed, and what you accepted or rejected. Share the repository in Discord, record a peer test, and preserve your revision.

Commit and push the complete source and evidence through Visual Studio. Test the repository's access, then submit its link in the Week 3 Canvas assignment. Check all R1–R8 requirements on the site. A download or self-check is not a submission.
