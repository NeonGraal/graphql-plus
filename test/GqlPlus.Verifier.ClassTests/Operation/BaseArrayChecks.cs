namespace GqlPlus.Verifier.Operation;

internal sealed class BaseArrayChecks<T>
{
  internal delegate T[] Array(ref OperationParser parser);

  private readonly Array _array;

  public BaseArrayChecks(Array array)
    => _array = array;

  internal void Expected(string input, params T[] expected)
  {
    var parser = new OperationParser(Tokens(input));

    var result = _array(ref parser);

    parser.Errors.Should().BeEmpty();
    result.Should().NotBeNull().And.Equal(expected);
  }

  internal void JustErrors(string input)
  {
    var parser = new OperationParser(Tokens(input));

    var result = _array(ref parser);

    parser.Errors.Should().NotBeEmpty();
    result.Should().BeEmpty();
  }

  internal void ErrorsExpected(string input, params T[] expected)
  {
    var parser = new OperationParser(Tokens(input));

    var result = _array(ref parser);

    parser.Errors.Should().NotBeEmpty();
    result.Should().NotBeNull().And.Equal(expected);
  }

  internal void Count(string input, int count)
  {
    var parser = new OperationParser(Tokens(input));

    var result = _array(ref parser);

    result.Length.Should().Be(count);
  }
}
