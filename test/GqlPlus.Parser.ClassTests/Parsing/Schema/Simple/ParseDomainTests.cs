using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainTests
  : DeclarationClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly Parser<DomainDefinition>.I _definition;
  private readonly ParseDomain _parser;

  public ParseDomainTests()
  {

    Parser<DomainDefinition>.D definition = ParserFor(out _definition);
    _parser = new ParseDomain(SimpleName, ParamNull, Aliases, OptionNull, definition);
  }

  [Theory]
  [RepeatInlineData(DomainKind.Boolean)]
  [RepeatInlineData(DomainKind.Enum)]
  [RepeatInlineData(DomainKind.Number)]
  [RepeatInlineData(DomainKind.String)]
  [RepeatInlineData((DomainKind)99)]
  public void Parse_ShouldReturnDomain_WhenValid(DomainKind domainKind, string domainName, string enumType, string enumLabel)
  {
    // Arrange
    NameReturns(domainName);
    IGqlpDomainLabel domainLabel = A.DomainLabel(enumType, enumLabel);
    DomainDefinition definition = new() { Kind = domainKind, Labels = [domainLabel] };
    ParseOk(_definition, definition);

    // Act
    IResult<IGqlpDomain> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDomain>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    NameFails();
    SetupError<IGqlpDomain>();

    // Act
    IResult<IGqlpDomain> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
