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
  public void Parse_ShouldReturnDomainLabel_WhenValidJustLabel(string enumLabel)
  {
    // Arrange
    IdentifierReturns(OutString(enumLabel));

    // Act
    IResult<IGqlpDomainLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainLabel_WhenValidTypeAndLabel(string enumType, string enumLabel)
  {
    // Arrange
    IdentifierReturns(OutString(enumType), OutString(enumLabel));
    TakeReturns('.', true);

    // Act
    IResult<IGqlpDomainLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainLabel_WhenValidTypeAndAsterisk(string enumType)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));
    TakeReturns('.', true);
    TakeReturns('*', true);

    // Act
    IResult<IGqlpDomainLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldPartial_WhenInvalidTypeAndOther(string enumType)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));
    TakeReturns('.', true);
    SetupPartial<IGqlpDomainLabel>();

    // Act
    IResult<IGqlpDomainLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpDomainLabel>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNothingAfterExclamation()
  {
    // Arrange
    TakeReturns('!', true);
    IdentifierReturns(OutFail);
    SetupPartial<IGqlpDomainLabel>();

    // Act
    IResult<IGqlpDomainLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpDomainLabel>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNothing()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpDomainLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
