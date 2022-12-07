using FluentAssertions;

namespace Day7.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var text = File.ReadAllText("TestData");
        text.Should().NotBeEmpty();
        First.Solve(text).Should().Be(95437);
    }
    
    [Test]
    public void Test2()
    {
        var text = File.ReadAllText("Data");
        text.Should().NotBeEmpty();
        First.Solve(text).Should().Be(2104783);
    }
    
    [Test]
    public void Test3()
    {
        var text = File.ReadAllText("TestData");
        text.Should().NotBeEmpty();
        Second.Solve(text).Should().Be(24933642);
    }
    
    [Test]
    public void Test4()
    {
        var text = File.ReadAllText("Data");
        text.Should().NotBeEmpty();
        Second.Solve(text).Should().Be(5883165);
    }
}