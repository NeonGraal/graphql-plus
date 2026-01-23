//HintName: test_generic-parent-enum-dom+Dual_Intf.gen.cs
// Generated from generic-parent-enum-dom+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public interface ItestGnrcPrntEnumDomDual
  : ItestFieldGnrcPrntEnumDomDual
{
  public testGnrcPrntEnumDomDual GnrcPrntEnumDomDual { get; set; }
}

public interface ItestGnrcPrntEnumDomDualObject
  : ItestFieldGnrcPrntEnumDomDualObject
{
}

public interface ItestFieldGnrcPrntEnumDomDual<Tref>
{
  public testFieldGnrcPrntEnumDomDual FieldGnrcPrntEnumDomDual { get; set; }
}

public interface ItestFieldGnrcPrntEnumDomDualObject<Tref>
{
  public Tref field { get; set; }
}

public interface ItestDomGnrcPrntEnumDomDual
  : IDomainEnum
{
}
