RelayManifest — Tests and AI Verification
1. Input → Expected → Observed → Next Step
Test 1: Clean manifest file
Input: Relay batteries|4|HIGH and other valid manifest rows.
Expected: The app accepts valid records and displays their name, quantity, and priority.
Observed: We identified the expected behavior from the ManifestData.Parse logic. Valid rows are added to the accepted records list.
Next step: Test invalid quantities and missing fields.
Test 2: Invalid quantity
Input: Relay batteries|four|HIGH
Expected: The app rejects the row because the quantity is not an integer and displays a warning with the line number.
Observed: We discussed how int.TryParse checks the quantity without crashing and how the parser records a warning for an invalid row.
Next step: Test a row with a missing field.
Test 3: Missing field
Input: Relay batteries|4
Expected: The row is rejected because the format requires three fields separated by |.
Observed: We discussed how string.Split('|') separates the fields and how the parser checks that exactly three fields exist.
Next step: Test an unknown priority.
Test 4: Unknown priority
Input: Relay batteries|4|URGENT
Expected: The row is rejected because the allowed priorities are HIGH and NORMAL.
Observed: We identified the priority validation rule in ManifestData.Parse.
Next step: Test a file containing only invalid rows.
Test 5: All-invalid file
Input: A manifest containing only invalid rows.
Expected: The app displays a message that no valid rows were found and keeps the previous list.
Observed: We reviewed the Open_Click logic, which checks parsed.Items.Count before replacing the existing list.
Next step: Confirm the behavior with an all-invalid sample file.
Test 6: Blank lines and comments
Input: A file containing blank lines, a line beginning with #, and a valid record.
Expected: Blank lines and comments are ignored; the valid record is accepted.
Observed: We identified the parsing rules that skip blank lines and comments.
Next step: Test cancelling the file picker.
Test 7: Cancel opening a file
Input: Open the file picker and select Cancel.
Expected: The app returns without loading a file or replacing the current list.
Observed: We reviewed the early return in Open_Click.
Next step: Test saving before loading records.
Test 8: Save before loading
Input: Choose File > Save visible summary before opening a manifest.
Expected: The app displays a no-data message and does not create an empty summary.
Observed: We reviewed the check for an empty visible list in Save_Click.
Next step: Test filtering and exporting.
Test 9: HIGH filter and summary
Input: Load the clean sample containing three records, then choose View > High priority.
Expected: Two HIGH-priority records appear. Saving the visible summary produces a report with a total of 7 units.
Observed: We reviewed how ManifestData.Select chooses visible records and ManifestData.Summary creates the report.
Next step: Choose View > All records and confirm that all three records return.
2. AI Question → Test → Kept / Changed / Rejected
AI question

I am a beginner building RelayManifest in C# WPF. Explain string.Split, int.TryParse and continue using one name|quantity|priority row. Name the exact file/method for parsing, show one valid and one invalid input, and give expected results. Do not rewrite my app. I will test your explanation.

AI response summary

In ManifestData.cs, the ManifestData.Parse method processes the manifest one line at a time. string.Split('|') separates a row into fields. int.TryParse checks whether the quantity is a valid integer. If a row fails validation, continue skips that row and moves to the next one.

Valid input: Relay batteries|4|HIGH

Expected result: The parser creates a ManifestItem with the name Relay batteries, quantity 4, and priority HIGH.

Invalid input: Relay batteries|four|HIGH

Expected result: The quantity cannot be parsed as an integer. The row is skipped and a warning identifies its line number.

Test and decision
Test: Compare the valid and invalid examples against the validation conditions in ManifestData.Parse.
Kept: The explanation of Split, TryParse, and continue, because it matches the intended parsing logic.
Changed: No code changes were proposed by this explanation.
Rejected: Rewriting the whole application was unnecessary because the question requested a focused explanation.

Verification status: We reviewed the expected outcomes from the supplied code and examples. Actual execution should be confirmed in the running app.

3. Peer Check
Tested action: Reviewed the planned flow from opening a manifest to displaying records and saving a summary.
Observed result: The code separates file reading, validation, filtering, and summary creation into different methods.
Unresolved question: Does the running application display every warning and preserve the previous list for every invalid-input case?
Next step: Verify the remaining cases in the app and record any differences.
4. Overall Notes

We worked through the RelayManifest project plan, data structures, WPF window, event connections, file parsing, filtering, saving, AI verification, and handoff requirements.

The main pattern is:

Open → Parse → Validate → Display → Filter → Export

The original input file should remain unchanged when a summary is saved. The final report contains the selected visible records rather than modifying the source manifest.

Status: These notes summarize the intended behavior and hypothetical work discussed. They do not claim that every test was physically run or that the instructor has verified the application.
