//HintName: test_parent-param-same+Dual_Impl.gen.cs
// Generated from parent-param-same+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

public class testPrntParamSameDual<TA>
  : testRefPrntParamSameDual<TA>
  , ItestPrntParamSameDual<TA>
{
  public TA Field { get; set; }
  public ItestPrntParamSameDualObject<TA> AsPrntParamSameDual { get; set; }
}

public class testRefPrntParamSameDual<TA>
  : ItestRefPrntParamSameDual<TA>
{
  public TA Asa { get; set; }
  public ItestRefPrntParamSameDualObject<TA> AsRefPrntParamSameDual { get; set; }
}
