namespace GqlPlus.Verifier.Ast;

internal sealed record class VariableAst : NamedAst
{
  public VariableAst(string name) : base(name) { }

  public string? Type { get; set; }

  public ModifierAst[] Modifers { get; set; } = Array.Empty<ModifierAst>();

  public bool Equals(VariableAst? other)
    => base.Equals(other)
    && Type.NullEqual(other.Type)
    && Modifers.SequenceEqual(other.Modifers);

  public override int GetHashCode()
    => HashCode.Combine((NamedAst)this, Type, Modifers);
}
