using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainLabelTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpDomainLabel>.IA _itemsParser;
  private readonly ParseDomainLabel _parser;

  public ParseDomainLabelTests()
  {
    Parser<IGqlpDomainLabel>.DA itemsParser = ParserAFor(out _itemsParser);
    _parser = new ParseDomainLabel(itemsParser);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainLabel_WhenValid(string enumType)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));

    // Act
    IResult<IGqlpDomainLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainLabel>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpDomainLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
