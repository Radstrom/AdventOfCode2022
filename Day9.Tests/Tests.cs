using FluentAssertions;

namespace Day9.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var text = File.ReadAllText("TestData");
        text.Should().NotBeEmpty();
        First.Solve(text).Should().Be(13);
    }

    [Test]
    public void Test2()
    {
        var text = File.ReadAllText("Data");
        text.Should().NotBeEmpty();
        First.Solve(text).Should().Be(6181);
    }
    
    [Test]
    public void Test3()
    {
        var text = File.ReadAllText("TestData2");
        text.Should().NotBeEmpty();
        Second.Solve(text).Should().Be(36);
    }
    
    [Test]
    public void Test4()
    {
        var text = File.ReadAllText("Data");
        text.Should().NotBeEmpty();
        Second.Solve(text).Should().Be(2386);
    }
}