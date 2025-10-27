//HintName: test_-Simple_Intf.gen.cs
// Generated from -Simple.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public interface Itest_DomainRef<Tkind>
  : Itest_TypeRef
{
  Tkind domainKind { get; }
}

public interface Itest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Itest_ParentType
{
  Tdomain domainKind { get; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  Boolean exclude { get; }
}

public interface Itest_DomainItem<Titem>
  : Itestitem
{
  _Identifier domain { get; }
}

public interface Itest_DomainValue<Tkind,Tvalue>
  : Itest_DomainRef
{
  Tvalue value { get; }
  Tvalue Asvalue { get; }
}

public interface Itest_BasicValue
{
  _DomainKind As_DomainKind { get; }
  _EnumValue As_EnumValue { get; }
  _DomainKind As_DomainKind { get; }
  _DomainKind As_DomainKind { get; }
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  Boolean value { get; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  _EnumValue label { get; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  Number lower { get; }
  Number upper { get; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  String pattern { get; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem
{
}

public interface Itest_EnumLabel
  : Itest_Aliased
{
  _Identifier enum { get; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
  _Identifier label { get; }
}

public interface Itest_UnionRef
  : Itest_TypeRef
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  _Identifier union { get; }
}
