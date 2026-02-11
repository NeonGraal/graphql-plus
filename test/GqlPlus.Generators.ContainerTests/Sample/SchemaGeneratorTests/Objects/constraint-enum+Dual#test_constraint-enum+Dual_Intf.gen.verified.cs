//HintName: test_constraint-enum+Dual_Intf.gen.cs
// Generated from constraint-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public interface ItestCnstEnumDual
{
  ItestRefCnstEnumDual<testEnumCnstEnumDual> AsEnumCnstEnumDualcnstEnumDual { get; }
  ItestCnstEnumDualObject AsCnstEnumDual { get; }
}

public interface ItestCnstEnumDualObject
{
}

public interface ItestRefCnstEnumDual<TType>
{
  ItestRefCnstEnumDualObject AsRefCnstEnumDual { get; }
}

public interface ItestRefCnstEnumDualObject<TType>
{
  TType Field { get; }
}
