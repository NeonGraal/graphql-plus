namespace GqlPlus.Verifier.Common;

internal sealed class BaseManyChecks<P, T>
  : BaseChecks<P> where P : CommonParser
{
  internal delegate bool Many(P parser, out T[] result);

  private readonly Many _many;

  public BaseManyChecks(Factory factory, Many many)
    : base(factory)
    => _many = many;

  internal void TrueExpected(string input, params T[] expected)
  {
    var parser = Parser(input);

    _many(parser, out T[] result).Should().BeTrue();

    using var scope = new AssertionScope();

    parser.Errors.Should().BeEmpty();
    result.Should().Equal(expected);
  }

  internal void False(string input)
  {
    var parser = Parser(input);

    _many(parser, out T[] result).Should().BeFalse();

    using var scope = new AssertionScope();

    parser.Errors.Should().NotBeEmpty();
    result.Should().BeEmpty();
  }
}
