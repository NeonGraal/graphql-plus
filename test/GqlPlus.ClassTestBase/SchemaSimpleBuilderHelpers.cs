using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;

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

  public static IGqlpEnum Enum(this IMockBuilder builder, string name, string[] labels)
    => builder.Enum(name, builder.ArrayOf((b, i) => b.EnumLabel(i, []), labels));
  public static IGqlpEnum Enum(this IMockBuilder builder, string name, params IGqlpEnumLabel[] enumLabels)
    => builder.Enum(name, [], "", enumLabels);
  public static IGqlpEnum Enum(this IMockBuilder builder, string name, string[] aliases, string description, params IGqlpEnumLabel[] enumLabels)
  {
    IGqlpEnum gqlpEnum = builder.Simple<IGqlpEnum>(name, aliases, description);
    gqlpEnum.Items.Returns(enumLabels);
    HashSet<string> labels = [.. enumLabels.Select(l => l.Name)];
    gqlpEnum.HasValue(Arg.Is<string>(v => labels.Contains(v))).Returns(true);
    return gqlpEnum;
  }

  public static IGqlpEnumLabel EnumLabel(this IMockBuilder builder, string label, params string[] aliases)
  {
    IGqlpEnumLabel enumLabel = builder.Aliased<IGqlpEnumLabel>(label, aliases);
    enumLabel.IsNameOrAlias("").ReturnsForAnyArgs(c => label == c.Arg<string>() || aliases.Contains(c.Arg<string>()));
    return enumLabel;
  }

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

  public static IGqlpUnion Union(this IMockBuilder builder, string name, params string[] members)
    => builder.SetUnionMembers(builder.Simple<IGqlpUnion>(name), members);
  public static IGqlpUnion Union(this IMockBuilder builder, string name, string[] aliases, string description, params IGqlpUnionMember[] unionMembers)
  {
    IGqlpUnion union = builder.Simple<IGqlpUnion>(name, aliases, description);
    union.Items.Returns(unionMembers);
    return union;
  }
  public static IGqlpUnion SetUnionMembers(this IMockBuilder builder, [NotNull] IGqlpUnion union, params string[] memberNames)
  {
    IGqlpUnionMember[] members = builder.NamedArray<IGqlpUnionMember>(memberNames);
    union.Items.Returns(members);
    return union;
  }
}
