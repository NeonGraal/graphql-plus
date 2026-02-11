//HintName: test_parent-param-same+Output_Intf.gen.cs
// Generated from parent-param-same+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Output;

public interface ItestPrntParamSameOutp<TA>
  : ItestRefPrntParamSameOutp<TA>
{
  ItestPrntParamSameOutpObject AsPrntParamSameOutp { get; }
}

public interface ItestPrntParamSameOutpObject<TA>
  : ItestRefPrntParamSameOutpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameOutp<TA>
{
  TA Asa { get; }
  ItestRefPrntParamSameOutpObject AsRefPrntParamSameOutp { get; }
}

public interface ItestRefPrntParamSameOutpObject<TA>
{
}
