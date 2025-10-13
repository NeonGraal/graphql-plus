using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

internal abstract record class AstDirectives(
  ITokenAt At,
  string Identifier
) : AstIdentified(At, Identifier)
  , IGqlpDirectives
{
  public IGqlpDirective[] Directives { get; set; } = [];
  IEnumerable<IGqlpDirective> IGqlpDirectives.Directives => Directives;

  public virtual bool Equals(AstDirectives? other)
    => other is IGqlpDirectives directives && Equals(directives);
  public bool Equals(IGqlpDirectives? other)
    => Equals(other as IGqlpIdentified)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Directives.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(Directives.AsString());
}
