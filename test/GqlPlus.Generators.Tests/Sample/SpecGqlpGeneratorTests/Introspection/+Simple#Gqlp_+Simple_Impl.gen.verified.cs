//HintName: Gqlp_+Simple_Impl.gen.cs
// Generated from +Simple.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp__Simple;

public class Output_TypeDomain
  : I_TypeDomain
{
  public _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; set; }
}

public class Output_DomainRef<Tkind>
  : Output_TypeRef
  , I_DomainRef<Tkind>
{
  public Tkind domainKind { get; set; }
}

public class Output_BaseDomain<Tdomain,Titem,TdomainItem>
  : Output_ParentType
  , I_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain domainKind { get; set; }
}

public class Dual_BaseDomainItem
  : Dual_Described
  , I_BaseDomainItem
{
  public Boolean exclude { get; set; }
}

public class Output_DomainItem<Titem>
  : Outputitem
  , I_DomainItem<Titem>
{
  public _Identifier domain { get; set; }
}

public class Output_DomainValue<Tkind,Tvalue>
  : Output_DomainRef
  , I_DomainValue<Tkind,Tvalue>
{
  public Tvalue value { get; set; }
  public Tvalue Asvalue { get; set; }
}

public class Output_BasicValue
  : I_BasicValue
{
  public Boolean AsBoolean { get; set; }
  public _EnumValue As_EnumValue { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
}

public class Dual_DomainTrueFalse
  : Dual_BaseDomainItem
  , I_DomainTrueFalse
{
  public Boolean value { get; set; }
}

public class Output_DomainItemTrueFalse
  : Output_DomainItem
  , I_DomainItemTrueFalse
{
}

public class Output_DomainLabel
  : Output_BaseDomainItem
  , I_DomainLabel
{
  public _EnumValue label { get; set; }
}

public class Output_DomainItemLabel
  : Output_DomainItem
  , I_DomainItemLabel
{
}

public class Dual_DomainRange
  : Dual_BaseDomainItem
  , I_DomainRange
{
  public Number lower { get; set; }
  public Number upper { get; set; }
}

public class Output_DomainItemRange
  : Output_DomainItem
  , I_DomainItemRange
{
}

public class Dual_DomainRegex
  : Dual_BaseDomainItem
  , I_DomainRegex
{
  public String pattern { get; set; }
}

public class Output_DomainItemRegex
  : Output_DomainItem
  , I_DomainItemRegex
{
}

public class Output_TypeEnum
  : Output_ParentType
  , I_TypeEnum
{
}

public class Dual_EnumLabel
  : Dual_Aliased
  , I_EnumLabel
{
  public _Identifier enum { get; set; }
}

public class Output_EnumValue
  : Output_TypeRef
  , I_EnumValue
{
  public _Identifier label { get; set; }
}

public class Output_TypeUnion
  : Output_ParentType
  , I_TypeUnion
{
}

public class Output_UnionRef
  : Output_TypeRef
  , I_UnionRef
{
}

public class Output_UnionMember
  : Output_UnionRef
  , I_UnionMember
{
  public _Identifier union { get; set; }
}
