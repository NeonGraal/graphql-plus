//HintName: test_generic-parent-enum-parent+Dual_Impl.gen.cs
// Generated from generic-parent-enum-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public class testGnrcPrntEnumPrntDual
  : testFieldGnrcPrntEnumPrntDual
  , ItestGnrcPrntEnumPrntDual
{
  public testGnrcPrntEnumPrntDual GnrcPrntEnumPrntDual { get; set; }
}

public class testFieldGnrcPrntEnumPrntDual<Tref>
  : ItestFieldGnrcPrntEnumPrntDual<Tref>
{
  public Tref field { get; set; }
  public testFieldGnrcPrntEnumPrntDual FieldGnrcPrntEnumPrntDual { get; set; }
}
