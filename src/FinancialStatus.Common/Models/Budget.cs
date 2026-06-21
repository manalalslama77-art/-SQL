namespace FinancialStatus.Common.Models;

public class Budget
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public decimal Amount { get; set; }
    public BudgetLevel Level { get; set; }
    public int? ParentId { get; set; }
    public Budget? Parent { get; set; }
    public List<Budget> Children { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Notes { get; set; }
    public bool IsActive { get; set; } = true;
}
