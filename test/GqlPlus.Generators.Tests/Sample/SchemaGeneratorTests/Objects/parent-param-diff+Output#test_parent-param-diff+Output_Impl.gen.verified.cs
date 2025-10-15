//HintName: test_parent-param-diff+Output_Impl.gen.cs
// Generated from parent-param-diff+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public class OutputtestPrntParamDiffOutp<Ta>
  : OutputtestRefPrntParamDiffOutp
  , ItestPrntParamDiffOutp<Ta>
{
  public Ta field { get; set; }
}

public class OutputtestRefPrntParamDiffOutp<Tb>
  : ItestRefPrntParamDiffOutp<Tb>
{
  public Tb Asb { get; set; }
}
