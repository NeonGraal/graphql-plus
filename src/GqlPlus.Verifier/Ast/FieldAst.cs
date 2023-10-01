namespace GqlPlus.Verifier.Ast;

internal sealed record class FieldAst(string Name)
  : NamedDirectivesAst(Name), SelectionAst
{
  internal string? Alias { get; init; }

  public ArgumentAst? Argument { get; set; }

  internal SelectionAst[] Selections { get; set; } = Array.Empty<SelectionAst>();

  public bool Equals(FieldAst? other)
    => base.Equals(other)
    && Alias.NullEqual(other.Alias)
    && Argument == other.Argument
    && Selections.SequenceEqual(other.Selections);

  public override int GetHashCode()
    => HashCode.Combine((NamedDirectivesAst)this, Alias, Argument, Selections);
}
