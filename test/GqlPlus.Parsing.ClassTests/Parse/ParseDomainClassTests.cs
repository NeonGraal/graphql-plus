using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parse.Schema;
using GqlPlus.Parse.Schema.Simple;
using GqlPlus.Result;
using NSubstitute;

namespace GqlPlus.Parse;

public class ParseDomainClassTests : ClassTestBase
{
  [Theory, RepeatData(Repeats)]
  public void Parse_UnknownKind_ReturnsExpected(string name)
  {
    Token.Tokenizer tokens = Tokens("{ ");

    ISimpleName simpleName = NameFor<ISimpleName>(name);
    Parser<NullAst>.DA param = ArrayParserFor<NullAst>();
    Parser<string>.DA aliases = ArrayParserFor<string>();
    Parser<IOptionParser<NullOption>, NullOption>.D option = OptionParserFor<NullOption>();
    Parser<DomainDefinition>.D definition = ParserFor(out Parser<DomainDefinition>.I? definitionParser);
    definitionParser.Parse(tokens, default!)
      .ReturnsForAnyArgs(new DomainDefinition() { Kind = (DomainKind)99 }.Ok());

    ParseDomain domain = new(simpleName, param, aliases, option, definition);

    IResult<AstDomain> result = domain.Parse(tokens, "test");

    result.Should().BeAssignableTo<IResultOk<AstDomain>>();
  }
}
