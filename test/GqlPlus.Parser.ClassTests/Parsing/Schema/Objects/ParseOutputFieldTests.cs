using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputFieldTests
  : ObjectFieldParseTestBase<IAstOutputField>
{

  private readonly Parser<IAstInputParam>.IA _parameter;

  protected override Parser<IAstOutputField>.I Parser { get; }

  public ParseOutputFieldTests()
  {
    ConfigureRepoArray<IAstInputParam>(Parsers, out _parameter);
    Parser = new ParseOutputField(Parsers);
    ParseEmptyA(_parameter);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnParams_WhenValid(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseBaseOk();
    ParseOkA(_parameter);

    // Act
    IResult<IAstOutputField> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstOutputField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenParamsError(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    ParseErrorA(_parameter);

    // Act
    IResult<IAstOutputField> result = Parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
