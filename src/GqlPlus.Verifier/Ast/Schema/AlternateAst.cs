using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public record class AlternateAst<R>(TokenAt At, R Type)
  : AstBase(At), IEquatable<AlternateAst<R>>, IAstDescribed, IAstModified
  where R : AstReference<R>, IEquatable<R>
{
  public ModifierAst[] Modifiers { get; set; } = [];

  internal override string Abbr => "A";

  public string Description => Type.Description;

  internal AlternateAst(R @type)
    : this(type.At, type) { }

  public virtual bool Equals(AlternateAst<R>? other)
    => base.Equals(other)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => new[] { "!" + Abbr + Type.Abbr[..1] }
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString());
}
