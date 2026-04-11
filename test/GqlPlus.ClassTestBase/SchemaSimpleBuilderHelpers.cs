using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus;

public static class SchemaSimpleBuilderHelpers
{
  public static IAstDomain<TItem> Domain<TItem>(this IMockBuilder _, string name, DomainKind kind, params TItem[] items)
    where TItem : IAstDomainItem
    => _.Domain<TItem>(name, kind).WithItems(items).AsDomain;

  public static IAstDomain<IAstDomainTrueFalse> DomainBoolean(this IMockBuilder _, string name)
    => _.Domain<IAstDomainTrueFalse>(name, DomainKind.Boolean).AsDomain;

  public static IAstDomain<IAstDomainLabel> DomainEnum(this IMockBuilder _, string name, string enumType, string enumLabel)
    => _.DomainEnum(name).WithItems(_.ItemLabel(enumType, enumLabel)).AsDomain;

  public static IAstDomain<IAstDomainRange> DomainNumber(this IMockBuilder _, string name)
    => _.Domain<IAstDomainRange>(name, DomainKind.Number).AsDomain;

  public static IAstDomain<IAstDomainRegex> DomainString(this IMockBuilder _, string name)
    => _.Domain<IAstDomainRegex>(name, DomainKind.String).AsDomain;

  public static IAstDomainLabel ItemLabel(this IMockBuilder _, string enumType, string enumLabel, bool excludes = false)
    => new DomainLabelBuilder(enumType, enumLabel)
      .WithExcludes(excludes)
      .AsLabel;

  public static IAstDomainRange ItemRange(this IMockBuilder _, decimal value, bool excludes = false)
    => new DomainRangeBuilder(value)
      .WithExcludes(excludes)
      .AsRange;

  public static IAstDomainRegex ItemRegex(this IMockBuilder _, string pattern, bool excludes = false)
    => new DomainRegexBuilder(pattern)
      .WithExcludes(excludes)
      .AsRegex;

  public static IAstDomainTrueFalse ItemTrueFalse(this IMockBuilder _, bool value, bool excludes = false)
    => new DomainTrueFalseBuilder(value)
      .WithExcludes(excludes)
      .AsTrueFalse;

  public static IAstEnum Enum(this IMockBuilder _, string name, string[] labels)
    => _.Enum(name).WithLabels(labels).AsEnum;

  public static DomainBuilder<TItem> Domain<TItem>(this IMockBuilder _, string name, DomainKind kind)
    where TItem : IAstDomainItem
    => new(name, kind);
  public static DomainBuilder<IAstDomainLabel> DomainEnum(this IMockBuilder _, string name)
    => new(name, DomainKind.Enum);

  public static EnumBuilder Enum(this IMockBuilder _, string name)
    => new(name);

  public static UnionBuilder Union(this IMockBuilder _, string name)
    => new(name);
}
