using Advanced.Tasks;

namespace Advanced.Tests.Tasks;

using Xunit;

public class PerformanceTasksTests
{
    private readonly PerformanceTasks _tasks = new();

    [Fact]
    public void ReverseArray_ShouldReverseArrayInPlace()
    {
        // Arrange
        var array = new[] { 1, 2, 3, 4, 5 };

        // Act
        _tasks.ReverseArray(array);

        // Assert
        Assert.Equal(new[] { 5, 4, 3, 2, 1 }, array);
    }

    [Fact]
    public void SumArray_ShouldCalculateSum()
    {
        // Arrange
        var span = new Span<int>(new[] { 1, 2, 3, 4, 5 });

        // Act
        var result = _tasks.SumArray(span);

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void BoxUnbox_ShouldWorkCorrectly()
    {
        // Act
        var boxed = _tasks.BoxValue(42);
        var unboxed = _tasks.UnboxValue(boxed);

        // Assert
        Assert.Equal(42, unboxed);
    }
}