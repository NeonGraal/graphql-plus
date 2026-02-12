//HintName: test_generic-parent-enum-child+Dual_Impl.gen.cs
// Generated from generic-parent-enum-child+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public class testGnrcPrntEnumChildDual
  : testFieldGnrcPrntEnumChildDual<testParentGnrcPrntEnumChildDual>
  , ItestGnrcPrntEnumChildDual
{
  public ItestGnrcPrntEnumChildDualObject AsGnrcPrntEnumChildDual { get; set; }
}

public class testFieldGnrcPrntEnumChildDual<TRef>
  : ItestFieldGnrcPrntEnumChildDual<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumChildDualObject<TRef> AsFieldGnrcPrntEnumChildDual { get; set; }
}
