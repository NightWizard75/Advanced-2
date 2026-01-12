namespace Advanced.Tasks.LanguagePatterns;

/// <summary>
/// Создавайте классы и рекорды в отдельном файле в папке LanguagePatterns
/// </summary>
public class LanguagePatternsTasks
{
    /// <summary>
    /// Задание 4.1: Создайте record Person с свойствами Name и Age.
    /// </summary>
    

    /// <summary>
    /// Задание 4.2: Создайте класс Product с init-only свойствами.
    /// </summary>
    
    
    /// <summary>
    /// Тестовый Класс для метода GetObjectType
    /// </summary>
    public class MyList<T> : List<T>
    {
    }

    /// <summary>
    /// Задание 4.3: Используйте pattern matching для определения типа объекта.
    /// </summary>
    public string GetObjectType(object obj)
    {
        return obj switch
        {
            null => "null",
            string s when s.Length == 0 => "empty string",
            string => "string",
            int => "integer",
            bool => "boolean",
            double => "double",
            float => "float",
            decimal => "decimal",
            DateTime => "DateTime",
            List<int> => "list of integers", // Важен порядок. Список как наследник IEnumerable<int> должен быть раньше
            MyList<Person> => "MyList<Person>", // А вот MyList<Person> не наследник List<int>, а наследник List<Person>
                                                // Но должен быть раньше чем System.Collections.IEnumerable
            System.Collections.Generic.IEnumerable<int> => "enumerable of ints",
            System.Collections.IEnumerable => "enumerable",
            Product => "Product",
            // Тут можно заматчить и другие типы. 
            _ => $"unknown type: {obj.GetType().Name}" // null обработан в первой строке, поэтому obj? не обязательно.
        };
        
        // Вариант без pattern matching
        // return obj?.GetType().Name ?? "null";
    }

    /// <summary>
    /// Задание 4.4: Используйте switch expression для вычисления стоимости доставки.
    /// Пусть стоимость доставки будет - либо базовая стоимость типа доставки, либо сколько-то за килограмм
    /// </summary>
    public decimal CalculateShippingCost(string shippingType, decimal weight)
    {
        if (weight <= 0)
            throw new ArgumentException("Weight должен быть больше 0.", nameof(weight));

        return shippingType?.ToLowerInvariant() switch
        {
            "standard" => Math.Max(1000.0m, 500.0m * weight),
            "express"  => Math.Max(3000.0m, 1000.0m * weight),
            "free"     => 0.0m,
            null       => throw new ArgumentNullException(nameof(shippingType)),
            _          => throw new ArgumentException($"Неизвестное значение shippingType: {shippingType}", nameof(shippingType))
        };
    }

    /// <summary>
    /// Задание 4.5: Создайте record и напишите код (в отдельном классе DemonstrateDeconstruction) использования деконструкции.
    /// </summary>
    

    /// <summary>
    /// Задание 4.6: Используйте property patterns класса Product для проверки условий.
    /// </summary>
    public string GetProductStatus(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);
        
        return product switch
        {
            { Price: <= 0 } => "Ошибочная цена (non-positive price)",
            { Price: > 100000 } => "Элитный",
            { Price: > 10000 } => "Премиальный",
            { Quantity: <= 0 } => "Товар закончился",
            { Quantity: <= 5 } => "Товара осталось немного",
            { Quantity: > 100 } => "Товар на складе в большом количестве",
            _ => "Доступен"
        };
    }
}