//HintName: test_generic-parent-enum-child+Dual_Intf.gen.cs
// Generated from generic-parent-enum-child+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public interface ItestGnrcPrntEnumChildDual
  : ItestFieldGnrcPrntEnumChildDual
{
  public testGnrcPrntEnumChildDual GnrcPrntEnumChildDual { get; set; }
}

public interface ItestGnrcPrntEnumChildDualField
  : ItestFieldGnrcPrntEnumChildDualField
{
}

public interface ItestFieldGnrcPrntEnumChildDual<Tref>
{
  public testFieldGnrcPrntEnumChildDual FieldGnrcPrntEnumChildDual { get; set; }
}

public interface ItestFieldGnrcPrntEnumChildDualField<Tref>
{
  public Tref field { get; set; }
}
