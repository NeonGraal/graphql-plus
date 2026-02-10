//HintName: test_constraint-enum+Dual_Intf.gen.cs
// Generated from constraint-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public interface ItestCnstEnumDual
{
  public ItestRefCnstEnumDual<testEnumCnstEnumDual> AsRefCnstEnumDual { get; set; }
  public ItestCnstEnumDualObject AsCnstEnumDual { get; set; }
}

public interface ItestCnstEnumDualObject
{
}

public interface ItestRefCnstEnumDual<Ttype>
{
  public ItestRefCnstEnumDualObject AsRefCnstEnumDual { get; set; }
}

public interface ItestRefCnstEnumDualObject<Ttype>
{
  public Ttype Field { get; set; }
}
