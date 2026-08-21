using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parser.Schema.Simple;

public sealed class ParseUnionMemberTests(ComponentFixture<Startup> fixture)
  : BaseNamedTests<string, IAstUnionMember>(fixture.GetService<IBaseNamedChecks<string, IAstUnionMember>>())
  , IClassFixture<ComponentFixture<Startup>>;

internal sealed class ParseUnionMemberChecks(
  IParserRepository parsers
) : BaseNamedChecks<string, UnionMemberAst, IAstUnionMember>(parsers)
{
  protected internal override UnionMemberAst NamedFactory(string input)
    => new(AstNulls.At, input, "");
  protected internal override string NameString(string input)
    => input;
}
