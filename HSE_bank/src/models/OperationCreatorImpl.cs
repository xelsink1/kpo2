using HSE_bank.models.bank;
using HSE_bank.utils;
using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.models;

public class OperationCreatorImpl : OperationCreator
{
    public Operation GetOperationFromInput(ServiceProvider serviceProvider, int id_)
    {
        var id = id_ == -1 ? serviceProvider.GetService<DBOperations>()!.NewOperationId : id_;
        var type = Helper.GetOperationType();
        var bank_account_id = Helper.GetId("счета");
        var amount = Helper.GetAmount();
        var date = Helper.GetDate();
        var category_id = Helper.GetId("категории");
        return new Operation(id, type, bank_account_id, amount, date, category_id);
    }
}