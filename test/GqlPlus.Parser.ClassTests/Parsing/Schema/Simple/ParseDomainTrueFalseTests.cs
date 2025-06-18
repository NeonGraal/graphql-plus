using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainTrueFalseTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpDomainTrueFalse>.IA _itemsParser;
  private readonly ParseDomainTrueFalse _parser;

  public ParseDomainTrueFalseTests()
  {
    Parser<IGqlpDomainTrueFalse>.DA itemsParser = ParserAFor(out _itemsParser);
    _parser = new ParseDomainTrueFalse(itemsParser);
  }

  [Fact]
  public void Parse_ShouldReturnDomainTrueFalse_WhenValid()
  {
    // Arrange
    IdentifierReturns(OutString("true"));

    // Act
    IResult<IGqlpDomainTrueFalse> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainTrueFalse>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNotBoolean()
  {
    // Arrange
    IdentifierReturns(OutString("phish"));
    SetupPartial<IGqlpDomainTrueFalse>();

    // Act
    IResult<IGqlpDomainTrueFalse> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpDomainTrueFalse>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNothingAfterExclamation()
  {
    // Arrange
    TakeReturns('!', true);
    IdentifierReturns(OutFail);
    SetupPartial<IGqlpDomainTrueFalse>();

    // Act
    IResult<IGqlpDomainTrueFalse> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpDomainTrueFalse>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNothing()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpDomainTrueFalse> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
