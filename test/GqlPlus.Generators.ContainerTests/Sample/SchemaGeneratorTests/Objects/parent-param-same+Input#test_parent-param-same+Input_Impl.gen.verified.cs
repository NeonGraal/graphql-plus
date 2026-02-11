//HintName: test_parent-param-same+Input_Impl.gen.cs
// Generated from parent-param-same+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

public class testPrntParamSameInp<TA>
  : testRefPrntParamSameInp<TA>
  , ItestPrntParamSameInp<TA>
{
  public TA Field { get; set; }
  public ItestPrntParamSameInpObject AsPrntParamSameInp { get; set; }
}

public class testRefPrntParamSameInp<TA>
  : ItestRefPrntParamSameInp<TA>
{
  public TA Asa { get; set; }
  public ItestRefPrntParamSameInpObject AsRefPrntParamSameInp { get; set; }
}
