# Lambda изрази в C\#

## 🧠 Какво е Lambda израз?

Lambda изразите са кратък синтаксис за създаване на анонимни методи (функции без име) в C#. Те позволяват по-четим, компактен и функционален стил на програмиране, особено когато работим с LINQ, делегати и събития.

```csharp
(parameters) => expression
```

Или за по-сложна логика:

```csharp
(parameters) => {
    // code block
    return value;
}
```

## 🧪 Пример:

```csharp
Func<int, int, int> sum = (a, b) => a + b;
Console.WriteLine(sum(3, 4)); // 7
```

## 📦 Вградените типове делегати:

* **Func<...>** – връща стойност
* **Action<...>** – не връща стойност (void)
* **Predicate<T>** – връща bool

```csharp
Func<string, int> getLength = s => s.Length;
Action<string> greet = name => Console.WriteLine($"Hi, {name}!");
Predicate<int> isEven = x => x % 2 == 0;
```

## 🎯 Контекст на употреба:

### LINQ:

```csharp
var evens = numbers.Where(n => n % 2 == 0);
```

### Събития:

```csharp
button.Click += (sender, args) => Console.WriteLine("Clicked!");
```

### Сортиране и трансформации:

```csharp
names.Sort((x, y) => x.CompareTo(y));
```

## 🧵 Scope и капсулиране

Lambda изразите имат достъп до:

* Параметрите си
* Локални променливи от обхвата, в който са създадени

```csharp
int factor = 2;
Func<int, int> multiplier = x => x * factor;
```
