RelayManifest Application
User and Need

Target User: A relay supply clerk who needs a simple way to read, organize, and review supply manifest records.

Core Need: A clear, easy-to-use WPF application that opens text-based supply manifests, validates each row, displays accepted records, identifies invalid entries, filters high-priority items, and exports a readable summary report.

The application will help the clerk find mistakes in supply information and review valid records without manually checking every line of a text file.

How to Open the Solution in Visual Studio
Prerequisites
IDE: Visual Studio 2022
Workload: .NET Desktop Development
Framework: A compatible .NET version supported by the project
Language and UI: C# and Windows Presentation Foundation (WPF)
Source Control: GitHub for storing and sharing project files
Opening and Running
Clone or download the RelayManifest repository to your local computer.
Open Visual Studio.
Select File > Open > Project/Solution.
Navigate to the RelayManifest project folder.
Open the solution file (RelayManifest.sln), if available, or the project file (RelayManifest.csproj).
Restore any required dependencies and verify that the correct project is selected as the startup project.
Press F5 or select Start Debugging to run the application.
Data Format and Source

File Source: A text manifest file containing supply records separated by the pipe (|) character.

Record Format: Each row should contain three fields in this order:

name|quantity|priority

Example:

Relay batteries|4|HIGH

Data Model: Each accepted manifest record stores:

name — a string containing the supply item's name.
qty — an integer representing the item quantity.
priority — a string identifying the item's priority level.
highOnly — a Boolean controlling whether only high-priority records are displayed.

Parsing and Validation: The ManifestData.cs file contains the Parse method, which splits each row using string.Split('|') and checks the fields before accepting the record. The quantity is validated using int.TryParse(). Invalid rows are skipped with continue and reported through warnings.

Validation should check that item names are not empty, quantities follow the agreed rules, and priority values match the accepted priority levels. The exact quantity limits and priority rules should be confirmed with the client.

Main Features
Open Manifest: Load a text file through a file-selection dialog.
Parse Records: Separate each row into item name, quantity, and priority.
Validate Input: Accept valid records and flag invalid rows with helpful warnings.
Display Records: Show accepted manifest entries in a table using WPF data binding.
Filter Records: Display only HIGH priority items or return to the complete list without deleting data.
Export Summary: Save a text report containing the records currently visible in the application.
Display Status Messages: Help the user understand loading results, validation problems, and save errors.
Error Handling and Data Integrity

The application should handle missing fields, empty item names, incorrect quantities, invalid priorities, and rows with the wrong number of delimiters.

Invalid rows should be skipped and reported so the user can identify problems in the original manifest. If a file cannot be opened or contains no valid records, the application should display a useful message and preserve the previously loaded records when appropriate.

Filtering must not delete or overwrite the original records. Exporting a summary should create a separate output file and leave the original manifest unchanged.

Data Storage Decisions

Current Format: Delimited TXT files are used because they are simple to read, parse, validate, and organize.

Possible Future Improvements:

SQLite: A suitable option if structured local storage and more advanced queries become necessary.
MySQL: A possible option if multiple users need to access and share centralized data.

For the current project, text files provide a straightforward starting point without requiring a database server.

Test Summary

Data Parsing and Validation: Test clean records, empty fields, missing fields, extra fields, incorrect quantities, and invalid priorities.

Filtering Logic: Verify that the high-priority filter displays only HIGH records and that switching back to all records restores the complete accepted list.

File Loading: Test valid files, files containing invalid rows, files with no valid records, missing files, and file-access errors.

Summary Export: Confirm that the exported report includes the currently visible records, uses readable formatting, and does not modify the source manifest.

User Interface and Event Handling: Verify that menu options invoke the correct event handlers and that status messages and warnings are understandable.

Evidence and Documentation: Record test inputs, expected results, observed results, and next steps in tests.md.

Known Limitations and Questions
The application currently uses a text-based manifest format rather than a database.
The accepted priority values and quantity restrictions must be confirmed with the client.
The behavior when all rows are invalid or no records are available to export must be tested.
Save-location errors and canceled file dialogs need to be handled correctly.
The application is intended to provide local file processing; shared, multi-user data management is not currently established.
The final report format and the exact information required by the client still need confirmation.
Project Evidence

The project evidence should include the source files, sample manifest data, testing documentation, and relevant design artifacts.

Expected files include:

ManifestData.cs — manifest parsing and validation.
The manifest item model class — stores item names, quantities, and priorities.
MainWindow.xaml — defines the WPF interface.
MainWindow.xaml.cs — connects user actions to application behavior.
A sample manifest TXT file — provides test data.
tests.md — documents test inputs, expected results, observed results, and next steps.
Project and solution files — support opening and running the application in Visual Studio.

The exact filenames should match those in the actual repository.

Project Setup and Submission

The project is managed through GitHub so the team can save progress, share code, and provide instructor access. Repository files and assignment evidence should remain organized and must not contain passwords or other private information.

The working notes indicate that the repository URL has been recorded, the receipt has been committed, instructor access has been tested, and Canvas submission has been confirmed.

Repository: https://github.com/saines007/CS077-Fall-2026-Team/tree/main/09-Week-09-First-Client-Jobs/9B

Smallest Successful Outcome

The minimum successful version of RelayManifest will open a text manifest, display valid supply records, flag invalid rows, filter HIGH priority items, and save a readable summary of the records currently visible. Testing results will be documented so the team can explain how the application works and demonstrate that its behavior matches the requirements.
