//HintName: test_parent-param-diff+Dual_Impl.gen.cs
// Generated from parent-param-diff+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

public class testPrntParamDiffDual<TA>
  : testRefPrntParamDiffDual<TA>
  , ItestPrntParamDiffDual<TA>
{
  public TA Field { get; set; }
}

public class testRefPrntParamDiffDual<TB>
  : ItestRefPrntParamDiffDual<TB>
{
}
