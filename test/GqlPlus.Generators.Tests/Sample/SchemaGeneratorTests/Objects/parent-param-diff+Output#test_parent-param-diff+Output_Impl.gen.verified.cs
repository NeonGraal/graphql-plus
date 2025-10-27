//HintName: test_parent-param-diff+Output_Impl.gen.cs
// Generated from parent-param-diff+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public class testPrntParamDiffOutp<Ta>
  : testRefPrntParamDiffOutp
  , ItestPrntParamDiffOutp<Ta>
{
  public Ta field { get; set; }
}

public class testRefPrntParamDiffOutp<Tb>
  : ItestRefPrntParamDiffOutp<Tb>
{
  public Tb Asb { get; set; }
}
