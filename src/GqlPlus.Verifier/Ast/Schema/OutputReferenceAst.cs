namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class OutputReferenceAst(ParseAt At, string Name)
  : AstNamed(At, Name), IEquatable<OutputReferenceAst>
{
  public bool IsTypeParameter { get; set; }
  public OutputReferenceAst[] Arguments { get; set; } = Array.Empty<OutputReferenceAst>();
  public string? Label { get; set; }

  internal override string Abbr => "OR";

  public bool Equals(OutputReferenceAst? other)
    => base.Equals(other)
    && IsTypeParameter == other.IsTypeParameter
    && Arguments.SequenceEqual(other.Arguments)
    && Label.NullEqual(other.Label);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), IsTypeParameter, Arguments.Length, Label);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      At.ToString(),
      Label is not null
        ? $"{Name}.{Label}"
        : IsTypeParameter ? Name.Prefixed("$") : Name
    }.Concat(Arguments.Bracket("<", ">"));
}
