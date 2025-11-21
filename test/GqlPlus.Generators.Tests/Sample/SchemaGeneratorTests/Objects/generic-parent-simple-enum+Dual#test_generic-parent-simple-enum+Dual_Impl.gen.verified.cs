//HintName: test_generic-parent-simple-enum+Dual_Impl.gen.cs
// Generated from generic-parent-simple-enum+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

public class testGnrcPrntSmplEnumDual
  : testFieldGnrcPrntSmplEnumDual
  , ItestGnrcPrntSmplEnumDual
{
  public testGnrcPrntSmplEnumDual GnrcPrntSmplEnumDual { get; set; }
}

public class testFieldGnrcPrntSmplEnumDual<Tref>
  : ItestFieldGnrcPrntSmplEnumDual<Tref>
{
  public Tref field { get; set; }
  public testFieldGnrcPrntSmplEnumDual FieldGnrcPrntSmplEnumDual { get; set; }
}
