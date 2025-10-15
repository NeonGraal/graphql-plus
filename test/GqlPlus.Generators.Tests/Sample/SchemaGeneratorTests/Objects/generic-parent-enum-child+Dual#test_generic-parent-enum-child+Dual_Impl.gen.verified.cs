//HintName: test_generic-parent-enum-child+Dual_Impl.gen.cs
// Generated from generic-parent-enum-child+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public class DualtestGnrcPrntEnumChildDual
  : DualtestFieldGnrcPrntEnumChildDual
  , ItestGnrcPrntEnumChildDual
{
}

public class DualtestFieldGnrcPrntEnumChildDual<Tref>
  : ItestFieldGnrcPrntEnumChildDual<Tref>
{
  public Tref field { get; set; }
}
