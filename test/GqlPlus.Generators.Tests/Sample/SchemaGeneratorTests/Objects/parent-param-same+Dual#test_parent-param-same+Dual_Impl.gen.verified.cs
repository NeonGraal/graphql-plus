//HintName: test_parent-param-same+Dual_Impl.gen.cs
// Generated from parent-param-same+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

public class DualtestPrntParamSameDual<Ta>
  : DualtestRefPrntParamSameDual
  , ItestPrntParamSameDual<Ta>
{
  public Ta field { get; set; }
}

public class DualtestRefPrntParamSameDual<Ta>
  : ItestRefPrntParamSameDual<Ta>
{
  public Ta Asa { get; set; }
}
