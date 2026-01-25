using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputFieldTests
  : ObjectFieldParseTestBase<IGqlpOutputField>
{
  private readonly Parser<IGqlpInputParam>.IA _parameter;

  protected override Parser<IGqlpOutputField>.I Parser { get; }

  public ParseOutputFieldTests()
  {
    Parser<IGqlpInputParam>.DA parameter = ParserAFor(out _parameter);
    Parser = new ParseOutputField(Aliases, Modifiers, ParseBase, parameter);

    ParseEmptyA(_parameter);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnParams_WhenValid(string fieldName, string label)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseBaseOk();
    ParseOkA(_parameter);

    // Act
    IResult<IGqlpOutputField> result = Parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpOutputField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenParamsError(string fieldName, string label)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    ParseErrorA(_parameter);

    // Act
    IResult<IGqlpOutputField> result = Parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
