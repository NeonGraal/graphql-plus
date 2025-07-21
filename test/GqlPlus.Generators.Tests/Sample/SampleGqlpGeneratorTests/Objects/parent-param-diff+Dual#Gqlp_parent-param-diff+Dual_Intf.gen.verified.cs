//HintName: Gqlp_parent-param-diff+Dual_Intf.gen.cs
// Generated from parent-param-diff+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_param_diff_Dual;

public interface IPrntParamDiffDual<Ta>
  : IRefPrntParamDiffDual
{
  Ta field { get; }
}

public interface IRefPrntParamDiffDual<Tb>
{
  Tb Asb { get; }
}
