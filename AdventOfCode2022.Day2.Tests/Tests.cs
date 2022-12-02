using AdventOfCode.Day2;
using FluentAssertions;

namespace AdventOfCode2022.Day2.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var text = File.ReadAllText("TestData");
        text.Should().NotBeEmpty();
        First.Solve(text).Should().Be(15);
    }
    
    [Test]
    public void Test2()
    {
        var text = File.ReadAllText("Data");
        text.Should().NotBeEmpty();
        First.Solve(text).Should().Be(11873);
    }
    
    [Test]
    public void Test3()
    {
        var text = File.ReadAllText("TestData");
        text.Should().NotBeEmpty();
        Second.Solve(text).Should().Be(12);
    }
    
    [Test]
    public void Test4()
    {
        var text = File.ReadAllText("Data");
        text.Should().NotBeEmpty();
        Second.Solve(text).Should().Be(12014);
    }
}