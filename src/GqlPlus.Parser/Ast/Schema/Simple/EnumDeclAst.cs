using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class EnumDeclAst(
  ITokenAt At,
  string Name,
  string Description,
  IGqlpEnumLabel[] Labels
) : AstSimple<IGqlpEnumLabel>(At, Name, Description, Labels)
  , IGqlpEnum
{
  internal override string Abbr => "En";
  public override string Label => "Enum";

  public EnumDeclAst(TokenAt at, string name, EnumLabelAst[] labels)
    : this(at, name, "", labels) { }

  public bool HasValue(string value)
    => Items.Any(v => v.Name == value || v.Aliases.Contains(value));

  public bool Equals(EnumDeclAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
