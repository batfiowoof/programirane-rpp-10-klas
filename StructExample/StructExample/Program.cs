using System;

struct Item
{
    public string Name;
    public int Durability;
    public bool IsTool;

    // Конструктор
    public Item(string name, int durability, bool isTool)
    {
        Name = name;
        Durability = durability;
        IsTool = isTool;
    }

    // Метод за извеждане на информация
    public void PrintInfo()
    {
        Console.WriteLine($"Име на предмет: {Name}");
        Console.WriteLine($"Издръжливост: {Durability}");
        Console.WriteLine($"Тип: {(IsTool ? "Инструмент" : "Обикновен предмет")}");
        Console.WriteLine(new string('-', 30));
    }
}

class Program
{
    static void Main()
    {
        // Създаваме обекти от тип Item (структура)
        Item sword = new Item("Железен меч", 250, true);
        Item apple = new Item("Ябълка", 1, false);
        Item pickaxe = new Item("Диамантена кирка", 1561, true);

        // Извикваме метода
        sword.PrintInfo();
        apple.PrintInfo();
        pickaxe.PrintInfo();

        // Масив от предмети
        Item[] inventory = new Item[]
        {
            new Item("Лък", 384, true),
            new Item("Хляб", 1, false),
            new Item("Златна кирка", 32, true)
        };

        Console.WriteLine("Предмети в инвентара:\n");

        foreach (Item item in inventory)
        {
            item.PrintInfo();
        }
    }
}
