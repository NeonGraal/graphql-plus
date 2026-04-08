//HintName: test_parent-param-diff+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public interface ItestPrntParamDiffOutp<TA>
  : ItestRefPrntParamDiffOutp<TA>
{
  ItestPrntParamDiffOutpObject<TA>? As_PrntParamDiffOutp { get; }
}

public interface ItestPrntParamDiffOutpObject<TA>
  : ItestRefPrntParamDiffOutpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffOutp<TB>
  // No Base because it's Class
{
  TB? Asb { get; }
  ItestRefPrntParamDiffOutpObject<TB>? As_RefPrntParamDiffOutp { get; }
}

public interface ItestRefPrntParamDiffOutpObject<TB>
  // No Base because it's Class
{
}
