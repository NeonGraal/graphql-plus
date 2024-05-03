using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parse.Schema.Simple;
using GqlPlus.Result;
using NSubstitute;

namespace GqlPlus.Parse.Schema;

public class ParseDomainDefinitionClassTests : ClassTestBase
{
  [Fact]
  public void Parse_UnknownKind_ReturnsExpected()
  {
    var tokens = Tokens("{ ");

    var kind = EnumParserFor<DomainKind>(out var kindParser);
    kindParser.Parse(tokens, default!)
      .ReturnsForAnyArgs(((DomainKind)99).Ok());

    var domain = new ParseDomainDefinition(kind, []);

    var result = domain.Parse(tokens, "test");

    result.Should().BeAssignableTo<IResultPartial<DomainDefinition>>();
  }
}
