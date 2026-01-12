using Advanced.Tasks.LanguagePatterns;
using Xunit;

namespace Advanced.Tests.Tasks;

public class LanguagePatternsTasksTests
{
    private readonly LanguagePatternsTasks _tasks = new();
    
    
    // === Тесты для GetObjectType ===

    [Fact]
    public void GetObjectType_Null_ReturnsNullString()
    {
        // Arrange
        object obj = null!;
        
        // Act
        var result = _tasks.GetObjectType(obj);
        
        // Assert
        Assert.Equal("null", result);
    }

    [Fact]
    public void GetObjectType_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = "";
        
        // Act
        var result = _tasks.GetObjectType(input);
        
        // Assert
        Assert.Equal("empty string", result);
    }

    [Fact]
    public void GetObjectType_MyListPerson_ReturnsCorrectString()
    {
        // Arrange
        var list = new LanguagePatternsTasks.MyList<Person> { new("Test", 25) };
        
        // Act
        var result = _tasks.GetObjectType(list);
        
        // Assert
        Assert.Equal("MyList<Person>", result);
    }
    
    
    // === Тесты для CalculateShippingCost ===

    [Fact]
    public void CalculateShippingCost_Standard_LowWeight_UsesBasePrice()
    {
        // Arrange
        const string shippingType = "standard";
        const decimal weight = 1; 
        
        // Act
        var cost = _tasks.CalculateShippingCost(shippingType, weight);
        
        // Assert
        Assert.Equal(1000.0m, cost);
    }

    [Fact]
    public void CalculateShippingCost_Express_HighWeight_UsesPerKgPrice()
    {
        // Arrange
        const string shippingType = "express";
        const decimal weight = 5; 
        
        // Act
        var cost = _tasks.CalculateShippingCost(shippingType, weight);
        
        // Assert
        Assert.Equal(5000.0m, cost);
    }

    [Fact]
    public void CalculateShippingCost_Free_ReturnsZero()
    {
        // Arrange
        const string shippingType = "free";
        const decimal weight = 100;
        
        // Act
        var cost = _tasks.CalculateShippingCost(shippingType, weight);
        
        // Assert
        Assert.Equal(0.0m, cost);
    }
    
    
    // === Тест деконструкции record Person ===

    [Fact]
    public void Person_DeconstructsCorrectly()
    {
        // Arrange
        var person = new Person("Alice", 30);
        
        // Act
        var (name, age) = person;
        
        // Assert
        Assert.Equal("Alice", name);
        Assert.Equal(30, age);
    }
    

    // === Тесты для GetProductStatus (property patterns) ===

    [Fact]
    public void GetProductStatus_ZeroQuantity_ReturnsOutOfStock()
    {
        // Arrange
        var product = new Product { Name = "Pen", Price = 10, Quantity = 0 };
        
        // Act
        var status = _tasks.GetProductStatus(product);
        
        // Assert
        Assert.Equal("Товар закончился", status);
    }

    [Fact]
    public void GetProductStatus_HighPrice_ReturnsPremium()
    {
        // Arrange
        var product = new Product { Name = "Laptop", Price = 15000, Quantity = 10 };
        
        // Act
        var status = _tasks.GetProductStatus(product);
        
        // Assert
        Assert.Equal("Премиальный", status);
    }

    [Fact]
    public void GetProductStatus_NormalProduct_ReturnsAvailable()
    {
        // Arrange
        var product = new Product { Name = "MacBook", Price = 5000, Quantity = 20 };
        
        // Act
        var status = _tasks.GetProductStatus(product);
        
        // Assert
        Assert.Equal("Доступен", status);
    }
}