namespace GqlPlus.Verifier.Ast;

internal sealed record class VariableAst(string Name)
  : NamedDirectivesAst(Name), IEquatable<VariableAst>
{
  internal string? Type { get; set; }

  internal ModifierAst[] Modifers { get; set; } = Array.Empty<ModifierAst>();

  public bool Equals(VariableAst? other)
    => base.Equals(other)
    && Type.NullEqual(other.Type)
    && Modifers.SequenceEqual(other.Modifers);

  public override int GetHashCode()
    => HashCode.Combine((NamedDirectivesAst)this, Type, Modifers);
}
