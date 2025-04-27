В този markdown файл ще разгледаме класа **Hashtable** в C#. Това е структура от данни, която съхранява двойки ключ-стойност и осигурява бърз достъп до стойностите чрез техните ключове, точно като Dictionary.

Важно: Тук говорим само за **Hashtable**, а не за други подобни колекции като **Dictionary<TKey, TValue>** (Което е по-препоръчително да използвате anyways!).

## Какво е Hashtable?

**Hashtable** е колекция от двойки ключ-стойност, където:
- **Ключ (Key)** е уникален идентификатор.
- **Стойност (Value)** е данните, асоциирани с този ключ.

Достъпът до стойности се реализира чрез хеширане на ключа.

## Създаване на Hashtable

```csharp
using System.Collections;

Hashtable hashtable = new Hashtable();
```

Създаване на хеш таблица с начални елементи:

```csharp
Hashtable hashtable = new Hashtable()
{
    { "key1", "value1" },
    { "key2", "value2" },
    { 3, 100 }
};
```

## Добавяне на елементи

```csharp
hashtable.Add("name", "John Doe");
hashtable.Add("occupation", "Engineer");
```

Добавянето на вече съществуващ ключ ще предизвика `ArgumentException`.

## Достъп до елементи

```csharp
Console.WriteLine(hashtable["name"]);
```

Ако ключът не съществува, ще бъде върнато `null`.

## Проверка за наличие на ключ или стойност

```csharp
if (hashtable.ContainsKey("name"))
{
    Console.WriteLine("Ключът съществува.");
}

if (hashtable.ContainsValue("Engineer"))
{
    Console.WriteLine("Стойността съществува.");
}
```

## Премахване на елементи

```csharp
hashtable.Remove("occupation");
```

Ако ключът не съществува, премахването няма да предизвика грешка.

## Итериране през Hashtable

```csharp
foreach (DictionaryEntry entry in hashtable)
{
    Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
}
```

## Недостатъци на Hashtable

- **Boxing/Unboxing**: Понеже работи с `object`, стойностните типове (int, double и т.н.) се обвиват в обекти, което води до допълнително натоварване.
- **Липса на типова безопасност**: Възможни са грешки по време на изпълнение.
- **По-ниска производителност**: В сравнение с `Dictionary<TKey, TValue>` при по-големи обеми данни.

## Кога да използваме Hashtable?

- При поддръжка на стар код.
- Когато е необходима съвместимост с интерфейси, изискващи `ICollection`.
- В ситуации, където типовата безопасност не е критична.

