using GqlPlus.Abstractions.Schema;
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus;

public static class SchemaSimpleBuilderHelpers
{
  public static IGqlpDomain<TItem> Domain<TItem>(this IMockBuilder _, string name, DomainKind kind, params TItem[] items)
    where TItem : IGqlpDomainItem
    => _.Domain<TItem>(name, kind).WithItems(items).AsDomain;

  public static IGqlpDomain<IGqlpDomainLabel> DomainEnum(this IMockBuilder _, string name, string enumType, string enumLabel)
    => _.DomainEnum(name).WithItems(_.DomainLabel(enumType, enumLabel)).AsDomain;

  public static IGqlpDomainLabel DomainLabel(this IMockBuilder _, string enumType, string enumLabel)
    => new DomainLabelBuilder(enumType, enumLabel).AsLabel;

  public static IGqlpDomainTrueFalse DomainTrueFalse(this IMockBuilder _, bool value, bool excludes = false)
    => new DomainTrueFalseBuilder(value)
      .WithExcludes(excludes)
      .AsTrueFalse;

  public static IGqlpEnum Enum(this IMockBuilder _, string name, string[] labels)
    => _.Enum(name).WithLabels(labels).AsEnum;

  public static SimpleBuilder<TSimple> Simple<TSimple>(this IMockBuilder _, string name)
    where TSimple : class, IGqlpSimple
    => new(name);

  public static DomainBuilder<TItem> Domain<TItem>(this IMockBuilder _, string name, DomainKind kind)
    where TItem : IGqlpDomainItem
    => new(name, kind);
  public static DomainBuilder<IGqlpDomainLabel> DomainEnum(this IMockBuilder _, string name)
    => new(name, DomainKind.Enum);

  public static EnumBuilder Enum(this IMockBuilder _, string name)
    => new(name);

  public static UnionBuilder Union(this IMockBuilder _, string name)
    => new(name);
}
