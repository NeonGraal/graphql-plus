//HintName: test_generic-parent-enum-dom+Dual_Intf.gen.cs
// Generated from generic-parent-enum-dom+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public interface ItestGnrcPrntEnumDomDual
  : ItestFieldGnrcPrntEnumDomDual
{
}

public interface ItestGnrcPrntEnumDomDualObject
  : ItestFieldGnrcPrntEnumDomDualObject
{
}

public interface ItestFieldGnrcPrntEnumDomDual<Tref>
{
}

public interface ItestFieldGnrcPrntEnumDomDualObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestDomGnrcPrntEnumDomDual
  : IDomainEnum
{
}
