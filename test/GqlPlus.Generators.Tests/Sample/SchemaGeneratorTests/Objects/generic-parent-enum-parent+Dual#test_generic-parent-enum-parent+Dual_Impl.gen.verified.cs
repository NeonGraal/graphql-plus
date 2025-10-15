//HintName: test_generic-parent-enum-parent+Dual_Impl.gen.cs
// Generated from generic-parent-enum-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public class DualtestGnrcPrntEnumPrntDual
  : DualtestFieldGnrcPrntEnumPrntDual
  , ItestGnrcPrntEnumPrntDual
{
}

public class DualtestFieldGnrcPrntEnumPrntDual<Tref>
  : ItestFieldGnrcPrntEnumPrntDual<Tref>
{
  public Tref field { get; set; }
}
