using FluentAssertions;

namespace Day3.Tests;

[TestFixture]
public class CharTest
{
    [Test]
    public void METHOD()
    {
        ("A".First()-38).Should().Be(27);
    }
    
    [Test]
    public void METHOD2()
    {
        ("a".First()-96).Should().Be(1);
    }

    [Test]
    public void METHOD3()
    {
        var hej = new List<string>()
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg"
        }.Aggregate((common, next) =>
        {
            return new string(common.Intersect(next).ToArray());
        });
        hej.Should().Be("r");
    }
}