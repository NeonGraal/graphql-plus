//HintName: test_generic-parent-simple-enum+Dual_Intf.gen.cs
// Generated from generic-parent-simple-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

public interface ItestGnrcPrntSmplEnumDual
  : ItestFieldGnrcPrntSmplEnumDual
{
  ItestGnrcPrntSmplEnumDualObject AsGnrcPrntSmplEnumDual { get; }
}

public interface ItestGnrcPrntSmplEnumDualObject
  : ItestFieldGnrcPrntSmplEnumDualObject
{
}

public interface ItestFieldGnrcPrntSmplEnumDual<Tref>
{
  ItestFieldGnrcPrntSmplEnumDualObject AsFieldGnrcPrntSmplEnumDual { get; }
}

public interface ItestFieldGnrcPrntSmplEnumDualObject<Tref>
{
  Tref Field { get; }
}
