//HintName: test_generic-enum+Dual_Intf.gen.cs
// Generated from generic-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public interface ItestGnrcEnumDual
{
  ItestRefGnrcEnumDual<testEnumGnrcEnumDual> AsEnumGnrcEnumDualgnrcEnumDual { get; }
  ItestGnrcEnumDualObject AsGnrcEnumDual { get; }
}

public interface ItestGnrcEnumDualObject
{
}

public interface ItestRefGnrcEnumDual<TType>
{
  ItestRefGnrcEnumDualObject<TType> AsRefGnrcEnumDual { get; }
}

public interface ItestRefGnrcEnumDualObject<TType>
{
  TType Field { get; }
}
