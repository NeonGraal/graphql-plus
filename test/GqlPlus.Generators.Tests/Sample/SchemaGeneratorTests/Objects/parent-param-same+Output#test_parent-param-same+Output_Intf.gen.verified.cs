//HintName: test_parent-param-same+Output_Intf.gen.cs
// Generated from parent-param-same+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Output;

public interface ItestPrntParamSameOutp<Ta>
  : ItestRefPrntParamSameOutp
{
  public testPrntParamSameOutp PrntParamSameOutp { get; set; }
}

public interface ItestPrntParamSameOutpField<Ta>
  : ItestRefPrntParamSameOutpField
{
  public Ta field { get; set; }
}

public interface ItestRefPrntParamSameOutp<Ta>
{
  public Ta Asa { get; set; }
  public testRefPrntParamSameOutp RefPrntParamSameOutp { get; set; }
}

public interface ItestRefPrntParamSameOutpField<Ta>
{
}
