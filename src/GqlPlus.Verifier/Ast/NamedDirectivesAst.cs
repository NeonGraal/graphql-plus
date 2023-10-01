namespace GqlPlus.Verifier.Ast;

internal record class NamedDirectivesAst(string Name)
  : NamedAst(Name), DirectivesAst, IEquatable<NamedDirectivesAst>
{
  DirectiveAst[] DirectivesAst.Directives { get; set; } = Array.Empty<DirectiveAst>();
  internal DirectiveAst[] Directives
  {
    get => (this as DirectivesAst).Directives;
    set => (this as DirectivesAst).Directives = value;
  }

  public virtual bool Equals(NamedDirectivesAst? other)
    => base.Equals(other)
    && Directives.SequenceEqual(other.Directives);

  public override int GetHashCode()
    => HashCode.Combine((NamedAst)this, Directives);
}
