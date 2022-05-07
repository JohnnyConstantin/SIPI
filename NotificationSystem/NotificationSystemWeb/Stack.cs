namespace NotificationSystemWeb.Models;

public class Stack
{
    /// <summary>
    /// Stack is a model class.
    /// Description and Vulnerabilities fields are nullable.
    /// </summary>
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Description { get; set; }
    public int VulnerabilityId { get; set; }
    public List<Vulnerability>? Vulnerabilities { get; set; } = new();
}