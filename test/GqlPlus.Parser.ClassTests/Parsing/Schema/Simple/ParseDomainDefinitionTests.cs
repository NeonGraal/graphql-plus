using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainDefinitionTests
  : SimpleParserClassTestBase
{
  private readonly Parser<DomainKind>.I _kindParser;
  private readonly IParseDomain _domainParser = Substitute.For<IParseDomain>();
  private readonly ParseDomainDefinition _parser;

  public ParseDomainDefinitionTests()
  {
    _domainParser.Kind.Returns(DomainKind.Enum);
    Parser<IEnumParser<DomainKind>, DomainKind>.D kindParser = EnumParserFor(out _kindParser);
    _parser = new ParseDomainDefinition(TypeRef, kindParser, [_domainParser]);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDomainDefinition_WhenValid(string parentType)
  {
    // Arrange
    TakeReturns(':', true);
    ParseTypeRefOk(parentType);
    ParseOk(_kindParser, DomainKind.Enum);
    _domainParser.Parser(Tokenizer, "testLabel", Arg.Any<DomainDefinition>()).Returns(c => new DomainDefinition().Ok());

    // Act
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, "testLabel");

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
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, "testLabel");

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
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, "testLabel");

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
    IResult<DomainDefinition> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DomainDefinition>>();
  }
}
