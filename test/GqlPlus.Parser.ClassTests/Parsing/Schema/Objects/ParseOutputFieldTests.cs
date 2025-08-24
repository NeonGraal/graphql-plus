using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputFieldTests
  : ParseObjectFieldTestBase<IGqlpOutputField, IGqlpOutputBase>
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
  public void Parse_ShouldReturnParams_WhenValid(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseBaseOk();
    ParseOkA(_parameter);

    // Act
    IResult<IGqlpOutputField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpOutputField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenParamsError(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    ParseErrorA(_parameter);

    // Act
    IResult<IGqlpOutputField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumField_WhenValidLabel(string fieldName, string[] aliases, string label)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName), OutString(label));
    TakeReturns('=', true);
    ParseAliasesOk(aliases);

    // Act
    IResult<IGqlpOutputField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpOutputField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumField_WhenValidEnum(string fieldName, string[] aliases, string type, string label)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName), OutString(type), OutString(label));
    TakeReturns('=', true);
    ParseAliasesOk(aliases);
    TakeReturns('.', true);

    // Act
    IResult<IGqlpOutputField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpOutputField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenInvalidLabel(string fieldName, string[] aliases)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName), OutFail);
    TakeReturns('=', true);
    ParseAliasesOk(aliases);
    SetupPartial<IGqlpOutputField>();

    // Act
    IResult<IGqlpOutputField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpOutputField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenInvalidEnum(string fieldName, string[] aliases, string type)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName), OutString(type), OutFail);
    TakeReturns('=', true);
    ParseAliasesOk(aliases);
    TakeReturns('.', true);
    SetupPartial<IGqlpOutputField>();

    // Act
    IResult<IGqlpOutputField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpOutputField>>();
  }
}
