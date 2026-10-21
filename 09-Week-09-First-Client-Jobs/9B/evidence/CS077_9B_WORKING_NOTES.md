# CS077 9B working notes

## start
What We Observed: We observed that we need to set up Visual Studio, create our project folder, and make sure we can access GitHub. We also learned that our project files and evidence need to be organized and kept free of private information.

What We Decided: We decided to use Visual Studio to build our WPF application and GitHub to save and share our work. We will keep our project and assignment evidence organized so our team can complete the client job.

What We Need to Ask: We need to ask our instructor for help if we have trouble setting up the project or accessing GitHub. We will also ask questions if we are unsure how to organize or submit our required files.

## brief
Client and User: We are creating RelayManifest for a relay supply clerk who needs to read and organize supply information. The clerk will use our app to check manifest entries and find mistakes.

Situation: We observed that the supply manifest is difficult to read and may contain incorrect information. We need to make the information clearer and easier to review.

Need: We need a simple app that opens a text manifest, checks for invalid rows, and displays accepted records. This will help the clerk identify problems and understand the supply information.

Actions: We will open, split, validate, display, filter, and export manifest records. These actions will help us organize the information and create a clear summary.

Variables/Types: We will use name (string), qty (int), priority (string), and highOnly (bool). These variables will store item names, quantities, priorities, and the high-priority filter setting.

Smallest Successful Output: We will create a working app that displays valid manifest records and flags invalid rows. It will also allow us to filter high-priority items and save a clear summary report.

## data
Today we use TXT files with delimiters because they are simple for reading, validating, and organizing relay supply manifest records. We should consider SQLite if we need structured data storage on one computer, or MySQL if multiple users need to access and share the data.

## project
What We Observed: We observed that Visual Studio creates the basic WPF project structure for our RelayManifest app. We learned that XAML controls the window layout and C# handles the app’s behavior.

What We Decided: We decided to create a project named RelayManifest using WPF and C#. We will use GitHub to save our progress and share our work with the instructor.

What We Need to Ask: We need to ask our instructor for help if we have trouble setting up the project or connecting GitHub. We will make sure our repository does not contain passwords or other private information.

## model
What We Observed: We observed that a class defines the information each manifest item stores, such as its name, quantity, and priority. We learned that a list holds multiple items and that invalid rows can be flagged with warnings.

What We Noted: We noted that our app checks item names, quantities, and priority levels before accepting manifest records. We also learned that separating data processing from the window makes our app easier to test and organize.

What We Need to Ask: We need to ask our client if there are any additional rules for valid supply items. We also need to confirm what information they want included in the final summary report.

## interface
What We Observed: We observed that XAML controls the layout and appearance of our RelayManifest window. We learned that the table can display item names, quantities, and priorities using data binding.

What We Noted: We noted that menus allow users to open manifests, filter high-priority items, and save summaries once the actions are connected. We also learned that status messages and warning boxes help users understand errors and results.

What We Need to Ask: We need to ask how to connect each menu option to its correct function. We also need to confirm how warnings should appear when the manifest contains invalid rows.

## wire
What We Observed: We observed that C# connects the menu options in our RelayManifest app to the code that runs when they are clicked. We learned that each menu option needs an event handler to respond to the user.

What We Noted: We noted that fields store information the app needs to remember, such as manifest items and the high-priority filter setting. We also learned that data binding displays item information, while click events trigger actions.

What We Need to Ask: We need to ask how to connect each menu option to its correct function without causing errors. We also need to know how to make the app open, filter, and save manifest information.

## load
What we observed: We saw how the app opens a text file, separates each row into name, quantity, and priority, and displays valid records. We also observed that invalid rows are skipped and listed as warnings.

What we decided: We decided to validate each row before displaying it so incorrect quantities or priorities are caught. We will keep the previous records if the file contains no valid rows.

What we need to ask: We need to ask what happens if the file cannot be opened or all rows are invalid. We also need to understand how warnings help us identify and fix skipped rows.

## finish
What we observed: We observed that the app can filter the manifest to show only HIGH priority records or display all records. We also saw how the Save feature creates a text summary of the visible records without changing the original file.

What we decided: We decided to keep filtering separate from the original data so no records are deleted when we change views. We will test saving, canceling, and error messages to make sure the client receives an accurate summary.

What we need to ask: We need to ask what should happen if there are no records to save or the save location is unavailable. We also need to confirm that the exported summary contains only the records currently visible in the app.

## test
My “Ask, Test, Explain: The Class Work” Notes

Input → Expected → Observed → Next step

- Input: We tested clean manifest data, invalid rows, missing fields, incorrect quantities, and bad priorities.
- Expected: We expected valid rows to appear in the table and invalid rows to be skipped with warning messages.
- Observed: We checked which records appeared and whether the warnings explained the problems.
- Next step: We will finish the remaining tests, verify the exported summary, and record our results in `tests.md`.

AI question → Test → Kept/Changed/Rejected

AI question:

I am a beginner building RelayManifest in C# WPF. Explain string.Split, int.TryParse and continue using one name|quantity|priority row. Name the exact file/method for parsing, show one valid and one invalid input, and give expected results. Do not rewrite my app. I will test your explanation.

AI response:

The parsing happens in `ManifestData.cs`, inside the `Parse` method.

- `string.Split('|')` separates a row into three fields: name, quantity, and priority.
- `int.TryParse()` checks whether the quantity is a valid whole number without crashing if the text is not numeric.
- `continue` skips the current invalid row and moves to the next line, allowing other valid rows to be processed.

Valid input:

`Relay batteries|4|HIGH`

Expected result: The row is accepted as an item with the name “Relay batteries,” quantity `4`, and priority `HIGH`.

Invalid input:

`Relay batteries|four|HIGH`

Expected result: The row is rejected because `four` is not a valid integer, and a warning is added for that line.

Test → We will use a copy of the manifest file, load both examples, and check the displayed records and warnings.

Kept/Changed/Rejected → We will keep the explanation if the program behaves as expected, change anything that does not match our observations, and reject suggestions that fail testing.

Peer check

We will have a partner trace one menu action through its event handler, data method, and output. We will share the tested action, observed result, and any unresolved question with our classmate or through the approved class communication method.

## submit
My Hand Off 9B / 15 Points Notes
Repository URL: https://github.com/saines007/CS077-Fall-2026-Team/tree/main/09-Week-09-First-Client-Jobs/9B
Receipt committed: Yes
Instructor access tested: Yes
Canvas submission confirmed: Yes