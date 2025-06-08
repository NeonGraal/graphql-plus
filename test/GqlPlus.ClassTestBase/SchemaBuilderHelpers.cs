using GqlPlus.Abstractions.Schema;
using NSubstitute;

namespace GqlPlus;

public static class SchemaBuilderHelpers
{
  public static T Aliased<T>(this IMockBuilder builder, string name, string[] aliases, string description = "")
    where T : class, IGqlpAliased
  {
    T result = builder.Named<T>(name, description);
    result.Aliases.Returns(aliases);
    return result;
  }

  public static T Descr<T>(this IMockBuilder builder, string description)
    where T : class, IGqlpDescribed
  {
    T result = builder.Error<T>();
    result.Description.Returns(description);
    return result;
  }

  public static IGqlpDomain<TItem> Domain<TItem>(this IMockBuilder builder, string name, DomainKind kind, params TItem[] items)
    where TItem : IGqlpDomainItem
  {
    IGqlpDomain<TItem> domain = builder.Named<IGqlpDomain<TItem>>(name);
    domain.DomainKind.Returns(kind);
    domain.Items.Returns(items);
    return domain;
  }

  public static IGqlpDomain<IGqlpDomainLabel> DomainEnum(this IMockBuilder builder, string name, string enumType, string enumLabel)
  {
    IGqlpDomainLabel domainLabel = builder.Error<IGqlpDomainLabel>();
    domainLabel.EnumType.Returns(enumType);
    domainLabel.EnumItem.Returns(enumLabel);
    return builder.Domain(name, DomainKind.Enum, domainLabel);
  }

  public static IGqlpDomainLabel DomainLabel(this IMockBuilder builder, string enumType, string enumLabel)
  {
    IGqlpDomainLabel domainLabel = builder.Error<IGqlpDomainLabel>();
    domainLabel.EnumType.Returns(enumType);
    domainLabel.EnumItem.Returns(enumLabel);
    return domainLabel;
  }

  public static IGqlpEnum Enum(this IMockBuilder builder, string name, string[] labels, string parent = "")
  {
    IGqlpEnum gqlpEnum = builder.Named<IGqlpEnum>(name);
    gqlpEnum.Parent.Returns(parent);
    IGqlpEnumLabel[] enumLabels = builder.ArrayOf((b, i) => b.EnumLabel(i), labels);
    gqlpEnum.Items.Returns(enumLabels);
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

  public static IGqlpInputParam InputParam(this IMockBuilder builder, string type, string description = "", bool isTypeParam = false)
  {
    IGqlpInputBase typeBase = builder.Named<IGqlpInputBase>(type, description);
    typeBase.Input.Returns(type);
    typeBase.IsTypeParam.Returns(isTypeParam);
    IGqlpInputParam input = builder.Descr<IGqlpInputParam>(description);
    input.Type.Returns(typeBase);
    return input;
  }

  public static T Named<T>(this IMockBuilder builder, string name)
    where T : class, IGqlpNamed
  {
    T result = builder.Error<T>();
    result.Name.Returns(name);
    return result;
  }

  public static T Named<T>(this IMockBuilder builder, string name, string description)
    where T : class, IGqlpNamed
  {
    T result = builder.Descr<T>(description);
    result.Name.Returns(name);
    return result;
  }

  public static T[] NamedArray<T>(this IMockBuilder builder, params string[] names)
    where T : class, IGqlpNamed
    => builder.ArrayOf((b, i) => b.Named<T>(i), names);

  public static IGqlpTypeParam TypeParam(this IMockBuilder builder, string paramName, string constraint)
  {
    IGqlpTypeParam typeParam = builder.Named<IGqlpTypeParam>(paramName);
    typeParam.Constraint.Returns(constraint);
    return typeParam;
  }

  public static IGqlpUnion Union(this IMockBuilder builder, string name, string member)
  {
    IGqlpUnion union = builder.Named<IGqlpUnion>(name);
    IGqlpUnionMember unionMember = builder.Named<IGqlpUnionMember>(member);
    union.Items.Returns([unionMember]);
    return union;
  }
}
