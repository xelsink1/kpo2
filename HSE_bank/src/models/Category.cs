using HSE_bank.consts;

namespace HSE_bank.models;

public class Category(int id, CategoryType type, string name)
{
    public int Id => id;
    public string Name => name;
    public CategoryType Type => type;
}