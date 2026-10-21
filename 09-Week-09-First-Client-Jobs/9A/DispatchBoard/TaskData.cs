using System.Text.Json;
using System.IO;

namespace DispatchBoard;

public static class TaskData
{
    public static List<DispatchTask> Parse(string json)
    {
        // Turn JSON text into C# objects; validate before display.
        var tasks = JsonSerializer.Deserialize<List<DispatchTask>>(json);
        if (tasks == null || tasks.Count == 0 || tasks.Count > 100)
            throw new InvalidDataException("Use 1 to 100 tasks.");

        var ids = new HashSet<int>();
        foreach (var task in tasks)
        {
            if (task == null || task.Id <= 0 ||
                string.IsNullOrWhiteSpace(task.Title) ||
                !ids.Add(task.Id))
                throw new InvalidDataException("Check task IDs and titles.");
        }
        return tasks;
    }

    public static List<DispatchTask> Select(
        List<DispatchTask> tasks, bool openOnly)
    {
        var visible = new List<DispatchTask>();
        foreach (var task in tasks)
        {
            if (!openOnly || !task.Completed)
                visible.Add(task);
        }
        return visible;
    }

    public static string Summary(List<DispatchTask> tasks)
    {
        var lines = new List<string> { "TRAINING TASK SUMMARY" };
        foreach (var task in tasks)
            lines.Add($"{task.Id}: {task.Title} | Done: {task.Completed}");
        return string.Join(Environment.NewLine, lines);
    }
}