using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parse.Schema.Simple;
using GqlPlus.Result;
using NSubstitute;

namespace GqlPlus.Parse;

public class ParseDomainDefinitionClassTests : ClassTestBase
{
  [Fact]
  public void Parse_UnknownKind_ReturnsExpected()
  {
    Token.Tokenizer tokens = Tokens("{ ");

    Parser<IEnumParser<DomainKind>, DomainKind>.D kind = EnumParserFor(out Parser<DomainKind>.I? kindParser);
    kindParser.Parse(tokens, default!)
      .ReturnsForAnyArgs(((DomainKind)99).Ok());

    ParseDomainDefinition domain = new(kind, []);

    IResult<DomainDefinition> result = domain.Parse(tokens, "test");

    result.Should().BeAssignableTo<IResultPartial<DomainDefinition>>();
  }
}
