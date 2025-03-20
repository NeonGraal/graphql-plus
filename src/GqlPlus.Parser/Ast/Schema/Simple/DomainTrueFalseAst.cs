using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class DomainTrueFalseAst(
  TokenAt At,
  string Description,
  bool Excludes,
  bool Value
) : AstDomainItem(At, Description, Excludes)
  , IGqlpDomainTrueFalse
{
  internal override string Abbr => "DT";

  bool IGqlpDomainTrueFalse.IsTrue => Value;

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append($"{Value}");
}
