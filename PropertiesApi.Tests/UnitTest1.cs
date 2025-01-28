using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Application.Features.Owners.V1.Commands.CreateProperty;
using PropertiesApi.Tests.Controllers;
namespace PropertiesApi.Tests;

[TestFixture]
public class Tests
{
    private Mock<IRequestHandler<CreatePropertyCommand, BaseResponse<String>>> _mockCreatePropertyHandler;
    
    private TestController _controller;

    [SetUp]
    public void Setup()
    {
        _mockCreatePropertyHandler = new Mock<IRequestHandler<CreatePropertyCommand, BaseResponse<String>>>();
      
        _controller = new TestController(_mockCreatePropertyHandler.Object);
    }

    [Test]
    public async Task CreateProperty_ShouldReturnTrue()
    {
        // Arrange
        var command = new CreatePropertyCommand ("propertyNameTest","calle 9a",0,"",DateOnly.MaxValue,1);
        var response = new BaseResponse<string> { Data = "Resultado simulado" };

        _mockCreatePropertyHandler
            .Setup(h => h.Handle(It.IsAny<CreatePropertyCommand>(), CancellationToken.None))
            .Returns(Task.FromResult(response));

        // Act
        var result = await _controller.TestCreateProperty(command);

        // Assert
        //Assert.IsInstanceOf<OkResult>(result);
        Assert.Equals(result,true);
    }
    [Test]
    public async Task CreateProperty_ShouldReturnTrue()
    {
        // Arrange
        var command = new CreatePropertyCommand("propertyNameTest", "calle 9a", 0, "", DateOnly.MaxValue, 1);
        var response = new BaseResponse<string> { Data = "Resultado simulado" };

        _mockCreatePropertyHandler
            .Setup(h => h.Handle(It.IsAny<CreatePropertyCommand>(), CancellationToken.None))
            .Returns(Task.FromResult(response));

        // Act
        var result = await _controller.TestCreateProperty(command);

        // Assert
        //Assert.IsInstanceOf<OkResult>(result);
        Assert.Equals(result, true);
    }


}
