//HintName: test_parent-param-diff+Output_Intf.gen.cs
// Generated from parent-param-diff+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public interface ItestPrntParamDiffOutp<Ta>
  : ItestRefPrntParamDiffOutp
{
}

public interface ItestPrntParamDiffOutpObject<Ta>
  : ItestRefPrntParamDiffOutpObject
{
  public Ta Field { get; set; }
}

public interface ItestRefPrntParamDiffOutp<Tb>
{
  public Tb Asb { get; set; }
}

public interface ItestRefPrntParamDiffOutpObject<Tb>
{
}
