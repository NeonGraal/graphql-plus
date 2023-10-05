namespace GqlPlus.Verifier.Ast;

internal abstract record class AstNamedDirectives(string Name)
  : AstNamed(Name), AstDirectives, IEquatable<AstNamedDirectives>
{
  DirectiveAst[] AstDirectives.Directives { get; set; } = Array.Empty<DirectiveAst>();
  internal DirectiveAst[] Directives
  {
    get => (this as AstDirectives).Directives;
    set => (this as AstDirectives).Directives = value;
  }

  public virtual bool Equals(AstNamedDirectives? other)
    => base.Equals(other)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine((AstNamed)this, Directives);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(Directives.Select(d => $"{d}"));
}
