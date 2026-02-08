//HintName: test_generic-parent-enum-parent+Dual_Intf.gen.cs
// Generated from generic-parent-enum-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public interface ItestGnrcPrntEnumPrntDual
  : ItestFieldGnrcPrntEnumPrntDual
{
  public ItestGnrcPrntEnumPrntDualObject AsGnrcPrntEnumPrntDual { get; set; }
}

public interface ItestGnrcPrntEnumPrntDualObject
  : ItestFieldGnrcPrntEnumPrntDualObject
{
}

public interface ItestFieldGnrcPrntEnumPrntDual<Tref>
{
  public ItestFieldGnrcPrntEnumPrntDualObject AsFieldGnrcPrntEnumPrntDual { get; set; }
}

public interface ItestFieldGnrcPrntEnumPrntDualObject<Tref>
{
  public Tref Field { get; set; }
}
