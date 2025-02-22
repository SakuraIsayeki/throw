using Xunit;

namespace Throw.UnitTests.ValidatableMethods;

[Collection(nameof(TypesTests))]
public class TypesTests
{
    [Fact]
    public void ThrowIfType_WhenCompileTypesEqual_ShouldThrow()
    {
        // Arrange
        string str = "string";

        // Act
        Action action = () => str.Throw().IfType<string>();

        // Assert
        var exception = Assert.Throws<ArgumentException>(() => action());
        Assert.Equal($"Parameter should not be of type '{str.GetType().Name}'. (Parameter '{nameof(str)}')", exception.Message);
    }

    [Fact]
    public void ThrowIfType_WhenRuntimeTypesEqual_ShouldThrow()
    {
        // Arrange
        object list = new List<int>();

        // Act
        Action action = () => list.Throw().IfType<List<int>>();

        // Assert
        var exception = Assert.Throws<ArgumentException>(() => action());
        Assert.Equal($"Parameter should not be of type '{list.GetType().Name}'. (Parameter '{nameof(list)}')", exception.Message);
    }

    [Fact]
    public void ThrowIfType_WhenCompileTimeTypeIsNotType_ShouldNotThrow()
    {
        // Arrange
        List<int> list = new();

        // Act
        Action action2 = () => list.Throw().IfType<int>();

        // Assert
        var ex = Record.Exception(() => action2());
        Assert.Null(ex);
    }

    [Fact]
    public void ThrowIfNotType_WhenCompileTimeTypeIsNotType_ShouldThrow()
    {
        // Arrange
        string str = "string";

        // Act
        Action action = () => str.Throw().IfNotType<int>();

        // Assert
        var ex = Assert.Throws<ArgumentException>(() => action());
        Assert.Equal($"Parameter should be of type '{nameof(Int32)}'. (Parameter '{nameof(str)}')", ex.Message);
    }

    [Fact]
    public void ThrowIfNotType_WhenCompileTimeTypesEqual_ShouldNotThrow()
    {
        // Arrange
        List<int> list = new();

        // Act
        Action action = () => list.Throw().IfNotType<List<int>>();

        // Assert
        var ex = Record.Exception(() => action());
        Assert.Null(ex);
    }

    [Fact]
    public void ThrowIfNotType_WhenRuntimeTypesEquals_ShouldNotThrow()
    {
        // Arrange
        object list = new List<int>();

        // Act
        Action action = () => list.Throw().IfNotType<List<int>>();

        // Assert
        var ex = Record.Exception(() => action());
        Assert.Null(ex);
    }
}
