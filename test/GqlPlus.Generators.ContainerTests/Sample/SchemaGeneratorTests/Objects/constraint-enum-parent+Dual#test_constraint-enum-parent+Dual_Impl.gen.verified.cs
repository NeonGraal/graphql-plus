//HintName: test_constraint-enum-parent+Dual_Impl.gen.cs
// Generated from constraint-enum-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public class testCnstEnumPrntDual
  : ItestCnstEnumPrntDual
{
  public ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual> AsEnumCnstEnumPrntDualcnstEnumPrntDual { get; set; }
  public ItestCnstEnumPrntDualObject AsCnstEnumPrntDual { get; set; }
}

public class testRefCnstEnumPrntDual<TType>
  : ItestRefCnstEnumPrntDual<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstEnumPrntDualObject AsRefCnstEnumPrntDual { get; set; }
}
