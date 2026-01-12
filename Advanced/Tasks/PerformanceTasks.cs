namespace Advanced.Tasks;

public class PerformanceTasks
{
    /// <summary>
    /// Задание 3.1: Напишите метод, который реверсирует массив using Span.
    /// </summary>
    public void ReverseArray<T>(T[] array)
    {
        ArgumentNullException.ThrowIfNull(array);
        
        var span = array.AsSpan();
        span.Reverse();
    }

    /// <summary>
    /// Задание 3.2: Напишите метод, который суммирует элементы массива using Span.
    /// </summary>
    public int SumArray(Span<int> span)
    {
        var result = 0;
        
        foreach (var val in span)
            result += val;
        
        return result;
    }

    /// <summary>
    /// Задание 3.3: Напишите метод, который демонстрирует boxing/unboxing.
    /// </summary>
    public object BoxValue(int value)
    {
        return (object)value;
    }

    public int UnboxValue(object value)
    {
        return (int)value;
    }
}