using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class DomainTrueFalseAst(
  ITokenAt At,
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
      .Append(Excludes ? $"!{Value}" : $"{Value}");
}
