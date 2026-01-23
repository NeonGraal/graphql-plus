//HintName: test_generic-parent-simple-enum+Dual_Intf.gen.cs
// Generated from generic-parent-simple-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

public interface ItestGnrcPrntSmplEnumDual
  : ItestFieldGnrcPrntSmplEnumDual
{
  public testGnrcPrntSmplEnumDual GnrcPrntSmplEnumDual { get; set; }
}

public interface ItestGnrcPrntSmplEnumDualObject
  : ItestFieldGnrcPrntSmplEnumDualObject
{
}

public interface ItestFieldGnrcPrntSmplEnumDual<Tref>
{
  public testFieldGnrcPrntSmplEnumDual FieldGnrcPrntSmplEnumDual { get; set; }
}

public interface ItestFieldGnrcPrntSmplEnumDualObject<Tref>
{
  public Tref field { get; set; }
}
