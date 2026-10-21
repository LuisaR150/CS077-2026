namespace RelayManifest;

public class ManifestItem
{
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public string Priority { get; set; } = "NORMAL";
}

public class ParseResult
{
    public List<ManifestItem> Items { get; } = new();
    public List<string> Warnings { get; } = new();
}