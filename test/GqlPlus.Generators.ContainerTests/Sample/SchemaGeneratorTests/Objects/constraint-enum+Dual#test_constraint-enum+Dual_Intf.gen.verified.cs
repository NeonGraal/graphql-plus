//HintName: test_constraint-enum+Dual_Intf.gen.cs
// Generated from constraint-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public interface ItestCnstEnumDual
{
  public ItestRefCnstEnumDual<ItestEnumCnstEnumDual> AsRefCnstEnumDual { get; set; }
}

public interface ItestCnstEnumDualObject
{
}

public interface ItestRefCnstEnumDual<Ttype>
{
}

public interface ItestRefCnstEnumDualObject<Ttype>
{
  public Ttype Field { get; set; }
}
