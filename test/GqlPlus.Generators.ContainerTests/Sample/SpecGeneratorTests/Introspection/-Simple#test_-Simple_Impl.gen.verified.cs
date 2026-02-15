//HintName: test_-Simple_Impl.gen.cs
// Generated from -Simple.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public class test_DomainRef<TKind>
  : test_TypeRef<Itest_TypeKind>
  , Itest_DomainRef<TKind>
{
  public TKind DomainKind { get; set; }
}

public class test_BaseDomain<TDomain,TItem,TDomainItem>
  : test_ParentType<Itest_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomain<TDomain,TItem,TDomainItem>
{
  public TDomain DomainKind { get; set; }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public test_DomainKind Exclude { get; set; }
}

public class test_DomainItem<TItem>
  : Itest_DomainItem<TItem>
{
  public Itest_Name Domain { get; set; }
}

public class test_DomainValue<TKind,TValue>
  : test_DomainRef<TKind>
  , Itest_DomainValue<TKind,TValue>
{
  public TValue Value { get; set; }
}

public class test_BasicValue
  : Itest_BasicValue
{
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public test_DomainKind Value { get; set; }
}

public class test_DomainItemTrueFalse
  : test_DomainItem<Itest_DomainTrueFalse>
  , Itest_DomainItemTrueFalse
{
}

public class test_DomainLabel
  : test_BaseDomainItem
  , Itest_DomainLabel
{
  public Itest_EnumValue Label { get; set; }
}

public class test_DomainItemLabel
  : test_DomainItem<Itest_DomainLabel>
  , Itest_DomainItemLabel
{
}

public class test_DomainRange
  : test_BaseDomainItem
  , Itest_DomainRange
{
  public test_DomainKind? Lower { get; set; }
  public test_DomainKind? Upper { get; set; }
}

public class test_DomainItemRange
  : test_DomainItem<Itest_DomainRange>
  , Itest_DomainItemRange
{
}

public class test_DomainRegex
  : test_BaseDomainItem
  , Itest_DomainRegex
{
  public test_DomainKind Pattern { get; set; }
}

public class test_DomainItemRegex
  : test_DomainItem<Itest_DomainRegex>
  , Itest_DomainItemRegex
{
}

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public Itest_Name EnumType { get; set; }
}

public class test_EnumValue
  : test_TypeRef<Itest_TypeKind>
  , Itest_EnumValue
{
  public Itest_Name Label { get; set; }
}

public class test_UnionRef
  : test_TypeRef<Itest_SimpleKind>
  , Itest_UnionRef
{
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public Itest_Name Union { get; set; }
}
