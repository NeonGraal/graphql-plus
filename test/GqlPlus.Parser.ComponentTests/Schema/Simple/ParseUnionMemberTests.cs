using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Simple;

public sealed class ParseUnionMemberTests(
  IBaseNamedChecks<string, IGqlpUnionMember> checks
) : BaseNamedTests<string, IGqlpUnionMember>(checks)
{ }

internal sealed class ParseUnionMemberChecks(
  Parser<IGqlpUnionMember>.D parser
) : BaseNamedChecks<string, UnionMemberAst, IGqlpUnionMember>(parser)
{
  protected internal override UnionMemberAst NamedFactory(string input)
    => new(AstNulls.At, input, "");
  protected internal override string NameString(string input)
    => input;
}
