//HintName: test_generic-parent-enum-child+Dual_Intf.gen.cs
// Generated from generic-parent-enum-child+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public interface ItestGnrcPrntEnumChildDual
  : ItestFieldGnrcPrntEnumChildDual
{
  public ItestGnrcPrntEnumChildDualObject AsGnrcPrntEnumChildDual { get; set; }
}

public interface ItestGnrcPrntEnumChildDualObject
  : ItestFieldGnrcPrntEnumChildDualObject
{
}

public interface ItestFieldGnrcPrntEnumChildDual<Tref>
{
  public ItestFieldGnrcPrntEnumChildDualObject AsFieldGnrcPrntEnumChildDual { get; set; }
}

public interface ItestFieldGnrcPrntEnumChildDualObject<Tref>
{
  public Tref Field { get; set; }
}
