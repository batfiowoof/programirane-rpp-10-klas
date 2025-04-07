// 1. Създаваме Dictionary<string, int> за Minecraft блокове
Dictionary<string, int> blockHardness = new Dictionary<string, int>();

// 2. Добавяне на блокове (Add)
blockHardness.Add("Stone", 3);
blockHardness.Add("Obsidian", 50);
blockHardness.Add("Dirt", 1);
blockHardness.Add("DiamondOre", 5);

// 3. Опит за добавяне на вече съществуващ ключ
if (!blockHardness.ContainsKey("Stone"))
{
    blockHardness.Add("Stone", 3); // Няма да се изпълни
}

// 4. Достъп до стойност по ключ (индексация)
Console.WriteLine($"Hardness of Obsidian: {blockHardness["Obsidian"]}");

// 5. Използване на TryGetValue за безопасен достъп
if (blockHardness.TryGetValue("Dirt", out int dirtHardness))
{
    Console.WriteLine($"Hardness of Dirt: {dirtHardness}");
}

// 6. Проверка дали ключ или стойност съществуват
Console.WriteLine("Contains 'Sand'? " + blockHardness.ContainsKey("Sand"));
Console.WriteLine("Contains value 5? " + blockHardness.ContainsValue(5));

// 7. Изтриване на елемент (Remove)
blockHardness.Remove("DiamondOre");

// 8. Обхождане на речника (KeyValuePair)
Console.WriteLine("\n--- All Blocks ---");
foreach (var block in blockHardness)
{
    Console.WriteLine($"Block: {block.Key}, Hardness: {block.Value}");
}

// 9. Обхождане на всички ключове
Console.WriteLine("\n--- Block Names ---");
foreach (var key in blockHardness.Keys)
{
    Console.WriteLine(key);
}

// 10. Обхождане на всички стойности
Console.WriteLine("\n--- Block Hardness Values ---");
foreach (var value in blockHardness.Values)
{
    Console.WriteLine(value);
}

// 11. Промяна на стойност за съществуващ ключ
blockHardness["Obsidian"] = 45;
Console.WriteLine($"\nUpdated Obsidian hardness: {blockHardness["Obsidian"]}");

// 12. Общо количество блокове
Console.WriteLine($"\nTotal blocks in dictionary: {blockHardness.Count}");

// 13. Изчистване на речника
blockHardness.Clear();
Console.WriteLine($"Cleared dictionary. Count: {blockHardness.Count}");

Console.ReadKey();