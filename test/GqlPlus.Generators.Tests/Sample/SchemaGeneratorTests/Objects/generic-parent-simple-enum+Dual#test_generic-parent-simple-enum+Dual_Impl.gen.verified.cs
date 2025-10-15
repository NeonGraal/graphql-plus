//HintName: test_generic-parent-simple-enum+Dual_Impl.gen.cs
// Generated from generic-parent-simple-enum+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

public class DualtestGnrcPrntSmplEnumDual
  : DualtestFieldGnrcPrntSmplEnumDual
  , ItestGnrcPrntSmplEnumDual
{
}

public class DualtestFieldGnrcPrntSmplEnumDual<Tref>
  : ItestFieldGnrcPrntSmplEnumDual<Tref>
{
  public Tref field { get; set; }
}
