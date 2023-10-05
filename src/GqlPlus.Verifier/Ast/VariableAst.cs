namespace GqlPlus.Verifier.Ast;

internal sealed record class VariableAst(string Name)
  : AstNamedDirectives(Name), IEquatable<VariableAst>
{
  protected override string Abbr => "V";

  public string? Type { get; set; }

  public ModifierAst[] Modifers { get; set; } = Array.Empty<ModifierAst>();

  public ConstantAst? Default { get; set; }

  public bool Equals(VariableAst? other)
    => base.Equals(other)
    && Type.NullEqual(other.Type)
    && Modifers.SequenceEqual(other.Modifers)
    && Default.NullEqual(other.Default);
  public override int GetHashCode()
    => HashCode.Combine((AstNamedDirectives)this, Type, Modifers, Default);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Type.Prefixed(":"))
      .Concat(Modifers.Select(m => $"{m}"))
      .Append(Default is null ? "" : "=" + Default.ToString());
}
