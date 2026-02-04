//HintName: test_parent-param-diff+Dual_Impl.gen.cs
// Generated from parent-param-diff+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

public class testPrntParamDiffDual<Ta>
  : testRefPrntParamDiffDual
  , ItestPrntParamDiffDual<Ta>
{
  public Ta field { get; set; }
  public testPrntParamDiffDual PrntParamDiffDual { get; set; }
}

public class testRefPrntParamDiffDual<Tb>
  : ItestRefPrntParamDiffDual<Tb>
{
  public Tb Asb { get; set; }
  public testRefPrntParamDiffDual RefPrntParamDiffDual { get; set; }
}
