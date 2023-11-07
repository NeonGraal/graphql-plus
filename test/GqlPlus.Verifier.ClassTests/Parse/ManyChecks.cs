using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier.Common;

internal sealed class ManyChecks<P, T>
  : BaseChecks<P> where P : CommonParser
{
  internal delegate bool Many(P parser, out T[] result);

  private readonly ManyResult _many;
  private readonly string _manyExpression;

  public ManyChecks(Factory factory, ManyResult many,
    [CallerArgumentExpression(nameof(many))] string manyExpression = "")
    : base(factory)
    => (_many, _manyExpression) = (many, manyExpression);

  internal delegate IResultArray<T> ManyResult(P parser);

  internal void TrueExpected(string input, bool skipIf, params T[] expected)
  {
    if (!skipIf) {
      TrueExpected(input, expected);
    }
  }

  internal void TrueExpected(string input, params T[] expected)
  {
    var parser = Parser(input);

    var success = _many(parser);

    success.IsOk().Should().BeTrue(_manyExpression);
    using var scope = new AssertionScope();
    parser.Errors.Should().BeEmpty();
    success.Required().Should().Equal(expected);
  }

  internal void False(string input)
  {
    var parser = Parser(input);

    var success = _many(parser);

    success.IsOk().Should().BeFalse(_manyExpression);
    using var scope = new AssertionScope();
    parser.Errors.Should().NotBeEmpty();
  }

  internal void Count(string input, int count)
  {
    var parser = Parser(input);

    var success = _many(parser);

    success.IsOk().Should().BeTrue(_manyExpression);
    using var scope = new AssertionScope();
    parser.Errors.Should().BeEmpty();
    success.Required().Length.Should().Be(count);
  }
}
