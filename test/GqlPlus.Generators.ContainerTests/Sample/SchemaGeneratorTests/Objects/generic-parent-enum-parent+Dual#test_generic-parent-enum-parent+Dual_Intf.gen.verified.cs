//HintName: test_generic-parent-enum-parent+Dual_Intf.gen.cs
// Generated from generic-parent-enum-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public interface ItestGnrcPrntEnumPrntDual
  : ItestFieldGnrcPrntEnumPrntDual
{
  ItestGnrcPrntEnumPrntDualObject AsGnrcPrntEnumPrntDual { get; }
}

public interface ItestGnrcPrntEnumPrntDualObject
  : ItestFieldGnrcPrntEnumPrntDualObject
{
}

public interface ItestFieldGnrcPrntEnumPrntDual<Tref>
{
  ItestFieldGnrcPrntEnumPrntDualObject AsFieldGnrcPrntEnumPrntDual { get; }
}

public interface ItestFieldGnrcPrntEnumPrntDualObject<Tref>
{
  Tref Field { get; }
}
