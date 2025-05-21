using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;
using NSubstitute;
using Shouldly;
using Xunit;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainTrueFalseTests : ParserClassTestBase
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
  public void Parse_ShouldReturnPartial_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpDomainTrueFalse> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
