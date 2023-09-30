namespace GqlPlus.Verifier.Ast;

internal sealed record class FieldAst : NamedAst, SelectionAst
{
  public FieldAst(string name) : base(name) { }

  internal string? Alias { get; init; }

  public ArgumentAst? Argument { get; set; }

  internal SelectionAst[] Selections { get; set; } = Array.Empty<SelectionAst>();

  public bool Equals(FieldAst? other)
    => base.Equals(other)
    && Alias.NullEqual(other.Alias)
    && Argument == other.Argument
    && Selections.SequenceEqual(other.Selections);

  public override int GetHashCode()
    => HashCode.Combine((NamedAst)this, Alias, Argument, Selections);
}
