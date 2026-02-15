//HintName: test_parent-param-diff+Output_Impl.gen.cs
// Generated from parent-param-diff+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public class testPrntParamDiffOutp<TA>
  : testRefPrntParamDiffOutp<TA>
  , ItestPrntParamDiffOutp<TA>
{
  public TA Field { get; set; }
}

public class testRefPrntParamDiffOutp<TB>
  : ItestRefPrntParamDiffOutp<TB>
{
}
