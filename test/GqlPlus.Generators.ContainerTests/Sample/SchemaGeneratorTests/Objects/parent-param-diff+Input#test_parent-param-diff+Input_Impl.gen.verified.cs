//HintName: test_parent-param-diff+Input_Impl.gen.cs
// Generated from parent-param-diff+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public class testPrntParamDiffInp<TA>
  : testRefPrntParamDiffInp<TA>
  , ItestPrntParamDiffInp<TA>
{
  public TA Field { get; set; }
  public ItestPrntParamDiffInpObject AsPrntParamDiffInp { get; set; }
}

public class testRefPrntParamDiffInp<TB>
  : ItestRefPrntParamDiffInp<TB>
{
  public TB Asb { get; set; }
  public ItestRefPrntParamDiffInpObject AsRefPrntParamDiffInp { get; set; }
}
