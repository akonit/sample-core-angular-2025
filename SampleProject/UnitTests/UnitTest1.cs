namespace UnitTests;

public class UnitTest1
{
    [Fact]
    public void CheckTestsAreRunning()
    {
        // Arrange
        var first = 1;
        var second = 2;

        // Act
        var result = first + second;

        // Assert
        Assert.Equal(3, result);
    }
}
