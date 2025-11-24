using Microsoft.AspNetCore.Mvc;
using WebCalculator.Controllers;
using WebCalculator.Models;
using Xunit;
public class CalculatorControllerTests
{
    private readonly CalculatorController _controller = new();
    [Fact]
    public void Calculate_ValidRequest_ReturnsSuccessResult()
    {
        var request = new CalculatorRequest { Number1 = 10, Number2 = 5, Operation = "add" };
        var result = _controller.Calculate(request);
        var okResult = Assert.IsType<ActionResult<CalculatorResponse>>(result);
        var response = Assert.IsType<CalculatorResponse>(((OkObjectResult)okResult.Result).Value);
        Assert.True(response.Success);
        Assert.Equal(15, response.Result);
    }
    [Fact]
    public void GetAvailableOperations_ReturnsListOfOperations()
    {
        var result = _controller.GetAvailableOperations();
        var okResult = Assert.IsType<ActionResult<List<string>>>(result);
        var operations = Assert.IsType<List<string>>(((OkObjectResult)okResult.Result).Value);
        Assert.Equal(5, operations.Count);
        Assert.Contains("add", operations);
    }
}
