namespace GqlPlus.Parsing.Schema;

public class ParseNullsTests
  : ParserClassTestBase
{
  [Theory, RepeatData]
  public void ParseNulls_ReturnsExpected(string label)
  {
    ParseNulls parser = new();

    IResultArray<NullAst> result = parser.Parse(Tokenizer, label);

    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Theory, RepeatData]
  public void ParseNullOption_ReturnsExpected(string label)
  {
    ParseNullOption parser = new();

    IResult<NullOption> result = parser.Parse(Tokenizer, label);

    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
