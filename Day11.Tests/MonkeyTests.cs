using FluentAssertions;

namespace Day11.Tests;

[TestFixture]
public class MonkeyTests
{
    [Test]
    public void Should_Map()
    {
        var text = File.ReadAllText("MonkeyTestData");
        text.Should().NotBeEmpty();

        var monkey = new First.Monkey(text);

        monkey.TimesInspected.Should().Be(0);
        monkey.Items.Should().Contain( x => x == 62 || x == 92);
        monkey.DivideBy.Should().Be(2);
        monkey.IfTrueThrowTo.Should().Be(7);
        monkey.IfFalseThrowTo.Should().Be(1);
        monkey.Operator.Should().Be("*");
        monkey.OperateWith.Should().Be(7);

        monkey.Operate(4).Should().Be(7 * 4);
    }
}