namespace GqlPlus.Verifier.Operation;

internal sealed class BaseOneChecks<T>
{
  internal delegate bool One(ref OperationParser parser, out T result);

  private readonly One _one;

  public BaseOneChecks(One one)
    => _one = one;

  internal void TrueExpected(string input, T expected, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = new OperationParser(Tokens(input));

    _one(ref parser, out T result).Should().BeTrue();

    parser._errors.Should().BeEmpty();
    result.Should().Be(expected);
  }

  internal void False(string input, Action<T> check, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var parser = new OperationParser(Tokens(input));

    _one(ref parser, out T result).Should().BeFalse();

    parser._errors.Should().NotBeEmpty();
    check(result);
  }
}
