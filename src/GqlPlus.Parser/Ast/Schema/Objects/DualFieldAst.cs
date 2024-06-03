using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class DualFieldAst(
  TokenAt At,
  string Name,
  string Description,
  IGqlpDualBase Type
) : AstObjectField<IGqlpDualBase>(At, Name, Description, Type)
  , IEquatable<DualFieldAst>
  , IGqlpDualField
{
  public DualFieldAst(TokenAt at, string name, IGqlpDualBase typeBase)
    : this(at, name, "", typeBase) { }

  internal override string Abbr => "DF";

  IGqlpDualBase IGqlpObjectField<IGqlpDualBase>.Type => Type;

  public bool Equals(DualFieldAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(":")
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString());
}
