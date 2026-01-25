//HintName: test_parent-param-diff+Output_Intf.gen.cs
// Generated from parent-param-diff+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public interface ItestPrntParamDiffOutp<Ta>
  : ItestRefPrntParamDiffOutp
{
  public testPrntParamDiffOutp PrntParamDiffOutp { get; set; }
}

public interface ItestPrntParamDiffOutpObject<Ta>
  : ItestRefPrntParamDiffOutpObject
{
  public Ta field { get; set; }
}

public interface ItestRefPrntParamDiffOutp<Tb>
{
  public Tb Asb { get; set; }
  public testRefPrntParamDiffOutp RefPrntParamDiffOutp { get; set; }
}

public interface ItestRefPrntParamDiffOutpObject<Tb>
{
}
