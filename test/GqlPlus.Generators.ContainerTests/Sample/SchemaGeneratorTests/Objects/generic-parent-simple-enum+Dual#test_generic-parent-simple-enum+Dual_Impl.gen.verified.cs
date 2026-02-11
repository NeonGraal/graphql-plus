//HintName: test_generic-parent-simple-enum+Dual_Impl.gen.cs
// Generated from generic-parent-simple-enum+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

public class testGnrcPrntSmplEnumDual
  : testFieldGnrcPrntSmplEnumDual<testEnumGnrcPrntSmplEnumDual>
  , ItestGnrcPrntSmplEnumDual
{
  public ItestGnrcPrntSmplEnumDualObject AsGnrcPrntSmplEnumDual { get; set; }
}

public class testFieldGnrcPrntSmplEnumDual<TRef>
  : ItestFieldGnrcPrntSmplEnumDual<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntSmplEnumDualObject AsFieldGnrcPrntSmplEnumDual { get; set; }
}
