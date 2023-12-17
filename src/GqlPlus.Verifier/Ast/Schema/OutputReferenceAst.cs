using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class OutputReferenceAst(TokenAt At, string Name, string Description)
  : AstReference<OutputReferenceAst>(At, Name, Description), IEquatable<OutputReferenceAst>
{
  public OutputReferenceAst(TokenAt at, string name)
    : this(at, name, "") { }

  public string? EnumValue { get; set; }

  internal override string Abbr => "OR";
  public override string Label => "Output";

  public override bool Equals(OutputReferenceAst? other)
    => base.Equals(other)
    && EnumValue.NullEqual(other.EnumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), EnumValue);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      At.ToString(),
      EnumValue is not null
        ? $"{Name}.{EnumValue}"
        : IsTypeParameter ? Name.Prefixed("$") : Name
    }.Concat(Arguments.Bracket("<", ">"));
}
