using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier.Common;

internal class OneChecks<P, T>
  : BaseChecks<P> where P : CommonParser
{
  internal delegate bool One(P parser, out T result);

  private readonly One _one;
  private readonly string _oneExpression;

  public OneChecks(Factory factory, One one,
    [CallerArgumentExpression(nameof(one))] string oneExpression = "")
    : base(factory)
    => (_one, _oneExpression) = (one, oneExpression);

  internal void TrueExpected(string input, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = Parser(input);

    var success = _one(parser, out T result);

    success.Should().BeTrue(_oneExpression);
    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    parser.Errors.Should().BeEmpty();
    result.Should().Be(expected);
  }

  internal void False(string input, Action<T> check, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = Parser(input);

    var success = _one(parser, out T result);

    success.Should().BeFalse(_oneExpression);
    using var scope = new AssertionScope();
    parser.Errors.Should().NotBeEmpty();
    check(result);
  }
}
