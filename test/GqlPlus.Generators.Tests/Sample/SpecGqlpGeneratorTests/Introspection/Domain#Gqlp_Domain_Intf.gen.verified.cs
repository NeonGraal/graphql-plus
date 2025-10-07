//HintName: Gqlp_Domain_Intf.gen.cs
// Generated from Domain.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Domain;

public interface I_TypeDomain
{
  _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; }
}

public interface I_DomainRef<Tkind>
  : I_TypeRef
{
  Tkind domainKind { get; }
}

public interface I_BaseDomain<Tdomain,Titem,TdomainItem>
  : I_ParentType
{
  Tdomain domainKind { get; }
}

public interface I_BaseDomainItem
  : I_Described
{
  Boolean exclude { get; }
}

public interface I_DomainItem<Titem>
  : Iitem
{
  _Identifier domain { get; }
}

public interface I_DomainValue<Tkind,Tvalue>
  : I_DomainRef
{
  Tvalue value { get; }
  Tvalue Asvalue { get; }
}

public interface I_BasicValue
{
  _DomainKind As_DomainKind { get; }
  _EnumValue As_EnumValue { get; }
  _DomainKind As_DomainKind { get; }
  _DomainKind As_DomainKind { get; }
}

public interface I_DomainTrueFalse
  : I_BaseDomainItem
{
  Boolean value { get; }
}

public interface I_DomainItemTrueFalse
  : I_DomainItem
{
}

public interface I_DomainLabel
  : I_BaseDomainItem
{
  _EnumValue label { get; }
}

public interface I_DomainItemLabel
  : I_DomainItem
{
}

public interface I_DomainRange
  : I_BaseDomainItem
{
  Number lower { get; }
  Number upper { get; }
}

public interface I_DomainItemRange
  : I_DomainItem
{
}

public interface I_DomainRegex
  : I_BaseDomainItem
{
  String pattern { get; }
}

public interface I_DomainItemRegex
  : I_DomainItem
{
}
