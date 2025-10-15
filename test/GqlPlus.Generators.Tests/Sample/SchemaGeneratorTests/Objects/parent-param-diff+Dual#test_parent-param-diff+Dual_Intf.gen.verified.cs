//HintName: test_parent-param-diff+Dual_Intf.gen.cs
// Generated from parent-param-diff+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

public interface ItestPrntParamDiffDual<Ta>
  : ItestRefPrntParamDiffDual
{
  Ta field { get; }
}

public interface ItestRefPrntParamDiffDual<Tb>
{
  Tb Asb { get; }
}
