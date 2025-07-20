//HintName: Model_Intro_+Simple.gen.cs
// Generated from Intro_+Simple.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_Intro__Simple;

public enum _DomainKind
{
  Boolean,
  Enum,
  Number,
  String,
}

public interface I_TypeDomain
{
  _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; }
}
public class Output_TypeDomain
  : I_TypeDomain
{
  public _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; set; }
}

public interface I_DomainRef<Tkind>
  : I_TypeRef
{
  Tkind domainKind { get; }
}
public class Output_DomainRef<Tkind>
  : Output_TypeRef
  , I_DomainRef<Tkind>
{
  public Tkind domainKind { get; set; }
}

public interface I_BaseDomain<Tdomain,Titem,TdomainItem>
  : I_ParentType
{
  Tdomain domainKind { get; }
}
public class Output_BaseDomain<Tdomain,Titem,TdomainItem>
  : Output_ParentType
  , I_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain domainKind { get; set; }
}

public interface I_BaseDomainItem
  : I_Described
{
  Boolean exclude { get; }
}
public class Dual_BaseDomainItem
  : Dual_Described
  , I_BaseDomainItem
{
  public Boolean exclude { get; set; }
}

public interface I_DomainItem<Titem>
  : Iitem
{
  _Identifier domain { get; }
}
public class Output_DomainItem<Titem>
  : Outputitem
  , I_DomainItem<Titem>
{
  public _Identifier domain { get; set; }
}

public interface I_DomainValue<Tkind,Tvalue>
  : I_DomainRef
{
  Tvalue value { get; }
}
public class Output_DomainValue<Tkind,Tvalue>
  : Output_DomainRef
  , I_DomainValue<Tkind,Tvalue>
{
  public Tvalue value { get; set; }
}

public interface I_BasicValue
{
  Boolean AsBoolean { get; }
  _EnumValue As_EnumValue { get; }
  Number AsNumber { get; }
  String AsString { get; }
}
public class Output_BasicValue
  : I_BasicValue
{
  public Boolean AsBoolean { get; set; }
  public _EnumValue As_EnumValue { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
}

public interface I_DomainTrueFalse
  : I_BaseDomainItem
{
  Boolean value { get; }
}
public class Dual_DomainTrueFalse
  : Dual_BaseDomainItem
  , I_DomainTrueFalse
{
  public Boolean value { get; set; }
}

public interface I_DomainItemTrueFalse
  : I_DomainItem
{
}
public class Output_DomainItemTrueFalse
  : Output_DomainItem
  , I_DomainItemTrueFalse
{
}

public interface I_DomainLabel
  : I_BaseDomainItem
{
  _EnumValue label { get; }
}
public class Output_DomainLabel
  : Output_BaseDomainItem
  , I_DomainLabel
{
  public _EnumValue label { get; set; }
}

public interface I_DomainItemLabel
  : I_DomainItem
{
}
public class Output_DomainItemLabel
  : Output_DomainItem
  , I_DomainItemLabel
{
}

public interface I_DomainRange
  : I_BaseDomainItem
{
  Number lower { get; }
  Number upper { get; }
}
public class Dual_DomainRange
  : Dual_BaseDomainItem
  , I_DomainRange
{
  public Number lower { get; set; }
  public Number upper { get; set; }
}

public interface I_DomainItemRange
  : I_DomainItem
{
}
public class Output_DomainItemRange
  : Output_DomainItem
  , I_DomainItemRange
{
}

public interface I_DomainRegex
  : I_BaseDomainItem
{
  String pattern { get; }
}
public class Dual_DomainRegex
  : Dual_BaseDomainItem
  , I_DomainRegex
{
  public String pattern { get; set; }
}

public interface I_DomainItemRegex
  : I_DomainItem
{
}
public class Output_DomainItemRegex
  : Output_DomainItem
  , I_DomainItemRegex
{
}

public interface I_TypeEnum
  : I_ParentType
{
}
public class Output_TypeEnum
  : Output_ParentType
  , I_TypeEnum
{
}

public interface I_EnumLabel
  : I_Aliased
{
  _Identifier enum { get; }
}
public class Dual_EnumLabel
  : Dual_Aliased
  , I_EnumLabel
{
  public _Identifier enum { get; set; }
}

public interface I_EnumValue
  : I_TypeRef
{
  _Identifier label { get; }
}
public class Output_EnumValue
  : Output_TypeRef
  , I_EnumValue
{
  public _Identifier label { get; set; }
}

public interface I_TypeUnion
  : I_ParentType
{
}
public class Output_TypeUnion
  : Output_ParentType
  , I_TypeUnion
{
}

public interface I_UnionRef
  : I_TypeRef
{
}
public class Output_UnionRef
  : Output_TypeRef
  , I_UnionRef
{
}

public interface I_UnionMember
  : I_UnionRef
{
  _Identifier union { get; }
}
public class Output_UnionMember
  : Output_UnionRef
  , I_UnionMember
{
  public _Identifier union { get; set; }
}
