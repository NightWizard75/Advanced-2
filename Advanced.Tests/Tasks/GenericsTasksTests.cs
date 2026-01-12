using Advanced.Tasks;

namespace Advanced.Tests.Tasks;

using Xunit;

public class GenericsTasksTests
{
    private readonly GenericsTasks _tasks = new();

    [Fact]
    public async Task GetFirstElement_ShouldReturnFirstElement()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3 };

        // Act
        var result = await _tasks.GetFirstElement(numbers);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task GetFirstElement_ShouldReturnDefaultForEmptyCollection()
    {
        // Arrange
        var empty = new List<int>();

        // Act
        var result = await _tasks.GetFirstElement(empty);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public async Task Filter_ShouldFilterCollectionByPredicate()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Act
        var result = await _tasks.Filter(numbers, x => x % 2 == 0);

        // Assert
        Assert.Equal(new[] { 2, 4 }, result);
    }

    [Fact]
    public void Swap_ShouldSwapValues()
    {
        // Arrange
        int a = 5, b = 10;

        // Act
        _tasks.Swap(ref a, ref b);

        // Assert
        Assert.Equal(10, a);
        Assert.Equal(5, b);
    }
}