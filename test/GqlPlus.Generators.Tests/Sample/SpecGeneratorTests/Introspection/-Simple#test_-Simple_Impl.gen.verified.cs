//HintName: test_-Simple_Impl.gen.cs
// Generated from -Simple.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public class test_TypeDomain
  : Itest_TypeDomain
{
  public _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; set; }
}

public class test_DomainRef<Tkind>
  : test_TypeRef
  , Itest_DomainRef<Tkind>
{
  public Tkind domainKind { get; set; }
}

public class test_BaseDomain<Tdomain,Titem,TdomainItem>
  : test_ParentType
  , Itest_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain domainKind { get; set; }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public Boolean exclude { get; set; }
}

public class test_DomainItem<Titem>
  : testitem
  , Itest_DomainItem<Titem>
{
  public _Identifier domain { get; set; }
}

public class test_DomainValue<Tkind,Tvalue>
  : test_DomainRef
  , Itest_DomainValue<Tkind,Tvalue>
{
  public Tvalue value { get; set; }
  public Tvalue Asvalue { get; set; }
}

public class test_BasicValue
  : Itest_BasicValue
{
  public _DomainKind As_DomainKind { get; set; }
  public _EnumValue As_EnumValue { get; set; }
  public _DomainKind As_DomainKind { get; set; }
  public _DomainKind As_DomainKind { get; set; }
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public Boolean value { get; set; }
}

public class test_DomainItemTrueFalse
  : test_DomainItem
  , Itest_DomainItemTrueFalse
{
}

public class test_DomainLabel
  : test_BaseDomainItem
  , Itest_DomainLabel
{
  public _EnumValue label { get; set; }
}

public class test_DomainItemLabel
  : test_DomainItem
  , Itest_DomainItemLabel
{
}

public class test_DomainRange
  : test_BaseDomainItem
  , Itest_DomainRange
{
  public Number lower { get; set; }
  public Number upper { get; set; }
}

public class test_DomainItemRange
  : test_DomainItem
  , Itest_DomainItemRange
{
}

public class test_DomainRegex
  : test_BaseDomainItem
  , Itest_DomainRegex
{
  public String pattern { get; set; }
}

public class test_DomainItemRegex
  : test_DomainItem
  , Itest_DomainItemRegex
{
}

public class test_TypeEnum
  : test_ParentType
  , Itest_TypeEnum
{
}

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public _Identifier enum { get; set; }
}

public class test_EnumValue
  : test_TypeRef
  , Itest_EnumValue
{
  public _Identifier label { get; set; }
}

public class test_TypeUnion
  : test_ParentType
  , Itest_TypeUnion
{
}

public class test_UnionRef
  : test_TypeRef
  , Itest_UnionRef
{
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public _Identifier union { get; set; }
}
