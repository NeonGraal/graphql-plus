//HintName: Gqlp_parent-param-diff+Dual_Impl.gen.cs
// Generated from parent-param-diff+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_param_diff_Dual;
public class DualPrntParamDiffDual<Ta>
  : DualRefPrntParamDiffDual
  , IPrntParamDiffDual<Ta>
{
  public Ta field { get; set; }
}
public class DualRefPrntParamDiffDual<Tb>
  : IRefPrntParamDiffDual<Tb>
{
  public Tb Asb { get; set; }
}
