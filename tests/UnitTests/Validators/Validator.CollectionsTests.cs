using Xunit;

namespace Throw.UnitTests.Validators;

[Collection(nameof(CollectionsValidatorTests))]
public class CollectionsValidatorTests
{
    [Fact]
    public void GetCollectionCount_WhenCollectionIsArray_ShouldReturnCollectionCount()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        var count = Validator.GetCollectionCount(collection);

        // Assert
        Assert.Equal(collection.Length, count);
    }

    [Fact]
    public void GetCollectionCount_WhenCollectionIsList_ShouldReturnCollectionCount()
    {
        // Arrange
        var collection = new List<int> { 1 };

        // Act
        var count = Validator.GetCollectionCount(collection);

        // Assert
        Assert.Equal(collection.Count, count);
    }

    [Fact]
    public void GetCollectionCount_WhenCollectionIsDictionary_ShouldReturnCollectionCount()
    {
        // Arrange
        var collection = new Dictionary<int, int> { { 1, 1 } };

        // Act
        var count = Validator.GetCollectionCount(collection);

        // Assert
        Assert.Equal(collection.Count, count);
    }

    [Fact]
    public void GetCollectionCount_WhenCollectionIsIEnumerable_ShouldReturnEnumeratedCount()
    {
        // Arrange
        var numItems = 10;
        var collection = Enumerable.Range(0, numItems);

        // Act
        var count = Validator.GetCollectionCount(collection);

        // Assert
        Assert.Equal(numItems, count);
    }

    [Fact]
    public void GetCollectionCount_WhenCollectionIsString_ShouldReturnStringLength()
    {
        // Arrange
        var str = "hello";

        // Act
        var count = Validator.GetCollectionCount(str);

        // Assert
        Assert.Equal(str.Length, count);
    }
}
