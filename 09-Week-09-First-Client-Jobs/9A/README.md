# Dispatch Board Application

## User and Need
* **Target User:** Anyone needing a simple visual tool to organize and track tasks across pipeline stages (such as dispatchers managing account registration batches).
* **Core Need:** A clean, distraction-free board to view task progression, add new tasks, and move items across **To Do**, **In Progress**, and **Done** columns without complex menus or clutter.

## How to Open the Solution in Visual Studio
### Prerequisites
* **IDE:** Visual Studio 2022 (v17.8 or newer)
* **Workload:** .NET Desktop Development
* **Target Framework:** .NET 8.0 SDK

### Opening & Running
1. Clone or download the repository to your local directory.
2. Open **Visual Studio**.
3. Choose **File > Open > Project/Solution...**
4. Navigate to the project root and select `DispatchBoard.sln` (or `DispatchBoard.csproj` / `DispatchBoard.slnx`).
5. If Visual Studio opens in **Folder View**, click the **Switch between solutions and available views** toggle at the top of Solution Explorer and select `DispatchBoard.sln`.
6. Press `F5` (or click **Start Debugging**) to run the application.

## Data Format & Source
* **File Source:** `account-progress.json` (or loaded via file dialog using `TaskData.Parse`).
* **Model Binding:** Configured in `DispatchTask.cs` using `[JsonPropertyName]` attributes mapping `id` (int), `title` (string), and `completed` (bool).
* **Validation & Parsing Rules:** Handled by `TaskData.cs`. Input JSON must represent an array of 1 to 100 task objects. Each task requires a unique positive integer `Id` and a non-empty `Title`.

## Known Limitations
* **Strict Task Boundary:** TaskData.Parse() throws an InvalidDataException if the dataset contains 0 or more than 100 tasks.

* **Duplicate ID Guard:** Tasks with missing titles, non-positive integer IDs (Id <= 0), or duplicate IDs fail validation automatically.

* **Single-User Local Storage:** Direct JSON file I/O operations occur locally without cloud synchronization or multi-user file locking.
## Test Summary
* **Data Model & Parsing:** Verified DispatchTask JSON deserialization with [JsonPropertyName] mappings, including validation against duplicate IDs and zero/negative integer values.

* **Filtering Logic:** Verified TaskData.Select() accurately isolates incomplete (completed: false) vs. completed items.

* **Summary Formatting:** Verified TaskData.Summary() produces correct multi-line text outputs for export logging.
## Evidence
* **Source Files:** DispatchTask.cs, TaskData.cs, MainWindow.xaml, and MainWindow.xaml.cs

* **Design Artifacts & UX Flowcharts:** sections/TaskBoard.Prototype.pdf, sections/User-Logic.drawio, and Task_Board_Flowchart.pptx

* **Data File:** account-progress.json

* **Solution Setup:** DispatchBoard.sln and DispatchBoard.csproj
