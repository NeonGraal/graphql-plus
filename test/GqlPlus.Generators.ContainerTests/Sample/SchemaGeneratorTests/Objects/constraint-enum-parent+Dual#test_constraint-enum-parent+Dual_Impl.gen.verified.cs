//HintName: test_constraint-enum-parent+Dual_Impl.gen.cs
// Generated from constraint-enum-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public class testCnstEnumPrntDual
  : ItestCnstEnumPrntDual
{
  public ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual> AsRefCnstEnumPrntDual { get; set; }
  public ItestCnstEnumPrntDualObject AsCnstEnumPrntDual { get; set; }
}

public class testRefCnstEnumPrntDual<Ttype>
  : ItestRefCnstEnumPrntDual<Ttype>
{
  public Ttype Field { get; set; }
  public ItestRefCnstEnumPrntDualObject AsRefCnstEnumPrntDual { get; set; }
}
