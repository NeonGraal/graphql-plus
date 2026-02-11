//HintName: test_parent-param-same+Output_Intf.gen.cs
// Generated from parent-param-same+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Output;

public interface ItestPrntParamSameOutp<Ta>
  : ItestRefPrntParamSameOutp
{
  ItestPrntParamSameOutpObject AsPrntParamSameOutp { get; }
}

public interface ItestPrntParamSameOutpObject<Ta>
  : ItestRefPrntParamSameOutpObject
{
  Ta Field { get; }
}

public interface ItestRefPrntParamSameOutp<Ta>
{
  Ta Asa { get; }
  ItestRefPrntParamSameOutpObject AsRefPrntParamSameOutp { get; }
}

public interface ItestRefPrntParamSameOutpObject<Ta>
{
}
