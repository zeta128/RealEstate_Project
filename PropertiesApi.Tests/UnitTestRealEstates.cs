
using FluentAssertions;
using PropertiesApi.Application.Features.Properties.V1.Commands;
namespace PropertiesApi.Tests;

[TestFixture]
public class Tests
{


    private const string ValidName = "Test Property";
    private const string ValidAddress = "123 Test St";
    private const decimal ValidPrice = 100000;
    private const string ValidCodeInternal = "TEST-123";
    private static readonly DateOnly ValidYear = new DateOnly(2020, 1, 1);
    private const long ValidIdOwner = 1;

    [Test]
    public void Should_CreateCommand_WhenAllValuesAreValid()
    {
        // Act
        var command = new CreatePropertyCommand(
            ValidName,
            ValidAddress,
            ValidPrice,
            ValidCodeInternal,
            ValidYear,
            ValidIdOwner);

        // Assert
        command.Name.Should().Be(ValidName);
        command.Address.Should().Be(ValidAddress);
        command.Price.Should().Be(ValidPrice);
        command.CodeInternal.Should().Be(ValidCodeInternal);
        command.Year.Should().Be(ValidYear);
        command.IdOwner.Should().Be(ValidIdOwner);
    }

    [Test]
    public void Should_ThrowArgumentException_WhenIdOwnerIsZero()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            new CreatePropertyCommand(
                ValidName,
                ValidAddress,
                ValidPrice,
                ValidCodeInternal,
                ValidYear,
                0));

        Assert.That(ex!.Message, Does.Contain("The idOwner cannot be empty because is a relational value"));
        Assert.That(ex.ParamName, Is.EqualTo("idOwner"));
    }

    [Test]
    public void Should_ThrowArgumentException_WhenIdOwnerIsNegative()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            new CreatePropertyCommand(
                ValidName,
                ValidAddress,
                ValidPrice,
                ValidCodeInternal,
                ValidYear,
                -10));

        Assert.That(ex!.Message, Does.Contain("The idOwner cannot be empty because is a relational value"));
        Assert.That(ex.ParamName, Is.EqualTo("idOwner"));
    }



    [Test]
    public void Should_ThrowArgumentException_WhenAddressIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            new CreatePropertyCommand(
                ValidName,
                "",
                ValidPrice,
                ValidCodeInternal,
                ValidYear,
                ValidIdOwner));

        Assert.That(ex!.Message, Does.Contain("The address of property cannot be empty"));
        Assert.That(ex.ParamName, Is.EqualTo("address"));
    }

    [Test]
    public void Should_AcceptNullCodeInternal()
    {
        var command = new CreatePropertyCommand(
            ValidName,
            ValidAddress,
            ValidPrice,
            null,
            ValidYear,
            ValidIdOwner);

        command.CodeInternal.Should().BeNull();
    }

    [Test]
    public void Should_AcceptNullYear()
    {
        var command = new CreatePropertyCommand(
            ValidName,
            ValidAddress,
            ValidPrice,
            ValidCodeInternal,
            null,
            ValidIdOwner);

        command.Year.Should().BeNull();
    }




}
