using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing.Schema;

public class OptionParserTests
  : ParserClassTestBase
{
  private readonly Parser<DomainKind>.I _domainParser;
  private readonly OptionParser<DomainKind> _parser;

  public OptionParserTests()
  {
    Parser<IEnumParser<DomainKind>, DomainKind>.D domainParser = ParserFor<IEnumParser<DomainKind>, DomainKind>(out _domainParser);
    _parser = new OptionParser<DomainKind>(domainParser);
    SetupPartial(DomainKind.Number);
  }

  [Fact]
  public void Parse_ShouldReturnOption_WhenValid()
  {
    // Arrange
    TakeReturns('(', true);
    ParseOk(_domainParser, DomainKind.Number);
    TakeReturns(')', true);

    // Act
    IResult<DomainKind> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<DomainKind>>()
      .Required().ShouldBe(DomainKind.Number);
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenClosingParenthesisIsMissing()
  {
    // Arrange
    TakeReturns('(', true);
    ParseOk(_domainParser, DomainKind.Number);
    TakeReturns(')', false);

    // Act
    IResult<DomainKind> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DomainKind>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoOpeningParenthesis()
  {
    // Arrange
    TakeReturns('(', false);

    // Act
    IResult<DomainKind> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty<DomainKind>>();
  }
}
