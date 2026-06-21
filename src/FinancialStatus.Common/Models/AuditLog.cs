namespace FinancialStatus.Common.Models;

public class AuditLog
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string Action { get; set; }
    public required string EntityType { get; set; }
    public int? EntityId { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? IpAddress { get; set; }
}
