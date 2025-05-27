using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputFieldTests
  : AliasesClassTestBase
{
  private readonly Parser<IGqlpOutputBase>.I _parseBase;
  private readonly Parser<IGqlpInputParam>.IA _parameter;
  private readonly ParseOutputField _parser;

  public ParseOutputFieldTests()
  {
    Parser<IGqlpOutputBase>.D parseBase = ParserFor(out _parseBase);
    Parser<IGqlpInputParam>.DA parameter = ParserAFor(out _parameter);
    _parser = new ParseOutputField(Aliases, Modifiers, parseBase, parameter);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOutputField_WhenValid(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true, false);
    ParseOk(_parseBase);

    // Act
    IResult<IGqlpOutputField> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpOutputField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumField_WhenValid(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns('=', true, false);
    ParseOk(_parseBase);

    // Act
    IResult<IGqlpOutputField> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpOutputField>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoFieldName()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpOutputField> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
