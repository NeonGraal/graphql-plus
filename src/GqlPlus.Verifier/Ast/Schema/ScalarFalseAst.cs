using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarFalseAst(TokenAt At, bool Value)
  : AstAbbreviated(At), IAstScalarItem
{
  internal override string Abbr => "SF";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append($"{Value}");
}
