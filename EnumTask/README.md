Този документ има за цел да даде кратко въведение, теоретична основа и примери за използването на **Enum** (изброен тип) в C#.

## 🔍 Какво е Enum?

В C# **enum** (съкратено от *enumeration*) е специален стойностен тип, който изброява логически свързани константи под формата на символични имена. Това позволява кодът да стане по-четлив, по-структуриран и по-лесен за поддръжка, тъй като работи с изрични именовани стойности, вместо с 🧙‍♂️ *"магически"* числа.  

### 📅 Пример

```csharp
public enum WeekDay
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
```

По този начин може да използвате `WeekDay.Monday` вместо числото `1` или друго явление, което носи по-малко смисъл.

## Синтаксис и основни свойства

- Обявяването на enum става с ключовата дума `enum`.
- По подразбиране, всяко изброено поле получава цяло число (int) като стойност, като броенето започва от 0 за първия елемент, 1 за втория и т.н.
- Могат да се посочат конкретни стойности към елементите.  
- Enum може да бъде деклариран на ниво namespace или в клас/структура.

```csharp
public enum OrderStatus
{
    Pending,     // Получава стойност 0
    Processing,  // Получава стойност 1
    Completed,   // Получава стойност 2
    Canceled     // Получава стойност 3
}
```

Може да се задават и конкретни стойности:

```csharp
public enum ErrorCode
{
    None = 0,
    NotFound = 404,
    ServerError = 500
}
```

## Присвояване и използване на Enum стойности

За да присвоите стойност от **enum** на променлива:

```csharp
OrderStatus status = OrderStatus.Pending;
```

Може и да сравнявате стойности:

```csharp
if (status == OrderStatus.Pending)
{
    // Изпълни действия, свързани с 'Pending'
}
```

## Преобразуване

### Преобразуване към цяло число

```csharp
int numericValue = (int)OrderStatus.Completed;  // numericValue = 2
```

### Преобразуване към String

```csharp
string enumName = OrderStatus.Completed.ToString(); // "Completed"
```

### Преобразуване от String

За да конвертирате низ към enum стойност, може да използвате:

```csharp
OrderStatus parsedStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), "Completed");
```

Ако има риск низът да не съответства на валидно име в enum-а, препоръчително е да използвате:

```csharp
bool success = Enum.TryParse("Completed", out OrderStatus safeParsedStatus);
if (success)
{
    // safeParsedStatus има стойността OrderStatus.Completed
}
else
{
    // Невалиден низ
}
```

### Преобразуване от цяло число

```csharp
OrderStatus statusFromInt = (OrderStatus)2;  // Completed
```

Когато не сте сигурни дали числото попада във валиден обхват, можете да направите проверка:

```csharp
int value = 10;
if (Enum.IsDefined(typeof(OrderStatus), value))
{
    OrderStatus validStatus = (OrderStatus)value;
}
else
{
    // Невалидна стойност за тази enum
}
```

## Enum с различен основен тип

По подразбиране, базовият тип на **enum** е `int`, но може да бъде зададен и друг целочислен тип (например `byte`, `short`, `long`), стига да е съвместим:

```csharp
public enum ByteEnum : byte
{
    First = 1,
    Second = 2,
    Third = 3
}
```

## Ключови предимства

1. **По-голяма четимост** - вместо числа като `1` или `404`, използването на `OrderStatus.Pending` или `ErrorCode.NotFound` прави кода по-добре разбираем.
2. **Защита при компилиране** - компилаторът следи дали стойностите са валидни за дадения тип enum, намалявайки грешките от неправилни стойности.
3. **По-лесна поддръжка** - при промени на стойности или добавяне на нови, enum дава ясен структурен начин да се адаптира кодът.
