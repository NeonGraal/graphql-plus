using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjAlternate(
  ITokenAt At,
  string Name,
  string Description
) : AstObjBase(At, Name, Description)
  , IGqlpObjAlternate
{
  public IGqlpModifier[] Modifiers { get; set; } = [];

  public string ModifiedType => GetFields().Skip(2).Joined();

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  public virtual bool Equals(AstObjAlternate? other)
    => other is IGqlpObjAlternate alternate && Equals(alternate);
  public bool Equals(IGqlpObjAlternate? other)
    => base.Equals(other)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Modifiers.AsString());
}
