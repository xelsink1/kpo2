using HSE_bank.consts;

namespace HSE_bank.models.bank;

public interface DBOperations
{
    public int NewOperationId { get; }
    public Result RegisterOperation(Operation operation);
    public void UpdateOperation(Operation operation);
    public bool CheckOperationId(int operationId);
    public void DeleteOperation(int operationId);
    public Dictionary<int, Operation> GetOperations();
}