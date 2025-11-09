namespace HSE_bank.utils;

using HSE_bank.console;
using HSE_bank.models;
using HSE_bank.models.bank;

public static class CategoryCommands
{
    public static void Command(ref HSEBank bank)
    {
        var choice = ConsoleCommands.ShowMenu(consts.Menus.MenuSubCommandCategory);

        switch (choice)
        {
            case "Добавить категорию":
                bank.RegisterCategory(GetCategoryFromInput(ref bank));
                break;
            case "Отредактировать категорию":
                var id = Helper.GetId();
                if (!bank.CheckAccountId(id))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, нет категории с таким id.");
                    return;
                }
                bank.UpdateCategory(GetCategoryFromInput(ref bank, id));
                break;
            case "Удалить категорию":
                id = Helper.GetId();
                bank.DeleteCategory(id);
                break;
        }
    }

    private static Category GetCategoryFromInput(ref HSEBank bank, int id_ = -1)
    {
        var id = id_ == -1 ? bank.NewCategoryId : id_;
        var type = Helper.GetCategoryType();
        var name = Helper.GetName();
        return new Category(id, type, name);
    }
}