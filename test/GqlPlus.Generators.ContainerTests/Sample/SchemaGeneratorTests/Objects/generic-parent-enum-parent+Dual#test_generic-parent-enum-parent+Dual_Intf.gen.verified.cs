//HintName: test_generic-parent-enum-parent+Dual_Intf.gen.cs
// Generated from generic-parent-enum-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public interface ItestGnrcPrntEnumPrntDual
  : ItestFieldGnrcPrntEnumPrntDual<testEnumGnrcPrntEnumPrntDual>
{
  ItestGnrcPrntEnumPrntDualObject AsGnrcPrntEnumPrntDual { get; }
}

public interface ItestGnrcPrntEnumPrntDualObject
  : ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>
{
}

public interface ItestFieldGnrcPrntEnumPrntDual<TRef>
{
  ItestFieldGnrcPrntEnumPrntDualObject AsFieldGnrcPrntEnumPrntDual { get; }
}

public interface ItestFieldGnrcPrntEnumPrntDualObject<TRef>
{
  TRef Field { get; }
}
