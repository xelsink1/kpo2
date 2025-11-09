using HSE_bank.consts;

namespace HSE_bank.models;

public class Category
{
    public int Id => id_;
    public string Name => name_;
    public CategoryType Type => type_;
    
    private int id_;
    private CategoryType type_;
    private string name_;
}