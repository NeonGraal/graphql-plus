using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing.Schema;

public class OptionParserTests
  : ParserClassTestBase
{
  private readonly IEnumParser<DomainKind> _domainParser;
  private readonly OptionParser<DomainKind> _parser;

  public OptionParserTests()
  {
    Parser<IEnumParser<DomainKind>, DomainKind>.D domainParser = EnumParserFor<DomainKind>(out _domainParser);
    _parser = new OptionParser<DomainKind>(domainParser);
    SetupPartial(DomainKind.Number);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOption_WhenValid(string label)
  {
    // Arrange
    TakeReturns('(', true);
    ParseOk(_domainParser, DomainKind.Number);
    TakeReturns(')', true);

    // Act
    IResult<DomainKind> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<DomainKind>>()
      .Required().ShouldBe(DomainKind.Number);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenClosingParenthesisIsMissing(string label)
  {
    // Arrange
    TakeReturns('(', true);
    ParseOk(_domainParser, DomainKind.Number);
    TakeReturns(')', false);

    // Act
    IResult<DomainKind> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DomainKind>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmpty_WhenNoOpeningParenthesis(string label)
  {
    // Arrange
    TakeReturns('(', false);

    // Act
    IResult<DomainKind> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
