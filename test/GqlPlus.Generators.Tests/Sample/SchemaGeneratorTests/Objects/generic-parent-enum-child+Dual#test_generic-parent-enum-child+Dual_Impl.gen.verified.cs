//HintName: test_generic-parent-enum-child+Dual_Impl.gen.cs
// Generated from generic-parent-enum-child+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public class testGnrcPrntEnumChildDual
  : testFieldGnrcPrntEnumChildDual
  , ItestGnrcPrntEnumChildDual
{
  public testGnrcPrntEnumChildDual GnrcPrntEnumChildDual { get; set; }
}

public class testFieldGnrcPrntEnumChildDual<Tref>
  : ItestFieldGnrcPrntEnumChildDual<Tref>
{
  public Tref field { get; set; }
  public testFieldGnrcPrntEnumChildDual FieldGnrcPrntEnumChildDual { get; set; }
}
