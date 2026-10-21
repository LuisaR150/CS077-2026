RelayManifest — 9B Brief
Project Overview

Client job: Relay Manifest File Desk
Purpose: Build a WPF desktop application that opens a text manifest, validates its rows, displays accepted records, identifies invalid rows, filters high-priority items, and saves a summary.

User need: The relay supply clerk needs an easy way to read a text manifest, identify incorrect entries, and produce a clear report without changing the original file.

Client Requirements
Open a text manifest using the File menu.
Split each row into name, quantity, and priority.
Validate input and show line-number warnings for invalid rows.
Display accepted records in a table.
Filter records to show only HIGH priority or all records.
Save a summary of the currently visible records.
Keep the original input file unchanged.
Provide File, View, and Help menus.
Technology and Data
Language: C#
Framework: WPF with modern .NET
Interface: XAML and C# code-behind
Data format: Plain text using name|quantity|priority
Data class: ManifestItem
Parsing class: ManifestData
Parsing method: ManifestData.Parse
Filtering method: ManifestData.Select
Summary method: ManifestData.Summary
Validation Rules
Each data row must contain exactly three fields.
Name cannot be empty.
Quantity must be a whole number from 1 to 500.
Priority must be HIGH or NORMAL.
Blank lines and lines starting with # are ignored.
Invalid rows are skipped and reported with their line numbers.
Visual, Logical, and Data Decisions

Visual: We use a dark window, a menu bar, a records table, a status message, and a warnings area to keep the interface readable.

Logical: Menu actions call event handlers. The handlers open files, change the filter, save summaries, exit the application, or display information.

Data: We use a List<ManifestItem> to hold accepted records and a separate list of warnings to explain rejected rows.

Implementation Summary

The project was created as a new WPF application named RelayManifest.

MainWindow.xaml defines the interface and its menu commands.
MainWindow.xaml.cs connects menu events to the application logic.
ManifestItem.cs defines a manifest record and the parsing result.
ManifestData.cs parses, validates, filters, and summarizes records.

The app uses OpenFileDialog to select input and SaveFileDialog to select an output location. It reads input asynchronously and writes a separate text summary.

Testing Notes

The expected clean sample contains three valid records. The HIGH priority filter should display two records, and the exported summary should report seven visible units.

Tests include:

Clean input.
Two valid and three invalid rows.
A non-numeric quantity.
A missing field.
An unknown priority.
An all-invalid file.
Blank and comment lines.
Canceling the file picker.
Saving before loading data.
Filtering HIGH priority and checking the exported total.

Test results should be recorded using:

Input → Expected → Observed → Next step

Screenshots should show the running application, accepted records, validation warnings, and a saved summary.

AI Verification

AI question:

I am a beginner building RelayManifest in C# WPF. Explain string.Split, int.TryParse and continue using one name|quantity|priority row. Name the exact file/method for parsing, show one valid and one invalid input, and give expected results. Do not rewrite my app. I will test your explanation.

Response summary:

The parsing occurs in ManifestData.cs, inside ManifestData.Parse.

string.Split('|') separates the row into fields.
int.TryParse() checks whether the quantity is a valid whole number.
continue skips the current invalid row and proceeds to the next row.

Valid example: Relay batteries|4|HIGH should be accepted.

Invalid example: Relay batteries|four|HIGH should be rejected because the quantity is not numeric, and a warning should be generated.

Decision: We will compare these expected results with the actual program, then record what we kept, changed, or rejected.

Data Storage Decision

Today, a plain-text manifest is sufficient because the application only needs to read, validate, filter, and export records.

We should consider SQLite if the client needs durable local records, repeated updates, or structured queries. We should consider MySQL if multiple users need shared, centrally managed data.

Assignment 9B — Five Required Items

Each requirement is worth 3 points, for a total of 15 points.

R1 — Plan a different client job: Save the brief and prototype, include File, View, and Help menus in the design, draw the valid/rejected-row flowchart, and keep class notes and a concise Discord peer check.
R2 — Build a second blank WPF project: Create RelayManifest and implement text-file reading, parsing, validation, accepted records, line-number warnings, HIGH filtering, and summary export.
R3 — Test and explain: Capture the interface, accepted records, warnings, and saved summary. Test invalid input, cancellation, and no-data cases. Explain arrays, loops, TryParse, and return.
R4 — Check AI and the three hats: Record the AI question, test, and keep/change/reject decision. Explain one Visual, Logical, and Data decision and the choice between text files and a database.
R5 — Submit the second handoff: Commit and push the project and required evidence, include the receipt, test instructor access, and submit the GitHub URL to Canvas Action 9B before the deadline.
Repository and Submission

GitHub repository:

https://github.com/saines007/CS077-Fall-2026-Team/tree/main/09-Week-09-First-Client-Jobs/9B

Handoff checklist:

Commit and push the project and required files.
Include the 9B receipt and evidence.
Check that the instructor can access the repository.
Submit the GitHub URL to Canvas Action 9B.
Confirm that Canvas records the submission.
Keep the 9A evidence unchanged.

Do not commit bin/, obj/, .vs/, passwords, tokens, or other secrets.

Evidence and Documentation

Keep the required handoff files together as directed by the instructor. Include the brief, prototype, whiteboard/flowchart, lecture notes, peer check, test results, running/output screenshots, AI verification, and receipt. Keep input files in SampleData/ and generated summaries in the designated output location.

Notes and Follow-up

We prepared notes for the client brief, data structure, visible window, event connections, file parsing, filtering/export, testing, AI verification, and final handoff.

Any untested behavior should remain marked as needing verification rather than being reported as complete. The receipt records our declarations; it does not independently prove attendance, application correctness, or instructor acceptance.
