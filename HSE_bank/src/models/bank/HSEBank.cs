using HSE_bank.consts;
using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.models.bank;

public sealed class HSEBank(ServiceProvider serviceProvider)
{
    public static string Name => "HSE Bank";
    
    public ref DBAccounts Accounts => ref accounts_;
    public ref DBCategories Categories => ref categories_;
    public ref DBOperations Operations => ref operations_;
    
    private ServiceProvider serviceProvider_ = serviceProvider;
    
    private DBAccounts accounts_ = new DBAccountsImpl();
    private DBCategories categories_ = new DBCategoriesImpl();
    private DBOperations operations_ = new DBOperationsImpl();
}