//HintName: test_parent-param-diff+Output_Intf.gen.cs
// Generated from parent-param-diff+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public interface ItestPrntParamDiffOutp<Ta>
  : ItestRefPrntParamDiffOutp
{
  ItestPrntParamDiffOutpObject AsPrntParamDiffOutp { get; }
}

public interface ItestPrntParamDiffOutpObject<Ta>
  : ItestRefPrntParamDiffOutpObject
{
  Ta Field { get; }
}

public interface ItestRefPrntParamDiffOutp<Tb>
{
  Tb Asb { get; }
  ItestRefPrntParamDiffOutpObject AsRefPrntParamDiffOutp { get; }
}

public interface ItestRefPrntParamDiffOutpObject<Tb>
{
}
