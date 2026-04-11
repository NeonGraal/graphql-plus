namespace GqlPlus.Ast.Operation;

internal abstract record class AstDirectives(
  ITokenAt At,
  string Identifier
) : AstIdentified(At, Identifier)
  , IAstDirectives
{
  public IAstDirective[] Directives { get; set; } = [];
  IEnumerable<IAstDirective> IAstDirectives.Directives => Directives;

  public virtual bool Equals(AstDirectives? other)
    => other is IAstDirectives directives && Equals(directives);
  public bool Equals(IAstDirectives? other)
    => Equals(other as IAstIdentified)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Directives.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(Directives.AsString());
}
