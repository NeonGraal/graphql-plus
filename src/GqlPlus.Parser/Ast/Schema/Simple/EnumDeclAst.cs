using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class EnumDeclAst(
  TokenAt At,
  string Name,
  string Description,
  EnumLabelAst[] Labels
) : AstSimple<EnumLabelAst>(At, Name, Description, Labels)
  , IGqlpEnum
{
  internal override string Abbr => "En";
  public override string Label => "Enum";

  IEnumerable<IGqlpEnumLabel> IGqlpSimple<IGqlpEnumLabel>.Items => Labels;

  public EnumDeclAst(TokenAt at, string name, EnumLabelAst[] labels)
    : this(at, name, "", labels) { }

  public bool HasValue(string value)
    => Items.Any(v => v.IsNameOrAlias(value));

  public bool Equals(EnumDeclAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
