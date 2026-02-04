//HintName: test_Domain_Impl.gen.cs
// Generated from Domain.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

public class test_DomainRef<Tkind>
  : test_TypeRef
  , Itest_DomainRef<Tkind>
{
  public Tkind domainKind { get; set; }
  public test_DomainRef _DomainRef { get; set; }
}

public class test_BaseDomain<Tdomain,Titem,TdomainItem>
  : test_ParentType
  , Itest_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain domainKind { get; set; }
  public test_BaseDomain _BaseDomain { get; set; }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public test_DomainKind exclude { get; set; }
  public test_BaseDomainItem _BaseDomainItem { get; set; }
}

public class test_DomainItem<Titem>
  : testitem
  , Itest_DomainItem<Titem>
{
  public test_Name domain { get; set; }
  public test_DomainItem _DomainItem { get; set; }
}

public class test_DomainValue<Tkind,Tvalue>
  : test_DomainRef
  , Itest_DomainValue<Tkind,Tvalue>
{
  public Tvalue value { get; set; }
  public Tvalue Asvalue { get; set; }
  public test_DomainValue _DomainValue { get; set; }
}

public class test_BasicValue
  : Itest_BasicValue
{
  public test_DomainKind As_DomainKindBoolean { get; set; }
  public test_EnumValue As_EnumValue { get; set; }
  public test_DomainKind As_DomainKindNumber { get; set; }
  public test_DomainKind As_DomainKindString { get; set; }
  public test_BasicValue _BasicValue { get; set; }
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public test_DomainKind value { get; set; }
  public test_DomainTrueFalse _DomainTrueFalse { get; set; }
}

public class test_DomainItemTrueFalse
  : test_DomainItem
  , Itest_DomainItemTrueFalse
{
  public test_DomainItemTrueFalse _DomainItemTrueFalse { get; set; }
}

public class test_DomainLabel
  : test_BaseDomainItem
  , Itest_DomainLabel
{
  public test_EnumValue label { get; set; }
  public test_DomainLabel _DomainLabel { get; set; }
}

public class test_DomainItemLabel
  : test_DomainItem
  , Itest_DomainItemLabel
{
  public test_DomainItemLabel _DomainItemLabel { get; set; }
}

public class test_DomainRange
  : test_BaseDomainItem
  , Itest_DomainRange
{
  public test_DomainKind? lower { get; set; }
  public test_DomainKind? upper { get; set; }
  public test_DomainRange _DomainRange { get; set; }
}

public class test_DomainItemRange
  : test_DomainItem
  , Itest_DomainItemRange
{
  public test_DomainItemRange _DomainItemRange { get; set; }
}

public class test_DomainRegex
  : test_BaseDomainItem
  , Itest_DomainRegex
{
  public test_DomainKind pattern { get; set; }
  public test_DomainRegex _DomainRegex { get; set; }
}

public class test_DomainItemRegex
  : test_DomainItem
  , Itest_DomainItemRegex
{
  public test_DomainItemRegex _DomainItemRegex { get; set; }
}
