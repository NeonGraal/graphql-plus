using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarTrueFalseAst(TokenAt At, bool Excludes, bool Value)
  : AstScalarItem(At, Excludes), IAstScalarItem
{
  internal override string Abbr => "STF";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append($"{Value}");
}
