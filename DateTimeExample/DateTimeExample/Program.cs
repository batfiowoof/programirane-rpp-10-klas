using System;

class Program
{
    static void Main()
    {
        // 1. Текуща дата и час
        DateTime now = DateTime.Now;
        Console.WriteLine($"Текуща дата и час: {now}");

        // 2. Само днешната дата (без час)
        DateTime today = DateTime.Today;
        Console.WriteLine($"Само дата (днес): {today.ToShortDateString()}");

        // 3. Ръчно зададена дата – например старт на събитие
        DateTime eventStart = new DateTime(2025, 5, 20, 14, 0, 0); // 20 май 2025, 14:00
        Console.WriteLine($"\nСъбитието започва на: {eventStart}");

        // 4. Добавяне на дни и часове
        DateTime eventEnd = eventStart.AddDays(3).AddHours(4);
        Console.WriteLine($"Събитието ще приключи на: {eventEnd}");

        // 5. Изчисляване на разлика между дати
        TimeSpan remaining = eventEnd - now;
        Console.WriteLine($"\nОставащо време до края на събитието: {remaining.Days} дни, {remaining.Hours} часа и {remaining.Minutes} минути");

        // 6. Форматиране на дата
        Console.WriteLine($"\nФорматирана дата: {eventStart.ToString("dddd, dd MMMM yyyy HH:mm")}");

        // 7. Сравнение на дати
        if (now < eventStart)
        {
            Console.WriteLine("Събитието още не е започнало.");
        }
        else if (now >= eventStart && now <= eventEnd)
        {
            Console.WriteLine("Събитието е в процес.");
        }
        else
        {
            Console.WriteLine("Събитието вече е приключило.");
        }
    }
}
