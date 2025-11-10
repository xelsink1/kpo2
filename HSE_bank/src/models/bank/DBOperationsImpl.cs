using HSE_bank.consts;

namespace HSE_bank.models.bank;

public class DBOperationsImpl : DBOperations
{
    public int NewOperationId => free_operation_id_++;
    
    private int free_operation_id_ = 0;
    
    private HashSet<int> operations_ = new HashSet<int>();
    private Dictionary<int, Operation> operations__ = new Dictionary<int, Operation>();

    public Result RegisterOperation(Operation operation)
    {
        if (!operations_.Add(operation.Id))
        {
            Console.WriteLine($"Операция {operation.Id} уже зарегистрирована!");
            return Result.Error;
        }

        operations__.Add(operation.Id, operation);
        return Result.Ok;
    }

    public void UpdateOperation(Operation operation)
    {
        operations__[operation.Id] = operation;
    }

    public bool CheckOperationId(int operationId)
    {
        return operations_.Contains(operationId);
    }

    public void DeleteOperation(int operationId)
    {
        operations_.Remove(operationId);
        operations__.Remove(operationId);
    }

    public Dictionary<int, Operation> GetOperations()
    {
        return operations__;
    }
}