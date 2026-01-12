namespace Advanced.Tasks.LanguagePatterns;

public class DemonstrateDeconstruction
{
    public static void DeconstructPerson()
    {
        Person person = new("Вася", 30);
        
        // Деконструкция: распаковка в отдельные переменные
        var (name, age) = person;
        Console.WriteLine($"Имя: {name}, Возраст: {age}");

        // Можно игнорировать часть значений с помощью _
        var (_, personAge) = person;
        Console.WriteLine($"Только возраст: {personAge}");

        // Деконструкция в цикле
        var people = new[] { new Person("Петя", 12), new Person("Маша", 11) };
        foreach (var (n, a) in people)
        {
            Console.WriteLine($"Имя: {n}, Возраст: {a}");
        }
    }
}