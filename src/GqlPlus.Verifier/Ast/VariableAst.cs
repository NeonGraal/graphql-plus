namespace GqlPlus.Verifier.Ast;

internal sealed record class VariableAst(ParseAt At, string Name)
  : AstNamedDirectives(At, Name), IEquatable<VariableAst>
{
  public string? Type { get; set; }
  public ModifierAst[] Modifers { get; set; } = Array.Empty<ModifierAst>();
  public ConstantAst? Default { get; set; }

  protected override string Abbr => "V";

  public bool Equals(VariableAst? other)
    => base.Equals(other)
    && Type.NullEqual(other.Type)
    && Modifers.SequenceEqual(other.Modifers)
    && Default.NullEqual(other.Default);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifers, Default);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Type.Prefixed(":"))
      .Concat(Modifers.Select(m => $"{m}"))
      .Append(Default is null ? "" : "=" + Default.ToString());
}
