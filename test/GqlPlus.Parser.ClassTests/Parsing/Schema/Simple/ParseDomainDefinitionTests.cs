using GqlPlus.Abstractions.Schema;

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
    Parser<IEnumParser<DomainKind>, DomainKind>.D kindParser = EnumParserFor(out _kindParser);
    _parser = new ParseDomainDefinition(TypeRef, kindParser, [_domainParser]);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainDefinition_WhenValid(string parentType, string label)
  {
    // Arrange
    TakeReturns(':', true);
    ParseTypeRefOk(parentType);
    ParseOk(_kindParser, DomainKind.Enum);
    _domainParser.Parser(Tokenizer, label, Arg.Any<DomainDefinition>()).Returns(c => new DomainDefinition().Ok());

    // Act
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<DomainDefinition>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialDomainDefinition_WhenKindInvalid(string parentType, string label)
  {
    // Arrange
    TakeReturns(':', true);
    ParseTypeRefOk(parentType);
    ParseOk(_kindParser, (DomainKind)99);
    SetupPartial(new DomainDefinition());

    // Acts
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DomainDefinition>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenParentTypeInvalid(string label)
  {
    // Arrange
    TakeReturns(':', true);
    IdentifierReturns(OutFail);
    SetupError<DomainDefinition>();

    // Act
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError<DomainDefinition>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenKindParsingFails(string label)
  {
    // Arrange
    ParseError(_kindParser);
    SetupPartial(new DomainDefinition());

    // Act
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DomainDefinition>>();
  }
}
