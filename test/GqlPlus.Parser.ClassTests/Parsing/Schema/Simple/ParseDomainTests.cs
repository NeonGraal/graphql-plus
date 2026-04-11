using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainTests
  : DeclarationClassTestBase
{

  private readonly Parser<DomainDefinition>.I _definition;
  private readonly ParseDomain _parser;

  public ParseDomainTests()
  {
    ConfigureRepo<DomainDefinition>(Parsers, out _definition);
    _parser = new ParseDomain(Parsers);
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
    IAstDomainLabel domainLabel = A.ItemLabel(enumType, enumLabel);
    DomainDefinition definition = new() { Kind = domainKind, Labels = [domainLabel] };
    ParseOk(_definition, definition);

    // Act
    IResult<IAstDomain> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstDomain>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    NameFails();
    SetupError<IAstDomain>();

    // Act
    IResult<IAstDomain> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
