//HintName: Gqlp_parent-param-same+Dual_Impl.gen.cs
// Generated from parent-param-same+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_param_same_Dual;
public class DualPrntParamSameDual<Ta>
  : DualRefPrntParamSameDual
  , IPrntParamSameDual<Ta>
{
  public Ta field { get; set; }
}
public class DualRefPrntParamSameDual<Ta>
  : IRefPrntParamSameDual<Ta>
{
  public Ta Asa { get; set; }
}
