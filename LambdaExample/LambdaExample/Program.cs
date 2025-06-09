using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsFuncs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Star Wars Func Side!");

            // Обикновен метод
            string GreetJedi(string name)
            {
                return $"Hello, Jedi {name}. May the Force be with you.";
            }

            // Анонимен метод - Func
            Func<string, string> greetJediAnon = name => $"Hello, Jedi {name}. May the Force be with you.";

            Console.WriteLine(GreetJedi("Luke"));
            Console.WriteLine(greetJediAnon("Ahsoka"));

            // Още един пример: дали даден герой е от Тъмната страна
            bool IsSith(string name)
            {
                var sithLords = new List<string> { "Palpatine", "Vader", "Maul", "Dooku", "Kylo" };
                return sithLords.Contains(name);
            }

            Func<string, bool> isSithAnon = name =>
                new List<string> { "Palpatine", "Vader", "Maul", "Dooku", "Kylo" }.Contains(name);

            Console.WriteLine(IsSith("Vader") ? "Sith detected!" : "All clear.");
            Console.WriteLine(isSithAnon("Obi-Wan") ? "Corruption!" : "Still clean.");

            // LINQ с Func – филтрираме само джедаи
            var characters = new List<string> { "Luke", "Leia", "Han", "Vader", "Rey", "Maul", "Yoda", "Finn" };

            // Обикновен метод за проверка дали е Jedi
            bool IsJedi(string name)
            {
                var knownJedi = new List<string> { "Luke", "Yoda", "Rey", "Obi-Wan", "Ahsoka" };
                return knownJedi.Contains(name);
            }

            // Анонимно
            Func<string, bool> isJediAnon = name =>
                new List<string> { "Luke", "Yoda", "Rey", "Obi-Wan", "Ahsoka" }.Contains(name);

            var realJedi = characters.Where(IsJedi).ToList();
            var fakeJedi = characters.Where(isJediAnon).ToList(); // същото нещо basically

            Console.WriteLine("Real Jedi:");
            realJedi.ForEach(jedi => Console.WriteLine($" - {jedi}"));

            Console.WriteLine("Fake Jedi (but same result 'cause LINQ magic):");
            fakeJedi.ForEach(jedi => Console.WriteLine($" - {jedi}"));

            // Action – просто печатаме нещо, без да връща стойност
            Action<string> useTheForce = name => Console.WriteLine($"{name} is using the Force!");

            useTheForce("Grogu");

            // Пример с по-комплексен Func – бойна сила според характера (100% научно доказано от Йода)
            Func<string, int> calculateMidichlorianLevel = name =>
                name switch
                {
                    "Yoda" => 20000,
                    "Anakin" => 27000,
                    "Grogu" => 15000,
                    _ => 5000 // Sorry Han, you ain't special
                };

            Console.WriteLine($"Anakin's Midichlorian Level: {calculateMidichlorianLevel("Anakin")}");
            Console.WriteLine($"Leia's Midichlorian Level: {calculateMidichlorianLevel("Leia")}");
        }
    }
}
