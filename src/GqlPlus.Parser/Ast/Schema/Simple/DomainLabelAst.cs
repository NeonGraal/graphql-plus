using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class DomainLabelAst(
  ITokenAt At,
  string Description,
  bool Excludes,
  string EnumItem
) : AstDomainItem(At, Description, Excludes)
  , IAstDomainLabel
{
  public string EnumType { get; set; } = "";

  internal override string Abbr => "DE";

  public bool Equals(DomainLabelAst? other)
    => other is IAstDomainLabel label && Equals(label);
  public bool Equals(IAstDomainLabel? other)
    => base.Equals(other)
      && EnumItem.NullEqual(other.EnumItem)
      && EnumType.NullEqual(other.EnumType);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), EnumItem, EnumType);
  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(EnumType)
      .Append((Excludes ? "!" : "") + EnumItem);

  void IAstDomainLabel.SetEnumType(string enumType)
  {
    if (string.IsNullOrWhiteSpace(EnumType)) {
      EnumType = enumType;
    }
  }
}
