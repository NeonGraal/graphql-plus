using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parser.Schema.Simple;

public sealed class ParseUnionMemberTests(
  IBaseNamedChecks<string, IGqlpUnionMember> checks
) : BaseNamedTests<string, IGqlpUnionMember>(checks)
{ }

internal sealed class ParseUnionMemberChecks(
  IParserRepository parsers
) : BaseNamedChecks<string, UnionMemberAst, IGqlpUnionMember>(parsers)
{
  protected internal override UnionMemberAst NamedFactory(string input)
    => new(AstNulls.At, input, "");
  protected internal override string NameString(string input)
    => input;
}
