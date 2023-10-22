namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class InputReferenceAst(ParseAt At, string Name)
  : AstNamed(At, Name), IEquatable<InputReferenceAst>
{
  public bool IsTypeParameter { get; set; }
  public InputReferenceAst[] Arguments { get; set; } = Array.Empty<InputReferenceAst>();

  internal override string Abbr => "IR";

  public bool Equals(InputReferenceAst? other)
    => base.Equals(other)
    && IsTypeParameter == other.IsTypeParameter
    && Arguments.SequenceEqual(other.Arguments);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), IsTypeParameter, Arguments.Length);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      AbbrAt,
      IsTypeParameter ? Name.Prefixed("$") : Name
    }.Concat(Arguments.Bracket("<", ">"));
}
