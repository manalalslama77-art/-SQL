namespace FinancialStatus.Common.Models;

public class Expense
{
    public int Id { get; set; }
    public int BudgetId { get; set; }
    public required string OrderNumber { get; set; }
    public string? HexNumber { get; set; }
    public DateTime ExpenseDate { get; set; }
    public decimal Amount { get; set; }
    public required string BeneficiaryName { get; set; }
    public string? InvoiceNumber { get; set; }
    public decimal Tax1 { get; set; } = 0;
    public decimal Tax2 { get; set; } = 0;
    public decimal Tax3 { get; set; } = 0;
    public decimal Tax4 { get; set; } = 0;
    public decimal Tax5 { get; set; } = 0;
    public decimal Tax6 { get; set; } = 0;
    public string? Tax1Name { get; set; }
    public string? Tax2Name { get; set; }
    public string? Tax3Name { get; set; }
    public string? Tax4Name { get; set; }
    public string? Tax5Name { get; set; }
    public string? Tax6Name { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal NetAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Notes { get; set; }
}
