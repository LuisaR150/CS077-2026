# PATTERN.md

## Reusable Pattern: Validate a Selection Before Acting

### Purpose

Check that the user has selected a valid item before performing an action. This prevents the app from opening a link when no link is selected.

### Where It Is Used

In `MainWindow.xaml.cs`, the `OpenSelectedLink()` method checks the selected item in the `lstLinks` ListBox before opening the link.

### Example

```csharp
if (lstLinks.SelectedItem is not string selectedLink)
{
    txtStatus.Text = "Please select a link first.";
    return;
}
```

### How It Works

- `lstLinks` is the ListBox containing the saved links.
- `SelectedItem` returns the currently selected item. It can be `null` when nothing is selected.
- `is not string selectedLink` checks whether the selected item is a string. If it is, the value is stored in the local variable `selectedLink`.
- `txtStatus.Text` displays a message when no valid link is selected.
- `return` exits the method immediately, preventing the remaining code from opening a link.

### Related UI Event

The `Window_MouseDown` event handler clears the selected link when the user clicks outside the links ListBox.

```csharp
private void Window_MouseDown(object sender, MouseButtonEventArgs e)
{
    if (!lstLinks.IsMouseOver)
    {
        lstLinks.SelectedItem = null;
    }
}
```

The event handler is connected in `MainWindow.xaml` using `MouseDown="Window_MouseDown"`.

This allows the selection validation to work when the user clicks elsewhere in the window.

### Test

1. Add a valid URL to the list.
2. Select the URL and click Open Selected Link. Confirm that it opens in the browser.
3. Click outside the links ListBox.
4. Click Open Selected Link again.

**Expected result:** The browser does not open the previous URL, and the app asks the user to select a link first.

### Reusing This Pattern

Use this pattern whenever an action depends on a selected item. Validate the selection before performing the action, show a clear message if the selection is missing or invalid, and use `return` to prevent the action from continuing.

This helps prevent errors and makes the application easier to use.
