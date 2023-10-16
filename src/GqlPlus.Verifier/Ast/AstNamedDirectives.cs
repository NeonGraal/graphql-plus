namespace GqlPlus.Verifier.Ast;

internal abstract record class AstNamedDirectives(ParseAt At, string Name)
  : AstNamed(At, Name), AstDirectives, IEquatable<AstNamedDirectives>
{
  public DirectiveAst[] Directives { get; set; } = Array.Empty<DirectiveAst>();

  public virtual bool Equals(AstNamedDirectives? other)
    => base.Equals(other)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Directives);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(Directives.AsString());
}
