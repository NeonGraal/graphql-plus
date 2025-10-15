//HintName: test_-Simple_Impl.gen.cs
// Generated from -Simple.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public class Outputtest_TypeDomain
  : Itest_TypeDomain
{
  public _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; set; }
}

public class Outputtest_DomainRef<Tkind>
  : Outputtest_TypeRef
  , Itest_DomainRef<Tkind>
{
  public Tkind domainKind { get; set; }
}

public class Outputtest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Outputtest_ParentType
  , Itest_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain domainKind { get; set; }
}

public class Dualtest_BaseDomainItem
  : Dualtest_Described
  , Itest_BaseDomainItem
{
  public Boolean exclude { get; set; }
}

public class Outputtest_DomainItem<Titem>
  : Outputtestitem
  , Itest_DomainItem<Titem>
{
  public _Identifier domain { get; set; }
}

public class Outputtest_DomainValue<Tkind,Tvalue>
  : Outputtest_DomainRef
  , Itest_DomainValue<Tkind,Tvalue>
{
  public Tvalue value { get; set; }
  public Tvalue Asvalue { get; set; }
}

public class Outputtest_BasicValue
  : Itest_BasicValue
{
  public _DomainKind As_DomainKind { get; set; }
  public _EnumValue As_EnumValue { get; set; }
  public _DomainKind As_DomainKind { get; set; }
  public _DomainKind As_DomainKind { get; set; }
}

public class Dualtest_DomainTrueFalse
  : Dualtest_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public Boolean value { get; set; }
}

public class Outputtest_DomainItemTrueFalse
  : Outputtest_DomainItem
  , Itest_DomainItemTrueFalse
{
}

public class Outputtest_DomainLabel
  : Outputtest_BaseDomainItem
  , Itest_DomainLabel
{
  public _EnumValue label { get; set; }
}

public class Outputtest_DomainItemLabel
  : Outputtest_DomainItem
  , Itest_DomainItemLabel
{
}

public class Dualtest_DomainRange
  : Dualtest_BaseDomainItem
  , Itest_DomainRange
{
  public Number lower { get; set; }
  public Number upper { get; set; }
}

public class Outputtest_DomainItemRange
  : Outputtest_DomainItem
  , Itest_DomainItemRange
{
}

public class Dualtest_DomainRegex
  : Dualtest_BaseDomainItem
  , Itest_DomainRegex
{
  public String pattern { get; set; }
}

public class Outputtest_DomainItemRegex
  : Outputtest_DomainItem
  , Itest_DomainItemRegex
{
}

public class Outputtest_TypeEnum
  : Outputtest_ParentType
  , Itest_TypeEnum
{
}

public class Dualtest_EnumLabel
  : Dualtest_Aliased
  , Itest_EnumLabel
{
  public _Identifier enum { get; set; }
}

public class Outputtest_EnumValue
  : Outputtest_TypeRef
  , Itest_EnumValue
{
  public _Identifier label { get; set; }
}

public class Outputtest_TypeUnion
  : Outputtest_ParentType
  , Itest_TypeUnion
{
}

public class Outputtest_UnionRef
  : Outputtest_TypeRef
  , Itest_UnionRef
{
}

public class Outputtest_UnionMember
  : Outputtest_UnionRef
  , Itest_UnionMember
{
  public _Identifier union { get; set; }
}
