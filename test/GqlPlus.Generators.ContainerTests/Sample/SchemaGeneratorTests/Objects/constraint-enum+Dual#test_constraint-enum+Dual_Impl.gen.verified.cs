//HintName: test_constraint-enum+Dual_Impl.gen.cs
// Generated from constraint-enum+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public class testCnstEnumDual
  : ItestCnstEnumDual
{
  public ItestRefCnstEnumDual<testEnumCnstEnumDual> AsRefCnstEnumDual { get; set; }
  public ItestCnstEnumDualObject AsCnstEnumDual { get; set; }
}

public class testRefCnstEnumDual<Ttype>
  : ItestRefCnstEnumDual<Ttype>
{
  public Ttype Field { get; set; }
  public ItestRefCnstEnumDualObject AsRefCnstEnumDual { get; set; }
}
