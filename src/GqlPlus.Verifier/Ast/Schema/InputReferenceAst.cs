using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class InputReferenceAst(TokenAt At, string Name, string Description)
  : AstReference<InputReferenceAst>(At, Name, Description), IEquatable<InputReferenceAst>
{
  public InputReferenceAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "IR";
  public override string Label => "Input";

  public override bool Equals(InputReferenceAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();

  internal DualReferenceAst ToDual()
    => new(At, Name, Description) {
      IsTypeParameter = IsTypeParameter,
      Arguments = [.. Arguments.Select(a => a.ToDual())],
    };
}
