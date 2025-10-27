//HintName: test_parent-param-same+Output_Impl.gen.cs
// Generated from parent-param-same+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Output;

public class testPrntParamSameOutp<Ta>
  : testRefPrntParamSameOutp
  , ItestPrntParamSameOutp<Ta>
{
  public Ta field { get; set; }
}

public class testRefPrntParamSameOutp<Ta>
  : ItestRefPrntParamSameOutp<Ta>
{
  public Ta Asa { get; set; }
}
