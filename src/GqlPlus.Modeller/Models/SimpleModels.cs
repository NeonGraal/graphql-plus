namespace GqlPlus.Models;

public enum DomainKindModel { Boolean, Enum, Number, String, Union }

internal record class DomainRefModel(
  string Name,
  DomainKind DomainKind
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Domain, Name)
{ }

public sealed record class BaseDomainModel<TItem>(
  DomainKindModel DomainKind,
  string Name
) : ParentTypeModel<TItem, DomainItemModel<TItem>>(TypeKindModel.Domain, Name)
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
    : this(new(name, label), exclude)
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
  string Name
) : ParentTypeModel<AliasedModel, EnumLabelModel>(TypeKindModel.Enum, Name)
{ }

public record class EnumLabelModel(
  string Name,
  string OfEnum
) : AliasedModel(Name)
{ }

public record class EnumValueModel(
  string Name,
  string Label
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
{ }

public record class TypeUnionModel(
  string Name
) : ParentTypeModel<AliasedModel, UnionMemberModel>(TypeKindModel.Union, Name)
{ }

public record class UnionMemberModel(
  string Name,
  string OfUnion
) : AliasedModel(Name)
{ }
