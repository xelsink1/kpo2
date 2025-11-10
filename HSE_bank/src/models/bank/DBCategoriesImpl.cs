using HSE_bank.consts;

namespace HSE_bank.models.bank;

public class DBCategoriesImpl : DBCategories
{
    public int NewCategoryId => free_category_id_++;
    
    private int free_category_id_ = 0;
    
    private HashSet<int> categories_ = new HashSet<int>();
    private Dictionary<int, Category> categories__ = new Dictionary<int, Category>();
    
    public Result RegisterCategory(Category category)
    {
        if (!categories_.Add(category.Id))
        {
            Console.WriteLine($"Категория {category.Id} уже зарегистрирована!");
            return Result.Error;
        }
        
        categories__.Add(category.Id, category);
        return Result.Ok;
    }

    public void UpdateCategory(Category category)
    {
        categories__[category.Id] = category;
    }

    public bool CheckCategoryId(int categoryId)
    {
        return categories_.Contains(categoryId);
    }

    public void DeleteCategory(int categoryId)
    {
        categories_.Remove(categoryId);
        categories__.Remove(categoryId);
    }

    public Dictionary<int, Category> GetCategories()
    {
        return categories__;
    }
}