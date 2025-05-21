using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualFieldTests
  : AliasesClassTestBase
{
  private readonly Parser<IGqlpDualBase>.I _parseBase;
  private readonly ParseDualField _parser;

  public ParseDualFieldTests()
  {
    Parser<IGqlpDualBase>.D parseBase = ParserFor(out _parseBase);
    _parser = new ParseDualField(Aliases, Modifiers, parseBase);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDualField_WhenValid(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true, false);
    ParseOk(_parseBase);

    // Act
    IResult<IGqlpDualField> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDualField>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoFieldName()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpDualField> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
