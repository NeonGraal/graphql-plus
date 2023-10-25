namespace GqlPlus.Verifier.Ast.Schema;

internal abstract record class AstReference<T>(ParseAt At, string Name)
  : AstNamed(At, Name), IEquatable<T>
  where T : AstReference<T>
{
  public bool IsTypeParameter { get; set; }
  public T[] Arguments { get; set; } = Array.Empty<T>();

  public virtual bool Equals(T? other)
    => base.Equals(other)
    && IsTypeParameter == other.IsTypeParameter
    && Arguments.SequenceEqual(other.Arguments);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), IsTypeParameter, Arguments.Length);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      At.ToString(),
      IsTypeParameter ? Name.Prefixed("$") : Name
    }.Concat(Arguments.Bracket("<", ">"));
}
