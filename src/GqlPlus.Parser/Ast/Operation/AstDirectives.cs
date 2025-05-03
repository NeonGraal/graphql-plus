using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

internal abstract record class AstDirectives(
  ITokenAt At,
  string Identifier
) : AstIdentified(At, Identifier)
  , IEquatable<AstDirectives>
  , IGqlpDirectives
{
  public IGqlpDirective[] Directives { get; set; } = [];
  IEnumerable<IGqlpDirective> IGqlpDirectives.Directives
  {
    get => Directives;
    init => Directives = [.. value.Cast<DirectiveAst>()];
  }

  public virtual bool Equals(AstDirectives? other)
    => base.Equals(other)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Directives.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(Directives.AsString());
}
