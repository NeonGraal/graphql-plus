using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainDefinitionTests
  : SimpleParserClassTestBase
{

  private readonly IEnumParser<DomainKind> _kindParser;
  private readonly IParseDomain _domainParser = Substitute.For<IParseDomain>();
  private readonly ParseDomainDefinition _parser;

  public ParseDomainDefinitionTests()
  {
    _domainParser.Kind.Returns(DomainKind.Enum);
    Parsers.GetDomains().ReturnsForAnyArgs([_domainParser]);
    ConfigureRepoInterface<IEnumParser<DomainKind>, DomainKind>(Parsers, out _kindParser);
    _parser = new ParseDomainDefinition(Parsers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainDefinition_WhenValid(string parentType)
  {
    // Arrange
    TakeReturns(':', true);
    ParseTypeRefOk(parentType);
    ParseOk(_kindParser, DomainKind.Enum);
    _domainParser.Parser(Tokenizer, TestLabel, Arg.Any<DomainDefinition>()).Returns(c => new DomainDefinition().Ok());

    // Act
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<DomainDefinition>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialDomainDefinition_WhenKindInvalid(string parentType)
  {
    // Arrange
    TakeReturns(':', true);
    ParseTypeRefOk(parentType);
    ParseOk(_kindParser, (DomainKind)99);
    SetupPartial(new DomainDefinition());

    // Acts
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DomainDefinition>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenParentTypeInvalid()
  {
    // Arrange
    TakeReturns(':', true);
    IdentifierReturns(OutFail);
    SetupError<DomainDefinition>();

    // Act
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError<DomainDefinition>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenKindParsingFails()
  {
    // Arrange
    ParseError(_kindParser);
    SetupPartial(new DomainDefinition());

    // Act
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DomainDefinition>>();
  }
}
