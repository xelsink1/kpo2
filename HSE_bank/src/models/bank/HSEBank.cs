using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.models.bank;

public sealed class HSEBank(ServiceProvider serviceProvider)
{
    public static string Name => "HSE Bank";
    
    private ServiceProvider serviceProvider_ = serviceProvider;
    
    
}