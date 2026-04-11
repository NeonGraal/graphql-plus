//HintName: test_-Simple_Intf.gen.cs
// Generated from {CurrentDirectory}-Simple.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public enum test_DomainKind
{
  Boolean,
  Enum,
  Number,
  String,
}

public interface Itest_DomainRef<TDomainKind>
  : Itest_TypeRef<Itest_TypeKind>
{
  Itest_DomainRefObject<TDomainKind>? As__DomainRef { get; }
}

public interface Itest_DomainRefObject<TDomainKind>
  : Itest_TypeRefObject<Itest_TypeKind>
{
  TDomainKind DomainKind { get; }
}

public interface Itest_BaseDomain<TDomainKind,TItem,TDomainItem>
  : Itest_ParentType<Itest_TypeKind, TItem, TDomainItem>
{
  Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem>? As__BaseDomain { get; }
}

public interface Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem>
  : Itest_ParentTypeObject<Itest_TypeKind, TItem, TDomainItem>
{
  TDomainKind DomainKind { get; }
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
  : IGqlpInterfaceBase
{
  TItem? As_Parent { get; }
  Itest_DomainItemObject<TItem>? As__DomainItem { get; }
}

public interface Itest_DomainItemObject<TItem>
  : IGqlpInterfaceBase
{
  Itest_Name Domain { get; }
}

public interface Itest_DomainValue<TDomainKind,TValue>
  : Itest_DomainRef<TDomainKind>
{
  TValue? Asvalue { get; }
  Itest_DomainValueObject<TDomainKind,TValue>? As__DomainValue { get; }
}

public interface Itest_DomainValueObject<TDomainKind,TValue>
  : Itest_DomainRefObject<TDomainKind>
{
  TValue Value { get; }
}

public interface Itest_BasicValue
  : IGqlpInterfaceBase
{
  bool? AsBoolean { get; }
  Itest_EnumValue? As_EnumValue { get; }
  decimal? AsNumber { get; }
  string? AsString { get; }
  Itest_BasicValueObject? As__BasicValue { get; }
}

public interface Itest_BasicValueObject
  : IGqlpInterfaceBase
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

public interface Itest_EnumLabel
  : Itest_Aliased
{
  Itest_EnumLabelObject? As__EnumLabel { get; }
}

public interface Itest_EnumLabelObject
  : Itest_AliasedObject
{
  Itest_Name EnumType { get; }
}

public interface Itest_EnumValue
  : Itest_TypeRef<Itest_TypeKind>
{
  Itest_EnumValueObject? As__EnumValue { get; }
}

public interface Itest_EnumValueObject
  : Itest_TypeRefObject<Itest_TypeKind>
{
  Itest_Name Label { get; }
}

public interface Itest_UnionRef
  : Itest_TypeRef<Itest_SimpleKind>
{
  Itest_UnionRefObject? As__UnionRef { get; }
}

public interface Itest_UnionRefObject
  : Itest_TypeRefObject<Itest_SimpleKind>
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  Itest_UnionMemberObject? As__UnionMember { get; }
}

public interface Itest_UnionMemberObject
  : Itest_UnionRefObject
{
  Itest_Name Union { get; }
}
