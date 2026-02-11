//HintName: test_parent-param-diff+Input_Intf.gen.cs
// Generated from parent-param-diff+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public interface ItestPrntParamDiffInp<Ta>
  : ItestRefPrntParamDiffInp
{
  ItestPrntParamDiffInpObject AsPrntParamDiffInp { get; }
}

public interface ItestPrntParamDiffInpObject<Ta>
  : ItestRefPrntParamDiffInpObject
{
  Ta Field { get; }
}

public interface ItestRefPrntParamDiffInp<Tb>
{
  Tb Asb { get; }
  ItestRefPrntParamDiffInpObject AsRefPrntParamDiffInp { get; }
}

public interface ItestRefPrntParamDiffInpObject<Tb>
{
}
