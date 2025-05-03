using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class DomainLabelAst(
  ITokenAt At,
  string Description,
  bool Excludes,
  string EnumItem
) : AstDomainItem(At, Description, Excludes)
  , IEquatable<DomainLabelAst>
  , IGqlpDomainLabel
{
  public string EnumType { get; set; } = "";

  internal override string Abbr => "DE";

  public bool Equals(DomainLabelAst? other)
    => base.Equals(other)
      && EnumItem.NullEqual(other.EnumItem)
      && EnumType.NullEqual(other.EnumType);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), EnumItem, EnumType);
  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Excludes ? "!" : "")
      .Append(EnumType)
      .Append(EnumItem);

  void IGqlpDomainLabel.SetEnumType(string enumType)
    => EnumType ??= enumType;
}
