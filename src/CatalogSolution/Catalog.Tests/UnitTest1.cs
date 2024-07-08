namespace Catalog.Tests;

public class UnitTest1
{
    [Fact]
    public void TenPlus20IsThirty()
    {
        int a = 10, b = 20, answer;

        answer = a + b;

        Assert.Equal(30, answer);

    }

    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(2, 2, 4)]
    [InlineData(10, 3, 13)]
    public void CanAddTwoIntegers(int a, int b, int expected)
    {
        int answer = a + b;

        Assert.Equal(expected, answer);
    }
}