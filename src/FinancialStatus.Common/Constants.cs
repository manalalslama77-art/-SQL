namespace FinancialStatus.Common;

public static class AppConstants
{
    public const string AppName = "برنامج الحالة المالية";
    public const string AppVersion = "v1.0.0";
    public const string AppTitle = $"{AppName} {AppVersion}";
    public const string Designer = "محمد السايج";
    public const string Organization = "المعاهد التقانية التابعة لجامعة الفرات";
    public const string DefaultCurrency = "ل.س"; // الليرة السورية
    public const string DefaultLanguage = "ar-SY";
    
    // Default credentials
    public const string DefaultUsername = "admin";
    public const string DefaultPassword = "1234";
    
    // Security
    public const int MaxFailedLoginAttempts = 3;
    public const int LockoutDurationMinutes = 15;
    public const int SessionTimeoutMinutes = 30;
    
    // Database
    public const string LocalDbName = "FinancialStatusDb";
    public const string DefaultConnectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FinancialStatusDb;Integrated Security=true;Encrypt=false;";
}

public enum BudgetLevel
{
    Major = 1,      // الأبواب الرئيسية
    Sub = 2,        // الأبواب الفرعية
    Partial = 3     // الأبواب الجزئية
}

public enum ReportTemplate
{
    Default = 0,
    Template1 = 1,
    Template2 = 2,
    Template3 = 3,
    Template4 = 4,
    Custom = 5
}

public enum DataClearType
{
    ExpensesOnly = 1,
    BudgetOnly = 2,
    ByMonthYear = 3,
    AllData = 4
}
