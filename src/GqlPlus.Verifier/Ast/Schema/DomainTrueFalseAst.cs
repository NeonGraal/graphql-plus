using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class DomainTrueFalseAst(TokenAt At, bool Excludes, bool Value)
  : AstDomainItem(At, Excludes), IAstDomainItem
{
  internal override string Abbr => "STF";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append($"{Value}");
}
