using HSE_bank.consts;

namespace HSE_bank.models.bank;

public interface DBCategories
{
    public int NewCategoryId { get; }
    public Result RegisterCategory(Category category);
    public void UpdateCategory(Category category);
    public bool CheckCategoryId(int categoryId);
    public void DeleteCategory(int categoryId);
    public Dictionary<int, Category> GetCategories();
}