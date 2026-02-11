//HintName: test_generic-parent-enum-dom+Dual_Intf.gen.cs
// Generated from generic-parent-enum-dom+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public interface ItestGnrcPrntEnumDomDual
  : ItestFieldGnrcPrntEnumDomDual
{
  ItestGnrcPrntEnumDomDualObject AsGnrcPrntEnumDomDual { get; }
}

public interface ItestGnrcPrntEnumDomDualObject
  : ItestFieldGnrcPrntEnumDomDualObject
{
}

public interface ItestFieldGnrcPrntEnumDomDual<Tref>
{
  ItestFieldGnrcPrntEnumDomDualObject AsFieldGnrcPrntEnumDomDual { get; }
}

public interface ItestFieldGnrcPrntEnumDomDualObject<Tref>
{
  Tref Field { get; }
}

public interface ItestDomGnrcPrntEnumDomDual
  : IDomainEnum
{
}
