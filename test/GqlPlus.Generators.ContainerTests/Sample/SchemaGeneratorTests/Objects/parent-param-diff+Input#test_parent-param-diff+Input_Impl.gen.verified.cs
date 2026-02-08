//HintName: test_parent-param-diff+Input_Impl.gen.cs
// Generated from parent-param-diff+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public class testPrntParamDiffInp<Ta>
  : testRefPrntParamDiffInp
  , ItestPrntParamDiffInp<Ta>
{
  public Ta Field { get; set; }
}

public class testRefPrntParamDiffInp<Tb>
  : ItestRefPrntParamDiffInp<Tb>
{
  public Tb Asb { get; set; }
}
