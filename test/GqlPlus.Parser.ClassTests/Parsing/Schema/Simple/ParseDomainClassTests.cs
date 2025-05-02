using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseDomainClassTests : ParserClassTestBase
{
  [Theory, RepeatData]
  public void Parse_UnknownKind_ReturnsExpected(string name)
  {
    Token.ITokenizer tokens = Tokens("{ ");

    ISimpleName simpleName = NameFor<ISimpleName>(name);
    Parser<NullAst>.DA param = ParserAFor<NullAst>();
    Parser<string>.DA aliases = ParserAFor<string>();
    Parser<IOptionParser<NullOption>, NullOption>.D option = OptionParserFor<NullOption>();
    Parser<DomainDefinition>.D definition = ParserFor(out Parser<DomainDefinition>.I? definitionParser);
    definitionParser.Parse(tokens, default!)
      .ReturnsForAnyArgs(new DomainDefinition() { Kind = (DomainKind)99 }.Ok());

    ParseDomain domain = new(simpleName, param, aliases, option, definition);

    IResult<IGqlpDomain> result = domain.Parse(tokens, "test");

    result.ShouldBeAssignableTo<IResultOk<IGqlpDomain>>();
  }
}
