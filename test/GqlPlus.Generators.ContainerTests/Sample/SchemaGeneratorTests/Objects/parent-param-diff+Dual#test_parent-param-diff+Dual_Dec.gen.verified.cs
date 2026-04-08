//HintName: test_parent-param-diff+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

public interface ItestPrntParamDiffDual<TA>
  : ItestRefPrntParamDiffDual<TA>
{
  ItestPrntParamDiffDualObject<TA>? As_PrntParamDiffDual { get; }
}

public interface ItestPrntParamDiffDualObject<TA>
  : ItestRefPrntParamDiffDualObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffDual<TB>
  // No Base because it's Class
{
  TB? Asb { get; }
  ItestRefPrntParamDiffDualObject<TB>? As_RefPrntParamDiffDual { get; }
}

public interface ItestRefPrntParamDiffDualObject<TB>
  // No Base because it's Class
{
}
