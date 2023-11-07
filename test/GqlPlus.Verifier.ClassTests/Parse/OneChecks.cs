using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier.Common;

internal class OneChecks<P, T>
  : BaseChecks<P> where P : CommonParser
{
  private readonly OneResult _one;
  private readonly string _oneExpression;

  public OneChecks(Factory factory, OneResult one,
    [CallerArgumentExpression(nameof(one))] string oneExpression = "")
    : base(factory)
    => (_one, _oneExpression) = (one, oneExpression);

  internal delegate IResult<T> OneResult(P parser);

  internal void TrueExpected(string input, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = Parser(input);

    var success = _one(parser);

    success.IsOk().Should().BeTrue(_oneExpression + " -> " + input);
    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    parser.Errors.Should().BeEmpty();
    success.Required().Should().Be(expected);
  }

  internal void False(string input, Action<T?>? check = null, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = Parser(input);

    var success = _one(parser);

    success.IsOk().Should().BeFalse(_oneExpression + " -> " + input);
    using var scope = new AssertionScope();
    parser.Errors.Should().NotBeEmpty();
    success.Optional(result => check?.Invoke(result));
  }
}
