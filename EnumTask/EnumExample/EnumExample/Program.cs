using System;

class Program
{
    // 1. Дефинираме изброим тип (enum)
    enum BlockType
    {
        Dirt,
        Stone,
        Obsidian,
        DiamondOre,
        Wood
    }

    static void Main()
    {
        // 2. Използваме Enum пряко
        BlockType myBlock = BlockType.DiamondOre;
        Console.WriteLine($"Избран блок: {myBlock}");

        // 3. Използваме Enum в switch конструкция
        switch (myBlock)
        {
            case BlockType.Dirt:
                Console.WriteLine("Лесен за чупене. Полезен за засаждане.");
                break;
            case BlockType.Stone:
                Console.WriteLine("Среща се често под земята. Нужна е кирка.");
                break;
            case BlockType.Obsidian:
                Console.WriteLine("Много здрав. Необходима е диамантена кирка!");
                break;
            case BlockType.DiamondOre:
                Console.WriteLine("Рядък и ценен блок. Изисква желязна или по-добра кирка.");
                break;
            case BlockType.Wood:
                Console.WriteLine("Основен строителен материал. Събира се с брадва.");
                break;
        }

        // 4. Преобразуване от int към enum
        int n = 2;
        BlockType blockNumber = (BlockType)n;
        Console.WriteLine($"\nБлок с ID 2 е: {blockNumber}");

        // 5. Въвеждане от потребител и преобразуване към enum
        Console.WriteLine("\nВъведи име на блок (Пръст, Камък, Обсидиан, ДиамантенаЖила, Дърво):");
        string input = Console.ReadLine();

        if (Enum.TryParse(input, true, out BlockType userBlock))
        {
            Console.WriteLine($"Ти избра блока: {userBlock}");
        }
        else
        {
            Console.WriteLine("Невалиден тип блок.");
        }

        // 6. Изброяване на всички стойности в Enum
        Console.WriteLine("\nВсички налични типове блокове:");
        foreach (var block in Enum.GetValues(typeof(BlockType)))
        {
            Console.WriteLine($"- {block}");
        }
    }
}
