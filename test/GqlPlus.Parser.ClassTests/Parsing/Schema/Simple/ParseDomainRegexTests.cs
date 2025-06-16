using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainRegexTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpDomainRegex>.IA _itemsParser;
  private readonly ParseDomainRegex _parser;

  public ParseDomainRegexTests()
  {
    Parser<IGqlpDomainRegex>.DA itemsParser = ParserAFor(out _itemsParser);
    _parser = new ParseDomainRegex(itemsParser);
  }

  [Fact]
  public void ParseItems_ShouldReturnDomainTrueFalse_WhenValid()
  {
    // Arrange
    TakeReturns('}', true);
    DomainDefinition initial = new() { Kind = DomainKind.String };
    ParseOkA(_itemsParser);

    // Act
    IResult<DomainDefinition> result = _parser.Parser(Tokenizer, "testLabel", initial);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<DomainDefinition>>();
  }

  [Fact]
  public void ParseItems_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    DomainDefinition initial = new() { Kind = DomainKind.String };
    ParseErrorA(_itemsParser);

    // Act
    IResult<DomainDefinition> result = _parser.Parser(Tokenizer, "testLabel", initial);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnDomainRegex_WhenValid()
  {
    // Arrange
    Tokenizer.Regex(out _).Returns(OutString(".*"));

    // Act
    IResult<IGqlpDomainRegex> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomainRegex>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Regex(out _).Returns(OutFail);

    // Act
    IResult<IGqlpDomainRegex> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
