namespace GqlPlus.Models;

public enum DomainKindModel { Boolean, Enum, Number, String, Union }

internal record class DomainRefModel(
  string Name,
  DomainKind DomainKind,
  string Description
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Domain, Name, Description)
{ }

public sealed record class BaseDomainModel<TItem>(
  DomainKindModel DomainKind,
  string Name,
  string Description
) : ParentTypeModel<TItem, DomainItemModel<TItem>>(TypeKindModel.Domain, Name, Description)
  where TItem : BaseDomainItemModel
{
  internal override string Tag => $"_Domain{DomainKind}";
}

public record class BaseDomainItemModel(
  bool Exclude
) : ModelBase
{ }

public record class DomainLabelModel(
  EnumValueModel EnumValue,
  bool Exclude
) : BaseDomainItemModel(Exclude)
{
  public DomainLabelModel(string name, string label, bool exclude)
    : this(new(name, label, ""), exclude)
  { }
}

public record class DomainTrueFalseModel(
  bool Value,
  bool Exclude
) : BaseDomainItemModel(Exclude)
{ }

public record class DomainRangeModel(
  decimal? From,
  decimal? To,
  bool Exclude
) : BaseDomainItemModel(Exclude)
{ }

public record class DomainRegexModel(
  string Pattern,
  bool Exclude
) : BaseDomainItemModel(Exclude)
{ }

public record class DomainItemModel<TItem>(
  TItem Item,
  string Domain
) : ModelBase
  where TItem : BaseDomainItemModel
{ }

public record class TypeEnumModel(
  string Name,
  string Description
) : ParentTypeModel<AliasedModel, EnumLabelModel>(TypeKindModel.Enum, Name, Description)
{ }

public record class EnumLabelModel(
  string Name,
  string OfEnum,
  string Description
) : AliasedModel(Name, Description)
{ }

public record class EnumValueModel(
  string Name,
  string Label,
  string Description
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name, Description)
{ }

public record class TypeUnionModel(
  string Name,
  string Description
) : ParentTypeModel<AliasedModel, UnionMemberModel>(TypeKindModel.Union, Name, Description)
{ }

public record class UnionMemberModel(
  string Name,
  string OfUnion,
  string Description
) : AliasedModel(Name, Description)
{ }
