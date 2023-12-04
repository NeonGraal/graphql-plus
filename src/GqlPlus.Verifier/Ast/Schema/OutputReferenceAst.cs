using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class OutputReferenceAst(TokenAt At, string Name)
  : AstReference<OutputReferenceAst>(At, Name), IEquatable<OutputReferenceAst>
{
  public string? Label { get; set; }

  internal override string Abbr => "OR";

  public override bool Equals(OutputReferenceAst? other)
    => base.Equals(other)
    && Label.NullEqual(other.Label);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Label);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      At.ToString(),
      Label is not null
        ? $"{Name}.{Label}"
        : IsTypeParameter ? Name.Prefixed("$") : Name
    }.Concat(Arguments.Bracket("<", ">"));
}
