using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;
using GqlPlus.Result;
using NSubstitute;

namespace GqlPlus.Parsing;

public class ParseDomainClassTests : ClassTestBase
{
  [Theory, RepeatData]
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

    IResult<IGqlpDomain> result = domain.Parse(tokens, "test");

    result.ShouldBeAssignableTo<IResultOk<IGqlpDomain>>();
  }
}
