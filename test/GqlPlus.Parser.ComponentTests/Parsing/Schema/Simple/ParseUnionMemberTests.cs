using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public sealed class ParseUnionMemberTests(
  Parser<IGqlpUnionItem>.D parser
) : BaseNamedTests<string>
{
  internal override IBaseNamedChecks<string> NameChecks => _checks;

  private readonly ParseUnionMemberChecks _checks = new(parser);
}

internal sealed class ParseUnionMemberChecks(
  Parser<IGqlpUnionItem>.D parser
) : BaseNamedChecks<string, UnionMemberAst, IGqlpUnionItem>(parser)
{
  protected internal override UnionMemberAst NamedFactory(string input)
    => new(AstNulls.At, input, "");
  protected internal override string NameString(string input)
    => input;
}
