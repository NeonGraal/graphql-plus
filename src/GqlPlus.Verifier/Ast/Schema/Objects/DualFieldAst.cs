using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public sealed record class DualFieldAst(
  TokenAt At,
  string Name,
  string Description,
  DualReferenceAst Type
) : AstObjectField<DualReferenceAst>(At, Name, Description, Type), IEquatable<DualFieldAst>
{
  public DualFieldAst(TokenAt at, string name, DualReferenceAst fieldType)
    : this(at, name, "", fieldType) { }

  internal override string Abbr => "DF";

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
