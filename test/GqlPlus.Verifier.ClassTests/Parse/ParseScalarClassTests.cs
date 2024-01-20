using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using NSubstitute;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseScalarClassTests : ClassTestBase
{
  [Theory, RepeatData(Repeats)]
  public void Parse_UnknownKind_ReturnsExpected(string name)
  {
    var tokens = Tokens("{ ");

    var simpleName = NameFor<ISimpleName>(name);
    var param = ArrayParserFor<NullAst>();
    var aliases = ArrayParserFor<string>();
    var option = OptionParserFor<NullOption>();
    var definition = ParserFor<ScalarDefinition>(out var definitionParser);
    definitionParser.Parse(tokens, default!)
      .ReturnsForAnyArgs(new ScalarDefinition() { Kind = (ScalarKind)99 }.Ok());

    var scalar = new ParseScalar(simpleName, param, aliases, option, definition);

    var result = scalar.Parse(tokens, "test");

    result.Should().BeAssignableTo<IResultOk<AstScalar>>();
  }
}
