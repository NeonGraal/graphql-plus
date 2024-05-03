using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

public sealed record class DomainTrueFalseAst(TokenAt At, bool Excludes, bool Value)
  : AstDomainItem(At, Excludes), IAstDomainItem
{
  internal override string Abbr => "DT";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append($"{Value}");
}
