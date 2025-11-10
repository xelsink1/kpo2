using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.models;

public interface OperationCreator
{
    public Operation GetOperationFromInput(ServiceProvider serviceProvider, int id_ = -1);
}