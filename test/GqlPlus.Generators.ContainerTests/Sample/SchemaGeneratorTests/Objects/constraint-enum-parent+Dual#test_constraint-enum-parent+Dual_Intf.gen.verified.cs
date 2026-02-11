//HintName: test_constraint-enum-parent+Dual_Intf.gen.cs
// Generated from constraint-enum-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public interface ItestCnstEnumPrntDual
{
  ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual> AsRefCnstEnumPrntDual { get; }
  ItestCnstEnumPrntDualObject AsCnstEnumPrntDual { get; }
}

public interface ItestCnstEnumPrntDualObject
{
}

public interface ItestRefCnstEnumPrntDual<Ttype>
{
  ItestRefCnstEnumPrntDualObject AsRefCnstEnumPrntDual { get; }
}

public interface ItestRefCnstEnumPrntDualObject<Ttype>
{
  Ttype Field { get; }
}
