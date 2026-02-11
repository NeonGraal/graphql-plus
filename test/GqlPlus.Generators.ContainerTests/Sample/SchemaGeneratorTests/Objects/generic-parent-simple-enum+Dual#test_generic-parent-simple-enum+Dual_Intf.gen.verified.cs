//HintName: test_generic-parent-simple-enum+Dual_Intf.gen.cs
// Generated from generic-parent-simple-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

public interface ItestGnrcPrntSmplEnumDual
  : ItestFieldGnrcPrntSmplEnumDual<testEnumGnrcPrntSmplEnumDual>
{
  ItestGnrcPrntSmplEnumDualObject AsGnrcPrntSmplEnumDual { get; }
}

public interface ItestGnrcPrntSmplEnumDualObject
  : ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>
{
}

public interface ItestFieldGnrcPrntSmplEnumDual<TRef>
{
  ItestFieldGnrcPrntSmplEnumDualObject AsFieldGnrcPrntSmplEnumDual { get; }
}

public interface ItestFieldGnrcPrntSmplEnumDualObject<TRef>
{
  TRef Field { get; }
}
