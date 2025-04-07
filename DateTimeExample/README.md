Този документ има за цел да даде кратко въведение, теоретична основа и примери за използването на структурата **DateTime** в C#.  

## 🔍 Общ преглед

В .NET езиците, включително C#, **DateTime** представлява структура, която съхранява дата и час с определена точност (обикновено с точност до 100 наносекунди). Тази структура позволява работа с дати и времена, форматиране и преобразуване към различни часови зони, операции с интервали от време и други.

### 🔑 Ключови характеристики
- **Структура (Value Type)**: `DateTime` е стойностен тип, а не референтен, т.е. подава се по стойност при предаване на функции.
- **Точност**: Може да съхранява дата и час с резолюция до 100 наносекунди.
- **Гама от стойности**: Поддържа дати между 01.01.0001 00:00:00 и 31.12.9999 23:59:59.
- **Неутрален спрямо култура**: Обработката на стойностите се изпълнява еднакво, но форматирането често зависи от зададената култура (локални настройки).

## 🕒 Създаване на DateTime обекти

Има няколко начина да създадем `DateTime` стойност в C#.

### 1. Използване на конструктора

```csharp
// Година, Месец, Ден
DateTime specificDate = new DateTime(2025, 4, 7);
Console.WriteLine(specificDate); // 7.4.2025 г. 0:00:00

// Година, Месец, Ден, Час, Минута, Секунда
DateTime specificDateTime = new DateTime(2025, 4, 7, 14, 30, 0);
Console.WriteLine(specificDateTime); // 7.4.2025 г. 14:30:00
```

### 2. Взимане на текуща дата и час

```csharp
DateTime now = DateTime.Now;            // Текуща дата и час според системното време
DateTime utcNow = DateTime.UtcNow;      // Текуща дата и час спрямо UTC
DateTime today = DateTime.Today;        // Само дата, със стойност 00:00:00 за часа
```

### 3. Парсване на низове към DateTime

```csharp
string dateString = "2025-04-07";
DateTime parsedDate = DateTime.Parse(dateString); // Автоматично разпознава формат "YYYY-MM-DD"
```

Ако форматът на датата е специфичен, може да използваме:

```csharp
string dateStringCustom = "07/04/2025 14:30";
DateTime parsedDateCustom = DateTime.ParseExact(
    dateStringCustom, 
    "dd/MM/yyyy HH:mm", 
    System.Globalization.CultureInfo.InvariantCulture
);
```

## Форматиране на DateTime

При извеждане на дата като текст, `DateTime` може да се форматира чрез стандартни или потребителски шаблони.  

### Стандартни формати

- **d**: Кратък формат за дата (според системните настройки). Пример: `07.4.2025`.
- **D**: Дълъг формат за дата. Пример: `7 април 2025 г.`.
- **t**: Кратък формат за час. Пример: `14:30`.
- **T**: Дълъг формат за час. Пример: `14:30:00`.
- **f, F, g, G, M, Y** и други: предлагат различна степен на детайлност за дата/час.

```csharp
DateTime now = DateTime.Now;
Console.WriteLine(now.ToString("d")); // Пр. "07.4.2025"
Console.WriteLine(now.ToString("D")); // Пр. "7 април 2025 г."
Console.WriteLine(now.ToString("t")); // Пр. "14:30"
Console.WriteLine(now.ToString("T")); // Пр. "14:30:00"
```

### Потребителски формати

C# поддържа набор от символи за персонализиране на формата. Например:
- **dd**: Ден от месеца (01 – 31).
- **MM**: Месец (01 – 12).
- **yyyy**: Година.
- **HH**: Час във формат 0–23.
- **mm**: Минути (00 – 59).
- **ss**: Секунди (00 – 59).

```csharp
DateTime now = DateTime.Now;
string customFormat = now.ToString("dd.MM.yyyy HH:mm:ss");
Console.WriteLine(customFormat); // Пр. "07.04.2025 14:30:45"
```

## Операции с DateTime

Някои от най-често използваните операции включват добавяне/изваждане на периоди, сравнение на дати и изчисляване на разлики.

### Добавяне и изваждане

```csharp
DateTime now = DateTime.Now;

// Добавяне на 1 ден
DateTime tomorrow = now.AddDays(1);

// Добавяне на 2 часа
DateTime plusTwoHours = now.AddHours(2);

// Изваждане на 30 минути
DateTime minusThirtyMinutes = now.AddMinutes(-30);
```

### Сравнение на дати

```csharp
DateTime date1 = new DateTime(2025, 4, 7);
DateTime date2 = new DateTime(2025, 5, 1);

bool isDate1BeforeDate2 = date1 < date2;   // true
bool isDate1AfterDate2 = date1 > date2;    // false
bool areDatesEqual = date1 == date2;       // false
```

### Разлика между две дати

Разликата между две дати може да се получи чрез метода `Subtract(...)`, който връща структура `TimeSpan`.

```csharp
DateTime startDate = new DateTime(2025, 4, 7);
DateTime endDate = new DateTime(2025, 4, 10);

TimeSpan difference = endDate - startDate;          // 3.00:00:00
TimeSpan differenceAlt = endDate.Subtract(startDate); // Същият резултат

Console.WriteLine(difference.Days);    // 3
Console.WriteLine(difference.TotalHours); // 72
```

## Работа с часови зони

За по-сложни сценарии (например конвертиране между различни часови зони) се използва `DateTimeOffset`, който съхранява и информация за офсета спрямо UTC. С `DateTime` може да се борави и чрез статичния клас `TimeZoneInfo`, който предлага възможност за конверсия на дата/час от една зона в друга.

```csharp
DateTime utcTime = DateTime.UtcNow;
TimeZoneInfo sofiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time"); // EET/EEST
DateTime sofiaLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, sofiaTimeZone);
Console.WriteLine(sofiaLocalTime);
```
