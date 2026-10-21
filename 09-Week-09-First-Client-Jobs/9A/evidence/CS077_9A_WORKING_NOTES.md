# CS077 9A working notes

## start
What We Observed: We observed that our client is an Airbnb host who needs help managing guest check-in codes. We think assigning a unique code to each guest could help keep check-ins organized.

What We Decided: We decided to create a task board with To Do, In Progress, and Done sections to track guest check-in tasks. We also want to explore automatically assigning a different check-in code to each guest.

What We Need to Ask: We need to ask our client if they want each guest to receive an automatically generated check-in code. We also need to ask how and when the codes should be sent to guests.

## brief
Client and User: We are creating a task board for an Airbnb host to manage guest check-in tasks. The host will use it to track guests and automatically assign each one a different check-in code.

Situation: We need a way to keep track of which guests have been assigned check-in codes and which codes have been sent. This will help our client stay organized before guests arrive.

Need: We need a simple task board that shows which tasks are open, in progress, and completed. It should also help our client keep track of each guest’s unique check-in code.

Actions: We will load, display, filter, and export tasks. We will also explore generating a unique check-in code for each guest.

Variables/Types: We will use Id (int), Title (string), Completed (bool), and openOnly (bool) to identify tasks and track their status. We may also need a string variable to store each guest’s check-in code.

Smallest Successful Output: We will create a working task board that displays tasks, filters open tasks, and saves a report. It will also assign a different check-in code to each guest and track whether the code has been sent.

## data
Today we use JSON because it is simple and works well for storing and tracking guest check-in tasks and codes. We would consider SQLite if our client needed more organized data storage and MySQL if multiple users needed to access and manage shared information.

## project
What We Observed: We observed that Visual Studio creates the basic WPF project structure for our task board. We learned that XAML controls the window layout and C# handles the app’s behavior.

What We Decided: We decided to create a project named DispatchBoard using WPF and C#. We will use GitHub to save our progress and share our work with the instructor.

What We Need to Ask: We need to ask for help if we have trouble setting up the project or connecting GitHub. We will make sure not to include passwords or other private information in our repository.

## model
What We Observed: We observed that a class defines the information each task can hold, such as its ID, title, and completion status. We learned that a list can hold multiple tasks and help us organize guest check-in codes.

What We Noted: We noted that our task board needs to validate task information and filter completed or open tasks. We also learned that separating data from the window makes our app easier to organize and test.

What We Need to Ask: We need to ask our client what information should be stored for each guest and their check-in code. We also need to decide how we will handle missing or duplicate task information.

## interface
What We Observed: We observed that XAML is used to build the layout and appearance of our task board. We learned that buttons, labels, and a table help users see and organize tasks.

What We Noted: We noted that the table can display task IDs, titles, and completion status using data binding. We also learned that the buttons need code to work, which we will add later.

What We Need to Ask: We need to ask how to connect the buttons to the task board’s functions. We also need to know how to display guest check-in tasks and their assigned codes clearly.

## wire
What We Observed: We observed that C# connects the buttons in our task board to the code that runs when they are clicked. We learned that each button needs an event handler to respond to the user.

What We Noted: We noted that fields store information the app needs to remember, such as tasks and filter settings. We also learned that data binding displays task information, while click events trigger actions.

What We Need to Ask: We need to ask how to connect each button to its correct function without causing errors. We also need to know how to make the buttons load, filter, and save our guest check-in tasks.

## load
What We Observed: We observed that our app can load task information from online JSON or a saved JSON file. We learned that the app checks the data before displaying it to help prevent errors.

What We Decided: We decided to use async/await so the app stays responsive while loading tasks. We will also use validation and error messages to help our task board handle problems safely.

What We Need to Ask: We need to ask how to handle situations when the internet is unavailable or the JSON file is invalid. We also need to decide how we will store guest check-in codes in our task data.

## finish
What We Observed: We observed that our task board can filter open tasks and save the visible tasks to a text file. We learned that filtering changes what we see without deleting the original tasks.

What We Decided: We decided to let users switch between viewing all tasks and only open tasks. We will also save a summary report so our client can easily review guest check-in tasks.

What We Need to Ask: We need to ask our client what information they want included in the saved report. We also need to confirm how they want unique check-in codes assigned and tracked for each guest.

## test
Input → Expected → Observed → Next Step: We tested our task board using sample JSON data, including invalid or missing information, to check for errors. We expected valid tasks to display correctly and invalid data to show a warning, and our next step is to fix any issues we find.

AI Question → Test → Kept/Changed/Rejected: We asked AI how to check for invalid JSON and missing task titles before displaying the data. We will test the suggestion and decide whether to keep, change, or reject it based on the results.

Peer Check: We asked a teammate to test the task board and check if its buttons and task list work correctly. We will use their feedback to fix problems and improve the app.

## submit
Repository URL: We submitted our project to GitHub in the 09-Week-09-First-Client-Jobs folder. Our repository link is https://github.com/saines007/CS077-Fall-2026-Team/tree/main/09-Week-09-First-Client-Jobs.

Confirmed Receipt: We completed and saved our project receipt. We included the required project files and documentation on GitHub.

Instructor Can Access and Test: We made our project available on GitHub so our instructor can access and test it. Our repository contains the source code and project files for review.

Canvas Submission Confirmed: We submitted our GitHub repository link through Canvas for Action 9A. We confirmed that our submission was turned in.