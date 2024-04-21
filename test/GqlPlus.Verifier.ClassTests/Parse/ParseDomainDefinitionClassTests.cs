using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using NSubstitute;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseDomainDefinitionClassTests : ClassTestBase
{
  [Fact]
  public void Parse_UnknownKind_ReturnsExpected()
  {
    var tokens = Tokens("{ ");

    var kind = EnumParserFor<DomainDomain>(out var kindParser);
    kindParser.Parse(tokens, default!)
      .ReturnsForAnyArgs(((DomainDomain)99).Ok());

    var domain = new ParseDomainDefinition(kind, []);

    var result = domain.Parse(tokens, "test");

    result.Should().BeAssignableTo<IResultPartial<DomainDefinition>>();
  }
}
