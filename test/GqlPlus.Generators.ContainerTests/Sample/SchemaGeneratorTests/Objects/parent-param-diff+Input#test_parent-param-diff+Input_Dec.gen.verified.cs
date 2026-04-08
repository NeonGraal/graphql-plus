//HintName: test_parent-param-diff+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public interface ItestPrntParamDiffInp<TA>
  : ItestRefPrntParamDiffInp<TA>
{
  ItestPrntParamDiffInpObject<TA>? As_PrntParamDiffInp { get; }
}

public interface ItestPrntParamDiffInpObject<TA>
  : ItestRefPrntParamDiffInpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffInp<TB>
  // No Base because it's Class
{
  TB? Asb { get; }
  ItestRefPrntParamDiffInpObject<TB>? As_RefPrntParamDiffInp { get; }
}

public interface ItestRefPrntParamDiffInpObject<TB>
  // No Base because it's Class
{
}
