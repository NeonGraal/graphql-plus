using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public sealed record class InputBaseAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjectBase<InputBaseAst>(At, Name, Description)
  , IEquatable<InputBaseAst>
{
  public InputBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "IR";
  public override string Label => "Input";

  public override bool Equals(InputBaseAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();

  internal DualBaseAst ToDual()
    => new(At, Name, Description) {
      IsTypeParameter = IsTypeParameter,
      Arguments = [.. Arguments.Select(a => a.ToDual())],
    };
}
