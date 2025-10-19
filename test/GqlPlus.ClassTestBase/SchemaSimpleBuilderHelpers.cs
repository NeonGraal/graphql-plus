using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Building.Schema;
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus;

public static class SchemaSimpleBuilderHelpers
{
  public static IGqlpDomain<TItem> Domain<TItem>(this IMockBuilder builder, string name, DomainKind kind, params TItem[] items)
    where TItem : IGqlpDomainItem
    => builder.Domain(name, [], "", kind, items);

  public static IGqlpDomain<TItem> Domain<TItem>(this IMockBuilder builder, string name, string[] aliases, string description, DomainKind kind, params TItem[] items)
    where TItem : IGqlpDomainItem
  {
    IGqlpDomain<TItem> domain = builder.Simple<IGqlpDomain<TItem>>(name, aliases, description);
    domain.DomainKind.Returns(kind);
    domain.Items.Returns(items);
    return domain;
  }

  public static IGqlpDomain<IGqlpDomainLabel> DomainEnum(this IMockBuilder builder, string name, string enumType, string enumLabel)
    => builder.DomainEnum(name, builder.DomainLabel(enumType, enumLabel));
  public static IGqlpDomain<IGqlpDomainLabel> DomainEnum(this IMockBuilder builder, string name, params IGqlpDomainLabel[] labels)
    => builder.Domain(name, [], "", DomainKind.Enum, labels);

  public static IGqlpDomainLabel DomainLabel(this IMockBuilder builder, string enumType, string enumLabel)
  {
    IGqlpDomainLabel domainLabel = builder.Error<IGqlpDomainLabel>();
    domainLabel.EnumType.Returns(enumType);
    domainLabel.EnumItem.Returns(enumLabel);
    return domainLabel;
  }

  public static IGqlpDomainTrueFalse DomainTrueFalse(this IMockBuilder builder, bool value, bool excludes = false)
  {
    IGqlpDomainTrueFalse domainTrueFalse = builder.Error<IGqlpDomainTrueFalse>();
    domainTrueFalse.IsTrue.Returns(value);
    domainTrueFalse.Excludes.Returns(excludes);
    return domainTrueFalse;
  }

  public static EnumBuilder Enum(this IMockBuilder _, string name) => new(name);
  public static IGqlpEnum Enum(this IMockBuilder _, string name, string[] labels)
    => _.Enum(name).WithLabels(labels).AsEnum;
  public static IGqlpEnum Enum(this IMockBuilder _, string name, params IGqlpEnumLabel[] enumLabels)
    => _.Enum(name).WithLabels(enumLabels).AsEnum;
  public static IGqlpEnum Enum(this IMockBuilder _, string name, string[] aliases, string description, params IGqlpEnumLabel[] enumLabels)
    => _.Enum(name)
    .WithAliases(aliases)
    .WithDescr(description)
    .WithLabels(enumLabels)
    .AsEnum;

  public static IGqlpEnumLabel EnumLabel(this IMockBuilder _, string label, params string[] aliases)
    => _.Aliased<IGqlpEnumLabel>(label, aliases);

  public static TSimple Simple<TSimple>(this IMockBuilder builder, string name)
    where TSimple : class, IGqlpSimple
    => builder.Simple<TSimple>(name, []);
  public static TSimple Simple<TSimple>(this IMockBuilder builder, string name, string[] aliases, string description = "")
    where TSimple : class, IGqlpSimple
  {
    TSimple simple = builder.Aliased<TSimple, IGqlpSimple, IGqlpType>(name, aliases, description);
    simple.Parent.Returns((IGqlpTypeRef?)null);

    return simple;
  }
  public static TSimple SetParent<TSimple>(this IMockBuilder builder, [NotNull] TSimple simple, string parent)
    where TSimple : IGqlpSimple
  {
    if (!string.IsNullOrWhiteSpace(parent)) {
      IGqlpTypeRef parentRef = builder.Named<IGqlpTypeRef>(parent);
      simple.Parent.Returns(parentRef);
    } else {
      simple.Parent.Returns((IGqlpTypeRef?)null);
    }

    return simple;
  }

  public static UnionBuilder Union(this IMockBuilder _, string name) => new(name);
  public static IGqlpUnion Union(this IMockBuilder _, string name, string[] members)
    => _.Union(name).WithMembers(members).AsUnion;
  public static IGqlpUnion Union(this IMockBuilder _, string name, string[] aliases, string description, params IGqlpUnionMember[] unionMembers)
    => _.Union(name)
      .WithAliases(aliases)
      .WithDescr(description)
      .WithMembers(unionMembers)
      .AsUnion;
}
