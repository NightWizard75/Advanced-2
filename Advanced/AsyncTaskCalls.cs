using Advanced.Tasks;

namespace Advanced;

public class AsyncTaskCalls
{
    public static async Task Run()
    {
        var async = new AsyncTasks();

        //2.1
        Console.WriteLine(await async.LoadDataAsync());

        //2.2
        Console.WriteLine(await async.LoadDataWithTimeoutAsync(new TimeSpan(hours:0, minutes:0, seconds:15)));

        //2.3, 2.4
        var finishedTasks = await async.ExecuteParallelAsync(new[]
        {
            async.LoadDataAsync(), 
            async.LoadDataAsync(),
            async.LoadDataAsync(),
        }); 
        Console.WriteLine(String.Join(", ", finishedTasks));

        // Запуск фоновой задачи, не дожидаясь ее завершения
        _ = ObserveLoadTask();

        // Продолжается выполнение кода
        Console.WriteLine("Это сообщение выводится, пока задача ObserveLoadTask() работает в фоне!");

        // Нужно удержать приложение от завершения. Иначе основной поток завершиться
        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }
    
    // Фоновая задача. Обращается к асинхронному методу LoadDataWithTimeoutAsync
    private static async Task ObserveLoadTask()
    {
        try
        {
            Console.WriteLine("Задача запущена.");
            var async = new AsyncTasks();
            var result = await async.LoadDataWithTimeoutAsync(TimeSpan.FromSeconds(5));
            Console.Write("Результат готов: ");
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}