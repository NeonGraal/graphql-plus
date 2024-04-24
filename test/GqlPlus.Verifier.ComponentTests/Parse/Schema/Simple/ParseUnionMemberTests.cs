using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

public sealed class ParseUnionMemberTests(
  Parser<UnionMemberAst>.D parser
) : BaseNamedTests<string>
{
  internal override IBaseNamedChecks<string> NameChecks => _checks;

  private readonly ParseUnionMemberChecks _checks = new(parser);
}

internal sealed class ParseUnionMemberChecks(
  Parser<UnionMemberAst>.D parser
) : BaseNamedChecks<string, UnionMemberAst>(parser)
{
  protected internal override UnionMemberAst NamedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string NameString(string input)
    => input;
}
