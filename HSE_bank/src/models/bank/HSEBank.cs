using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.models.bank;

public sealed class HSEBank(ServiceProvider serviceProvider)
{
    public static string Name => "HSE Bank";
    
    private ServiceProvider serviceProvider_ = serviceProvider;
    
    private List<BankAccount> accounts_ = new List<BankAccount>();
    private List<Operation> operations_ = new List<Operation>();
    private List<Category> categories_ = new List<Category>();
    
    
}