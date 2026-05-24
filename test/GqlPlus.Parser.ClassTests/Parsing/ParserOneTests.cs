namespace GqlPlus.Parsing;

public class ParserOneTests
  : SubstituteBase
{
  [Theory, RepeatData]
  public void Parse_WhenCalled_DelegatesToValue(string label)
  {
    IParser<IAstError> inner = A.Of<IParser<IAstError>>();
    ITokenizer tokens = A.Of<ITokenizer>();
    IResult<IAstError> expected = A.Of<IResult<IAstError>>();
    inner.Parse(tokens, label).Returns(expected);

    ParserOne<IAstError> parser = new(() => inner);

    IResult<IAstError> result = parser.Parse(tokens, label);

    result.ShouldBeSameAs(expected);
  }

  [Theory, RepeatData]
  public void ImplicitConvert_FromDelegate_ReturnsParserOne(string label)
  {
    IParser<IAstError> inner = A.Of<IParser<IAstError>>();
    ITokenizer tokens = A.Of<ITokenizer>();
    IResult<IAstError> expected = A.Of<IResult<IAstError>>();
    inner.Parse(tokens, label).Returns(expected);

    ParserOne<IAstError>.D factory = () => inner;
    ParserOne<IAstError> result = factory;

    result.Parse(tokens, label).ShouldBeSameAs(expected);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    ParserOne<IAstError>.D? factory = null;

    Action result = () => _ = (ParserOne<IAstError>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }

  [Theory, RepeatData]
  public void Parse_TwoTypeParams_WhenCalled_DelegatesToValue(string label)
  {
    IParser<IAstError> inner = A.Of<IParser<IAstError>>();
    ITokenizer tokens = A.Of<ITokenizer>();
    IResult<IAstError> expected = A.Of<IResult<IAstError>>();
    inner.Parse(tokens, label).Returns(expected);

    ParserOne<IParser<IAstError>, IAstError> parser = new(() => inner);

    IResult<IAstError> result = parser.Parse(tokens, label);

    result.ShouldBeSameAs(expected);
  }

  [Theory, RepeatData]
  public void ImplicitConvert_TwoTypeParams_FromDelegate_ReturnsParserOne(string label)
  {
    IParser<IAstError> inner = A.Of<IParser<IAstError>>();
    ITokenizer tokens = A.Of<ITokenizer>();
    IResult<IAstError> expected = A.Of<IResult<IAstError>>();
    inner.Parse(tokens, label).Returns(expected);

    ParserOne<IParser<IAstError>, IAstError>.D factory = () => inner;
    ParserOne<IParser<IAstError>, IAstError> result = factory;

    result.Parse(tokens, label).ShouldBeSameAs(expected);
  }

  [Fact]
  public void ImplicitConvert_TwoTypeParams_NullFactory_ThrowsArgumentNullException()
  {
    ParserOne<IParser<IAstError>, IAstError>.D? factory = null;

    Action result = () => _ = (ParserOne<IParser<IAstError>, IAstError>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
