﻿namespace GqlPlus.Models;

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

  protected override Func<TItem, DomainItemModel<TItem>> NewItem(string parent)
    => item => new(item, parent);
}

public record class BaseDomainItemModel(
  bool Exclude
) : ModelBase
{ }

public record class DomainMemberModel(
  EnumValueModel EnumValue,
  bool Exclude
) : BaseDomainItemModel(Exclude)
{
  public DomainMemberModel(string name, string member, bool exclude)
    : this(new(name, member), exclude)
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
) : ParentTypeModel<AliasedModel, EnumMemberModel>(TypeKindModel.Enum, Name)
{
  protected override Func<AliasedModel, EnumMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

public record class EnumMemberModel(
  string Name,
  string OfEnum
) : AliasedModel(Name)
{ }

public record class EnumValueModel(
  string Name,
  string Member
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
{ }

public record class TypeUnionModel(
  string Name
) : ParentTypeModel<AliasedModel, UnionMemberModel>(TypeKindModel.Union, Name)
{
  protected override Func<AliasedModel, UnionMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

public record class UnionMemberModel(
  string Name,
  string OfUnion
) : AliasedModel(Name)
{ }
