//HintName: test_parent-param-same+Dual_Impl.gen.cs
// Generated from parent-param-same+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

public class testPrntParamSameDual<Ta>
  : testRefPrntParamSameDual
  , ItestPrntParamSameDual<Ta>
{
  public Ta field { get; set; }
  public testPrntParamSameDual PrntParamSameDual { get; set; }
}

public class testRefPrntParamSameDual<Ta>
  : ItestRefPrntParamSameDual<Ta>
{
  public Ta Asa { get; set; }
  public testRefPrntParamSameDual RefPrntParamSameDual { get; set; }
}
