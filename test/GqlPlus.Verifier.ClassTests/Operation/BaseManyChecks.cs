namespace GqlPlus.Verifier.Operation;

internal sealed class BaseManyChecks<T>
{
  internal delegate bool Many(ref OperationParser parser, out T[] result);

  private readonly Many _many;

  public BaseManyChecks(Many many)
    => _many = many;

  internal void TrueExpected(string input, params T[] expected)
  {
    var parser = new OperationParser(Tokens(input));

    _many(ref parser, out T[] result).Should().BeTrue();

    parser.Errors.Should().BeEmpty();
    result.Should().Equal(expected);
  }

  internal void False(string input)
  {
    var parser = new OperationParser(Tokens(input));

    _many(ref parser, out T[] result).Should().BeFalse();

    parser.Errors.Should().NotBeEmpty();
    result.Should().BeEmpty();
  }
}
