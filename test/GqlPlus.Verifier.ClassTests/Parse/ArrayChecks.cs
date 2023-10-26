using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier.Common;

internal sealed class ArrayChecks<P, T>
  : BaseChecks<P> where P : CommonParser
{
  internal delegate T[] Array(P parser);

  private readonly Array _array;
  private readonly string _arrayExpression;

  public ArrayChecks(Factory factory, Array array,
    [CallerArgumentExpression(nameof(array))] string arrayExpression = "")
    : base(factory)
    => (_array, _arrayExpression) = (array, arrayExpression);

  internal void Expected(string input, params T[] expected)
  {
    var parser = Parser(input);

    var result = _array(parser);

    using var scope = new AssertionScope();

    parser.Errors.Should().BeEmpty();
    result.Should().NotBeNull(_arrayExpression).And.Equal(expected, _arrayExpression);
  }

  internal void JustErrors(string input)
  {
    var parser = Parser(input);

    var result = _array(parser);

    using var scope = new AssertionScope();

    parser.Errors.Should().NotBeEmpty();
    result.Should().BeEmpty(_arrayExpression);
  }

  internal void ErrorsExpected(string input, params T[] expected)
  {
    var parser = Parser(input);

    var result = _array(parser);

    using var scope = new AssertionScope();

    parser.Errors.Should().NotBeEmpty();
    result.Should().NotBeNull(_arrayExpression).And.Equal(expected, _arrayExpression);
  }

  internal void Count(string input, int count)
  {
    var parser = Parser(input);

    var result = _array(parser);

    result.Length.Should().Be(count, _arrayExpression);
  }
}
