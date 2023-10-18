namespace GqlPlus.Verifier.Common;

internal sealed class BaseOneChecks<P, T>
  : BaseChecks<P> where P : CommonParser
{
  internal delegate bool One(P parser, out T result);

  private readonly One _one;

  public BaseOneChecks(Factory factory, One one)
    : base(factory)
    => _one = one;

  internal void TrueExpected(string input, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = Parser(input);

    _one(parser, out T result).Should().BeTrue();

    parser.Errors.Should().BeEmpty();
    result.Should().Be(expected);
  }

  internal void False(string input, Action<T> check, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = Parser(input);

    _one(parser, out T result).Should().BeFalse();

    parser.Errors.Should().NotBeEmpty();
    check(result);
  }
}
