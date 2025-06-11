using GqlPlus.Abstractions.Schema;

namespace GqlPlus;

public static class SchemaSimpleBuilderHelpers
{
  public static IGqlpDomain<TItem> Domain<TItem>(this IMockBuilder builder, string name, DomainKind kind, params TItem[] items)
    where TItem : IGqlpDomainItem
    => builder.Domain(name, [], "", "", kind, items);

  public static IGqlpDomain<TItem> Domain<TItem>(this IMockBuilder builder, string name, string[] aliases, string parent, string description, DomainKind kind, params TItem[] items)
    where TItem : IGqlpDomainItem
  {
    IGqlpDomain<TItem> domain = builder.Simple<IGqlpDomain<TItem>>(name, aliases, parent, description);
    domain.DomainKind.Returns(kind);
    domain.Items.Returns(items);
    return domain;
  }

  public static IGqlpDomain<IGqlpDomainLabel> DomainEnum(this IMockBuilder builder, string name, string parent, string enumType, string enumLabel)
    => builder.DomainEnum(name, parent, builder.DomainLabel(enumType, enumLabel));
  public static IGqlpDomain<IGqlpDomainLabel> DomainEnum(this IMockBuilder builder, string name, string parent, params IGqlpDomainLabel[] labels)
    => builder.Domain(name, [], parent, "", DomainKind.Enum, labels);

  public static IGqlpDomainLabel DomainLabel(this IMockBuilder builder, string enumType, string enumLabel)
  {
    IGqlpDomainLabel domainLabel = builder.Error<IGqlpDomainLabel>();
    domainLabel.EnumType.Returns(enumType);
    domainLabel.EnumItem.Returns(enumLabel);
    return domainLabel;
  }

  public static IGqlpEnum Enum(this IMockBuilder builder, string name, string parent, string[] labels)
    => builder.Enum(name, parent, builder.ArrayOf((b, i) => b.EnumLabel(i), labels));
  public static IGqlpEnum Enum(this IMockBuilder builder, string name, string parent, params IGqlpEnumLabel[] enumLabels)
    => builder.Enum(name, [], parent, "", enumLabels);
  public static IGqlpEnum Enum(this IMockBuilder builder, string name, string[] aliases, string parent, string description, params IGqlpEnumLabel[] enumLabels)
  {
    IGqlpEnum gqlpEnum = builder.Simple<IGqlpEnum>(name, aliases, parent, description);
    gqlpEnum.Items.Returns(enumLabels);
    HashSet<string> labels = [.. enumLabels.Select(l => l.Name)];
    gqlpEnum.HasValue(Arg.Is<string>(v => labels.Contains(v))).Returns(true);
    return gqlpEnum;
  }

  public static IGqlpEnumLabel EnumLabel(this IMockBuilder builder, string label)
  {
    IGqlpEnumLabel enumLabel = builder.Error<IGqlpEnumLabel>();
    enumLabel.Name.Returns(label);
    enumLabel.IsNameOrAlias(label).Returns(true);
    return enumLabel;
  }

  public static TSimple Simple<TSimple>(this IMockBuilder builder, string name, string[] aliases, string parent = "", string description = "")
    where TSimple : class, IGqlpSimple
  {
    TSimple simple = builder.Aliased<TSimple>(name, aliases, description);
    simple.Parent.Returns(parent);
    return simple;
  }

  public static IGqlpUnion Union(this IMockBuilder builder, string name, params string[] members)
    => builder.Union(name, [], "", "", builder.NamedArray<IGqlpUnionMember>(members));
  public static IGqlpUnion Union(this IMockBuilder builder, string name, string[] aliases, string parent, string description, params IGqlpUnionMember[] unionMembers)
  {
    IGqlpUnion union = builder.Simple<IGqlpUnion>(name, aliases, parent, description);
    union.Items.Returns(unionMembers);
    return union;
  }
}
