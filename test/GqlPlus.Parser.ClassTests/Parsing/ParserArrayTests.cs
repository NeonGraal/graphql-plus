namespace GqlPlus.Parsing;

public class ParserArrayTests
  : SubstituteBase
{
  [Theory, RepeatData]
  public void Parse_WhenCalled_DelegatesToValue(string label)
  {
    IParserArray<IAstError> inner = A.Of<IParserArray<IAstError>>();
    ITokenizer tokens = A.Of<ITokenizer>();
    IResultArray<IAstError> expected = A.Of<IResultArray<IAstError>>();
    inner.Parse(tokens, label).Returns(expected);

    ParserArray<IAstError> parser = new(() => inner);

    IResultArray<IAstError> result = parser.Parse(tokens, label);

    result.ShouldBeSameAs(expected);
  }

  [Theory, RepeatData]
  public void ImplicitConvert_FromDelegate_ReturnsParserArray(string label)
  {
    IParserArray<IAstError> inner = A.Of<IParserArray<IAstError>>();
    ITokenizer tokens = A.Of<ITokenizer>();
    IResultArray<IAstError> expected = A.Of<IResultArray<IAstError>>();
    inner.Parse(tokens, label).Returns(expected);

    ParserArray<IAstError>.D factory = () => inner;
    ParserArray<IAstError> result = factory;

    result.Parse(tokens, label).ShouldBeSameAs(expected);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    ParserArray<IAstError>.D? factory = null;

    Action result = () => _ = (ParserArray<IAstError>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }

  [Theory, RepeatData]
  public void Parse_TwoTypeParams_WhenCalled_DelegatesToValue(string label)
  {
    IParserArray<IAstError> inner = A.Of<IParserArray<IAstError>>();
    ITokenizer tokens = A.Of<ITokenizer>();
    IResultArray<IAstError> expected = A.Of<IResultArray<IAstError>>();
    inner.Parse(tokens, label).Returns(expected);

    ParserArray<IParserArray<IAstError>, IAstError> parser = new(() => inner);

    IResultArray<IAstError> result = parser.Parse(tokens, label);

    result.ShouldBeSameAs(expected);
  }

  [Theory, RepeatData]
  public void ImplicitConvert_TwoTypeParams_FromDelegate_ReturnsParserArray(string label)
  {
    IParserArray<IAstError> inner = A.Of<IParserArray<IAstError>>();
    ITokenizer tokens = A.Of<ITokenizer>();
    IResultArray<IAstError> expected = A.Of<IResultArray<IAstError>>();
    inner.Parse(tokens, label).Returns(expected);

    ParserArray<IParserArray<IAstError>, IAstError>.D factory = () => inner;
    ParserArray<IParserArray<IAstError>, IAstError> result = factory;

    result.Parse(tokens, label).ShouldBeSameAs(expected);
  }

  [Fact]
  public void ImplicitConvert_TwoTypeParams_NullFactory_ThrowsArgumentNullException()
  {
    ParserArray<IParserArray<IAstError>, IAstError>.D? factory = null;

    Action result = () => _ = (ParserArray<IParserArray<IAstError>, IAstError>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
