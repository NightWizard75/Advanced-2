namespace Advanced.Tasks;

public class AsyncTasks
{
    /// <summary>
    /// Задание 2.1: Напишите асинхронный метод, который имитирует загрузку данных.
    /// Используйте Task.Delay для имитации задержки.
    /// </summary>
    public async Task<string> LoadDataAsync()
    {
        var notCanceledTask = new Task<string>(() =>
        {
            Task.Delay(new Random().Next(1, 4) * 1000).Wait();
            return "Загрузка завершена.";
        });
        
        // Запуск задачи. Важно! - НЕ позволяет использовать отмену 
        // Задачу можно использовать для отложенного выполнения. Передать в модуль принятия решения о приоритетности и пр.
        // В основном необходимо использовать Task.Run(Делегат)
        notCanceledTask.Start(); 

        return await notCanceledTask;
    }

    /// <summary>
    /// Задание 2.2: Напишите асинхронный метод, который загружает данные с тайм-аутом.
    /// Если операция превышает timeout, бросает TimeoutException.
    /// </summary>
    public async Task<string> LoadDataWithTimeoutAsync(TimeSpan timeout)
    {
        using var cts = new CancellationTokenSource(timeout);
        try
        {
            return await LoadDataWithCancellationAsync(cts.Token);
        }
        catch (OperationCanceledException) when (cts.Token.IsCancellationRequested)
        {
            throw new TimeoutException("Операция завершена по таймауту.");
        }
    }

    /// <summary>
    /// Задание 2.3: Напишите метод, который выполняет несколько асинхронных операций параллельно
    /// и возвращает результат, когда все завершатся.
    /// </summary>
    public async Task<string[]> ExecuteParallelAsync(IEnumerable<Task<string>> tasks)
    {
        ArgumentNullException.ThrowIfNull(tasks);
        var taskList = tasks as IList<Task<string>> ?? tasks.ToList();

        return await Task.WhenAll(taskList); //.ConfigureAwait(false);
    }

    /// <summary>
    /// Задание 2.4: Напишите метод, который поддерживает отмену операции через CancellationToken.
    /// </summary>
    public async Task<string> LoadDataWithCancellationAsync(CancellationToken cancellationToken = default)
    {
        var switcher = new Random().Next(1, 4);
        var rndTime = new Random().Next(3, 6);
        
        async Task<string> DelayedResult(CancellationToken ct)
        {
            await Task.Delay(rndTime * 1000, ct);
            return $"Загрузка завершена быстрее таймаута.{ct.ToString()}";
        }
        
        return switcher switch
        {
            1 => await DelayedResult(cancellationToken),
            2 => await Task.Run(async () =>
                {
                    await Task.Delay(rndTime * 1000, cancellationToken);
                    return $"Загрузка завершена быстрее чем {cancellationToken.ToString()}";
                }),
            3 => await new HttpClient().GetStringAsync("https://catfact.ninja/fact", cancellationToken),
            _ => throw new InvalidOperationException($"Непредвиденное значение: {rndTime}")
        };
    }

    /// <summary>
    /// Задание 2.5: Напишите метод, который использует ConfigureAwait(false) для избежания deadlock.
    /// </summary>
    public async Task<string> LoadDataConfigureAwaitAsync()
    {
        return await LoadDataAsync().ConfigureAwait(false);
    }
}