
using PropertiesApi.Application.Features.Owners.V1.Commands.CreateProperty;
namespace PropertiesApi.Tests;

[TestFixture]
public class Tests
{
      

    [Test]
    public void CreateProperty_ShouldThrowArgumentException_WhenIdOwnerIsZero()
    {
        // Arrange
        string name = "Test Property";
        string address = "123 Test St";
        decimal? price = 100000;
        string codeInternal = "TEST-123";
        DateOnly? year = DateOnly.MinValue;
        long idOwner = 0; // Valor inválido

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() =>
            new CreatePropertyCommand(name, address, price, codeInternal, year, idOwner)
        );

        // Verifica que el mensaje de error y el parámetro sean correctos
        Assert.That(ex.Message, Does.Contain("The idOwner cannot be empty because is a relational value"));
        Assert.That(ex.ParamName, Is.EqualTo("idOwner"));
    }
    


}
