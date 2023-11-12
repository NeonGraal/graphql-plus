using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Parse;

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

  internal void Ok(string input, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = Parser(input);

    var success = _one(parser);

    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    success.IsOk().Should().BeTrue(_oneExpression + " -> " + input);
    parser.Errors.Should().BeEmpty();
    success.Required().Should().Be(expected);
  }

  internal void Partial(string input, string error, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = Parser(input);

    var success = _one(parser);

    success.IsError().Should().BeTrue(_oneExpression + " -> " + input);
    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    parser.Errors.Should().NotBeEmpty()
      .And.Contain(pm => pm.Message.Contains(error));
    success.Optional().Should().Be(expected);
  }

  internal void Error(string input, string error, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = Parser(input);

    var success = _one(parser);

    success.IsError().Should().BeTrue(_oneExpression + " -> " + input);
    using var scope = new AssertionScope();
    scope.FormattingOptions.MaxDepth = 10;
    parser.Errors.Should().NotBeEmpty()
      .And.Contain(pm => pm.Message.Contains(error));
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
