//HintName: test_parent-param-diff+Input_Intf.gen.cs
// Generated from parent-param-diff+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public interface ItestPrntParamDiffInp<Ta>
  : ItestRefPrntParamDiffInp
{
  Ta field { get; }
}

public interface ItestRefPrntParamDiffInp<Tb>
{
  Tb Asb { get; }
}
