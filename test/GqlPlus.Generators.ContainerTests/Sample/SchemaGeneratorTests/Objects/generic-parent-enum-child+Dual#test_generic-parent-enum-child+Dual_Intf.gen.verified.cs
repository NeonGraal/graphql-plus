//HintName: test_generic-parent-enum-child+Dual_Intf.gen.cs
// Generated from generic-parent-enum-child+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public interface ItestGnrcPrntEnumChildDual
  : ItestFieldGnrcPrntEnumChildDual
{
  ItestGnrcPrntEnumChildDualObject AsGnrcPrntEnumChildDual { get; }
}

public interface ItestGnrcPrntEnumChildDualObject
  : ItestFieldGnrcPrntEnumChildDualObject
{
}

public interface ItestFieldGnrcPrntEnumChildDual<Tref>
{
  ItestFieldGnrcPrntEnumChildDualObject AsFieldGnrcPrntEnumChildDual { get; }
}

public interface ItestFieldGnrcPrntEnumChildDualObject<Tref>
{
  Tref Field { get; }
}
