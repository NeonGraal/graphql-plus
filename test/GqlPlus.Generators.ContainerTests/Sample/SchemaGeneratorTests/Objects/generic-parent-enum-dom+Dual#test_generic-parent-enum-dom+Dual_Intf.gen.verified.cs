//HintName: test_generic-parent-enum-dom+Dual_Intf.gen.cs
// Generated from generic-parent-enum-dom+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public interface ItestGnrcPrntEnumDomDual
  : ItestFieldGnrcPrntEnumDomDual<ItestDomGnrcPrntEnumDomDual>
{
  ItestGnrcPrntEnumDomDualObject AsGnrcPrntEnumDomDual { get; }
}

public interface ItestGnrcPrntEnumDomDualObject
  : ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>
{
}

public interface ItestFieldGnrcPrntEnumDomDual<TRef>
{
  ItestFieldGnrcPrntEnumDomDualObject<TRef> AsFieldGnrcPrntEnumDomDual { get; }
}

public interface ItestFieldGnrcPrntEnumDomDualObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntEnumDomDual
  : IGqlpDomainEnum
{
}
