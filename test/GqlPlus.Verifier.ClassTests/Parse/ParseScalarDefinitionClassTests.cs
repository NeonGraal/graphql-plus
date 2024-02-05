using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using NSubstitute;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseScalarDefinitionClassTests : ClassTestBase
{
  [Fact]
  public void Parse_UnknownKind_ReturnsExpected()
  {
    var tokens = Tokens("{ ");

    var kind = EnumParserFor<ScalarKind>(out var kindParser);
    kindParser.Parse(tokens, default!)
      .ReturnsForAnyArgs(((ScalarKind)99).Ok());

    var scalar = new ParseScalarDefinition(kind, []);

    var result = scalar.Parse(tokens, "test");

    result.Should().BeAssignableTo<IResultPartial<ScalarDefinition>>();
  }
}
