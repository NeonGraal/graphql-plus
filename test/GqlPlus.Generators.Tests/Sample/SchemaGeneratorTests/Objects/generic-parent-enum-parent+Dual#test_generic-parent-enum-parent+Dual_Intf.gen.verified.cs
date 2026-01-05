//HintName: test_generic-parent-enum-parent+Dual_Intf.gen.cs
// Generated from generic-parent-enum-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public interface ItestGnrcPrntEnumPrntDual
  : ItestFieldGnrcPrntEnumPrntDual
{
  public testGnrcPrntEnumPrntDual GnrcPrntEnumPrntDual { get; set; }
}

public interface ItestGnrcPrntEnumPrntDualField
  : ItestFieldGnrcPrntEnumPrntDualField
{
}

public interface ItestFieldGnrcPrntEnumPrntDual<Tref>
{
  public testFieldGnrcPrntEnumPrntDual FieldGnrcPrntEnumPrntDual { get; set; }
}

public interface ItestFieldGnrcPrntEnumPrntDualField<Tref>
{
  public Tref field { get; set; }
}
