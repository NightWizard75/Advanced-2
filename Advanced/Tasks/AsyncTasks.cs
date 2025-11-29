namespace Advanced.Tasks;

public class AsyncTasks
{
    /// <summary>
    /// Задание 2.1: Напишите асинхронный метод, который имитирует загрузку данных.
    /// Используйте Task.Delay для имитации задержки.
    /// </summary>
    public Task<string> LoadDataAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Задание 2.2: Напишите асинхронный метод, который загружает данные с тайм-аутом.
    /// Если операция превышает timeout, бросает TimeoutException.
    /// </summary>
    public Task<string> LoadDataWithTimeoutAsync(TimeSpan timeout)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Задание 2.3: Напишите метод, который выполняет несколько асинхронных операций параллельно
    /// и возвращает результат, когда все завершатся.
    /// </summary>
    public Task<string[]> ExecuteParallelAsync(IEnumerable<Task<string>> tasks)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Задание 2.4: Напишите метод, который поддерживает отмену операции через CancellationToken.
    /// </summary>
    public Task<string> LoadDataWithCancellationAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Задание 2.5: Напишите метод, который использует ConfigureAwait(false) для избежания deadlock.
    /// </summary>
    public Task<string> LoadDataConfigureAwaitAsync()
    {
        throw new NotImplementedException();
    }
}