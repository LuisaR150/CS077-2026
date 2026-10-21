namespace RelayManifest;

public static class ManifestData
{
    public static ParseResult Parse(string[] lines)
    {
        var result = new ParseResult();
        for (int index = 0; index < lines.Length; index++)
        {
            string line = lines[index].Trim();
            if (line.Length == 0 || line.StartsWith("#")) continue;
            string[] parts = line.Split('|');
            if (parts.Length != 3)
            {
                result.Warnings.Add($"Line {index + 1}: use 3 fields.");
                continue;
            }
            string name = parts[0].Trim();
            string priority = parts[2].Trim().ToUpperInvariant();
            bool validNumber = int.TryParse(parts[1].Trim(), out int qty);
            if (name.Length == 0 || !validNumber || qty < 1 || qty > 9001 ||
                (priority != "HIGH" && priority != "NORMAL"))
            {
                result.Warnings.Add($"Line {index + 1}: check name, " +
                    "quantity 1-9001 and HIGH/NORMAL.");
                continue;
            }
            result.Items.Add(new ManifestItem
            {
                Name = name,
                Quantity = qty,
                Priority = priority
            });
        }
        return result;
    }

    public static List<ManifestItem> Select(
        List<ManifestItem> items, bool highOnly)
    {
        var visible = new List<ManifestItem>();
        foreach (var item in items)
            if (!highOnly || item.Priority == "HIGH") visible.Add(item);
        return visible;
    }

    public static string Summary(List<ManifestItem> items)
    {
        var lines = new List<string> { "RELAY MANIFEST SUMMARY" };
        int total = 0;
        foreach (var item in items)
        {
            total += item.Quantity;
            lines.Add($"{item.Name} | {item.Quantity} | {item.Priority}");
        }
        lines.Add($"Total visible units: {total}");
        return string.Join(Environment.NewLine, lines);
    }
}