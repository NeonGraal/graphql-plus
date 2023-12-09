using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class EnumValueAst(TokenAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<EnumValueAst>
{
  internal override string Abbr => "EV";
}
