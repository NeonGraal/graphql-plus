namespace GqlPlus.Parsing.Schema;

public class ParseNullsTests
  : ParserClassTestBase
{
  private const string TestLabel = "testLabel";

  [Fact]
  public void ParseNulls_ReturnsExpected()
  {
    ParseNulls parser = new();

    IResultArray<NullAst> result = parser.Parse(Tokenizer, TestLabel);

    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Fact]
  public void ParseNullOption_ReturnsExpected()
  {
    ParseNullOption parser = new();

    IResult<NullOption> result = parser.Parse(Tokenizer, TestLabel);

    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
