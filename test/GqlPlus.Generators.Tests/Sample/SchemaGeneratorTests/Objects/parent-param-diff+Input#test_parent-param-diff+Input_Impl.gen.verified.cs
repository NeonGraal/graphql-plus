//HintName: test_parent-param-diff+Input_Impl.gen.cs
// Generated from parent-param-diff+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public class InputtestPrntParamDiffInp<Ta>
  : InputtestRefPrntParamDiffInp
  , ItestPrntParamDiffInp<Ta>
{
  public Ta field { get; set; }
}

public class InputtestRefPrntParamDiffInp<Tb>
  : ItestRefPrntParamDiffInp<Tb>
{
  public Tb Asb { get; set; }
}
