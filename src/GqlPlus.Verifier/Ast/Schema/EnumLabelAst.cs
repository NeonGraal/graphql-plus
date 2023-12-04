using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class EnumLabelAst(TokenAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<EnumLabelAst>
{
  internal override string Abbr => "EL";
}
