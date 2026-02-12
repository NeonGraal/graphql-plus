//HintName: test_parent-param-diff+Output_Intf.gen.cs
// Generated from parent-param-diff+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public interface ItestPrntParamDiffOutp<TA>
  : ItestRefPrntParamDiffOutp<TA>
{
  ItestPrntParamDiffOutpObject<TA> AsPrntParamDiffOutp { get; }
}

public interface ItestPrntParamDiffOutpObject<TA>
  : ItestRefPrntParamDiffOutpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffOutp<TB>
{
  TB Asb { get; }
  ItestRefPrntParamDiffOutpObject<TB> AsRefPrntParamDiffOutp { get; }
}

public interface ItestRefPrntParamDiffOutpObject<TB>
{
}
