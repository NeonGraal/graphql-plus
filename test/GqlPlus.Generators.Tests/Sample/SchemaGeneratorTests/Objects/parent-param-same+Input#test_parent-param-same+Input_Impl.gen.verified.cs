//HintName: test_parent-param-same+Input_Impl.gen.cs
// Generated from parent-param-same+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

public class InputtestPrntParamSameInp<Ta>
  : InputtestRefPrntParamSameInp
  , ItestPrntParamSameInp<Ta>
{
  public Ta field { get; set; }
}

public class InputtestRefPrntParamSameInp<Ta>
  : ItestRefPrntParamSameInp<Ta>
{
  public Ta Asa { get; set; }
}
