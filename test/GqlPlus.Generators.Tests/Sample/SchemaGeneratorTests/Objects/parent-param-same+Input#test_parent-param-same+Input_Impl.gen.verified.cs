//HintName: test_parent-param-same+Input_Impl.gen.cs
// Generated from parent-param-same+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

public class testPrntParamSameInp<Ta>
  : testRefPrntParamSameInp
  , ItestPrntParamSameInp<Ta>
{
  public Ta field { get; set; }
  public testPrntParamSameInp PrntParamSameInp { get; set; }
}

public class testRefPrntParamSameInp<Ta>
  : ItestRefPrntParamSameInp<Ta>
{
  public Ta Asa { get; set; }
  public testRefPrntParamSameInp RefPrntParamSameInp { get; set; }
}
