using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class EnumValueAst(TokenAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<EnumValueAst>
{
  public EnumValueAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "EV";

}
