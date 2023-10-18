namespace GqlPlus.Verifier.Common;

internal sealed class BaseArrayChecks<P, T>
  : BaseChecks<P> where P : CommonParser
{
  internal delegate T[] Array(P parser);

  private readonly Array _array;

  public BaseArrayChecks(Factory factory, Array array)
    : base(factory)
    => _array = array;

  internal void Expected(string input, params T[] expected)
  {
    var parser = Parser(input);

    var result = _array(parser);

    parser.Errors.Should().BeEmpty();
    result.Should().NotBeNull().And.Equal(expected);
  }

  internal void JustErrors(string input)
  {
    var parser = Parser(input);

    var result = _array(parser);

    parser.Errors.Should().NotBeEmpty();
    result.Should().BeEmpty();
  }

  internal void ErrorsExpected(string input, params T[] expected)
  {
    var parser = Parser(input);

    var result = _array(parser);

    parser.Errors.Should().NotBeEmpty();
    result.Should().NotBeNull().And.Equal(expected);
  }

  internal void Count(string input, int count)
  {
    var parser = Parser(input);

    var result = _array(parser);

    result.Length.Should().Be(count);
  }
}
