using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Common;

internal sealed class ManyChecks<P, T>
  : BaseChecks<P> where P : CommonParser
{
  internal delegate bool Many(P parser, out T[] result);

  private readonly Many _many;
  private readonly string _manyExpression;

  public ManyChecks(Factory factory, Many many,
    [CallerArgumentExpression(nameof(many))] string manyExpression = "")
    : base(factory)
    => (_many, _manyExpression) = (many, manyExpression);

  internal void TrueExpected(string input, params T[] expected)
  {
    var parser = Parser(input);

    var success = _many(parser, out T[] result);

    success.Should().BeTrue(_manyExpression);
    using var scope = new AssertionScope();
    parser.Errors.Should().BeEmpty();
    result.Should().Equal(expected);
  }

  internal void False(string input)
  {
    var parser = Parser(input);

    var success = _many(parser, out T[] result);

    success.Should().BeFalse(_manyExpression);
    using var scope = new AssertionScope();
    parser.Errors.Should().NotBeEmpty();
    result.Should().BeEmpty();
  }
}
