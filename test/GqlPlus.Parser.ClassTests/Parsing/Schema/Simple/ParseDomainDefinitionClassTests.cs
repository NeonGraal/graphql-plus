using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainDefinitionClassTests : ParserClassTestBase
{
  [Fact]
  public void Parse_UnknownKind_ReturnsExpected()
  {
    Token.ITokenizer tokens = Tokens("{ ");

    Parser<IEnumParser<DomainKind>, DomainKind>.D kind = EnumParserFor(out Parser<DomainKind>.I? kindParser);
    kindParser.Parse(tokens, default!)
      .ReturnsForAnyArgs(((DomainKind)99).Ok());

    ParseDomainDefinition domain = new(kind, []);

    IResult<DomainDefinition> result = domain.Parse(tokens, "test");

    result.ShouldBeAssignableTo<IResultPartial<DomainDefinition>>();
  }
}
