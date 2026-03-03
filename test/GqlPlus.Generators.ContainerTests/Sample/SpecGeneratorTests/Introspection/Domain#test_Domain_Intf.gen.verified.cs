//HintName: test_Domain_Intf.gen.cs
// Generated from {CurrentDirectory}Domain.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

public interface Itest_DomainRef<TDomain>
  : Itest_TypeRef<Itest_TypeKind>
{
  Itest_DomainRefObject<TDomain>? As__DomainRef { get; }
}

public interface Itest_DomainRefObject<TDomain>
  : Itest_TypeRefObject<Itest_TypeKind>
{
  TDomain DomainKind { get; }
}

public interface Itest_BaseDomain<TDomain,TItem,TDomainItem>
  : Itest_ParentType<Itest_TypeKind, TItem, TDomainItem>
{
  Itest_BaseDomainObject<TDomain,TItem,TDomainItem>? As__BaseDomain { get; }
}

public interface Itest_BaseDomainObject<TDomain,TItem,TDomainItem>
  : Itest_ParentTypeObject<Itest_TypeKind, TItem, TDomainItem>
{
  TDomain DomainKind { get; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  Itest_BaseDomainItemObject? As__BaseDomainItem { get; }
}

public interface Itest_BaseDomainItemObject
  : Itest_DescribedObject
{
  bool Exclude { get; }
}

public interface Itest_DomainItem<TItem>
  : IGqlpModelImplementationBase
{
  TItem? As_Parent { get; }
  Itest_DomainItemObject<TItem>? As__DomainItem { get; }
}

public interface Itest_DomainItemObject<TItem>
  : IGqlpModelImplementationBase
{
  Itest_Name Domain { get; }
}

public interface Itest_DomainValue<TDomain,TValue>
  : Itest_DomainRef<TDomain>
{
  TValue? Asvalue { get; }
  Itest_DomainValueObject<TDomain,TValue>? As__DomainValue { get; }
}

public interface Itest_DomainValueObject<TDomain,TValue>
  : Itest_DomainRefObject<TDomain>
{
  TValue Value { get; }
}

public interface Itest_BasicValue
  : IGqlpModelImplementationBase
{
  bool? AsBoolean { get; }
  Itest_EnumValue? As_EnumValue { get; }
  decimal? AsNumber { get; }
  string? AsString { get; }
  Itest_BasicValueObject? As__BasicValue { get; }
}

public interface Itest_BasicValueObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  Itest_DomainTrueFalseObject? As__DomainTrueFalse { get; }
}

public interface Itest_DomainTrueFalseObject
  : Itest_BaseDomainItemObject
{
  bool Value { get; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem<Itest_DomainTrueFalse>
{
  Itest_DomainItemTrueFalseObject? As__DomainItemTrueFalse { get; }
}

public interface Itest_DomainItemTrueFalseObject
  : Itest_DomainItemObject<Itest_DomainTrueFalse>
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  Itest_DomainLabelObject? As__DomainLabel { get; }
}

public interface Itest_DomainLabelObject
  : Itest_BaseDomainItemObject
{
  Itest_EnumValue Label { get; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem<Itest_DomainLabel>
{
  Itest_DomainItemLabelObject? As__DomainItemLabel { get; }
}

public interface Itest_DomainItemLabelObject
  : Itest_DomainItemObject<Itest_DomainLabel>
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  Itest_DomainRangeObject? As__DomainRange { get; }
}

public interface Itest_DomainRangeObject
  : Itest_BaseDomainItemObject
{
  decimal? Lower { get; }
  decimal? Upper { get; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem<Itest_DomainRange>
{
  Itest_DomainItemRangeObject? As__DomainItemRange { get; }
}

public interface Itest_DomainItemRangeObject
  : Itest_DomainItemObject<Itest_DomainRange>
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  Itest_DomainRegexObject? As__DomainRegex { get; }
}

public interface Itest_DomainRegexObject
  : Itest_BaseDomainItemObject
{
  string Pattern { get; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem<Itest_DomainRegex>
{
  Itest_DomainItemRegexObject? As__DomainItemRegex { get; }
}

public interface Itest_DomainItemRegexObject
  : Itest_DomainItemObject<Itest_DomainRegex>
{
}
