using Microsoft.AspNetCore.Mvc;
using WebCalculator.Controllers;
using WebCalculator.Models;
using Xunit;

public class CalculatorControllerTests
{
    private readonly CalculatorController _controller;

    public CalculatorControllerTests()
    {
        _controller = new CalculatorController();
    }

    [Fact]
    public void Calculate_ValidRequest_ReturnsSuccessResult()
    {
        // Arrange
        var request = new CalculatorRequest 
        { 
            Number1 = 10, 
            Number2 = 5, 
            Operation = "add" 
        };

        // Act
        var result = _controller.Calculate(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<CalculatorResponse>(okResult.Value);
        Assert.True(response.Success);
        Assert.Equal(15, response.Result);
    }

    [Fact]
    public void GetAvailableOperations_ReturnsListOfOperations()
    {
        // Act
        var result = _controller.GetAvailableOperations();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var operations = Assert.IsType<List<string>>(okResult.Value);
        Assert.Equal(5, operations.Count);
        Assert.Contains("add", operations);
    }
}
