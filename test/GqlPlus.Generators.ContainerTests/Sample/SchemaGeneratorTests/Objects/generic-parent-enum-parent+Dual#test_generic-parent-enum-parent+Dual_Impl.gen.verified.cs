//HintName: test_generic-parent-enum-parent+Dual_Impl.gen.cs
// Generated from generic-parent-enum-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public class testGnrcPrntEnumPrntDual
  : testFieldGnrcPrntEnumPrntDual
  , ItestGnrcPrntEnumPrntDual
{
  public ItestGnrcPrntEnumPrntDualObject AsGnrcPrntEnumPrntDual { get; set; }
}

public class testFieldGnrcPrntEnumPrntDual<Tref>
  : ItestFieldGnrcPrntEnumPrntDual<Tref>
{
  public Tref Field { get; set; }
  public ItestFieldGnrcPrntEnumPrntDualObject AsFieldGnrcPrntEnumPrntDual { get; set; }
}
