using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Hashtable inventory = new Hashtable();

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Добавяне на предмети в инвентара
        inventory.Add("Diamond", 5);
        inventory.Add("Iron Ingot", 20);
        inventory.Add("Wood Plank", 64);

        Console.WriteLine("--- Minecraft Инвентар ---");
        DisplayInventory(inventory);

        // Проверка дали даден предмет съществува
        Console.WriteLine("\nПроверка за предмет 'Iron Ingot':");
        if (inventory.ContainsKey("Iron Ingot"))
        {
            Console.WriteLine("Имате 'Iron Ingot' в количество: {0}", inventory["Iron Ingot"]);
        }

        // Достъп до стойност по ключ
        Console.WriteLine("\nКоличество на 'Wood Plank':");
        if (inventory.ContainsKey("Wood Plank"))
        {
            Console.WriteLine(inventory["Wood Plank"]);
        }

        // Премахване на предмет
        Console.WriteLine("\nПремахване на предмет 'Diamond'.");
        inventory.Remove("Diamond");

        Console.WriteLine("\n--- Инвентар след премахване ---");
        DisplayInventory(inventory);

        // Опит за достъп до несъществуващ предмет
        Console.WriteLine("\nОпит за достъп до 'Diamond':");
        if (inventory.ContainsKey("Diamond"))
        {
            Console.WriteLine(inventory["Diamond"]);
        }
        else
        {
            Console.WriteLine("Нямате 'Diamond' в инвентара.");
        }

        Console.WriteLine("\nНатиснете произволен клавиш за изход...");
        Console.ReadKey();
    }

    static void DisplayInventory(Hashtable inventory)
    {
        foreach (DictionaryEntry entry in inventory)
        {
            Console.WriteLine("Предмет: {0}, Количество: {1}", entry.Key, entry.Value);
        }
    }
}