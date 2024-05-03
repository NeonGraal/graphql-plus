using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

public abstract record class AstDirectives(TokenAt At, string Name)
  : AstNamed(At, Name), IAstDirectives, IEquatable<AstDirectives>
{
  public DirectiveAst[] Directives { get; set; } = Array.Empty<DirectiveAst>();

  public virtual bool Equals(AstDirectives? other)
    => base.Equals(other)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Directives.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(Directives.AsString());
}
