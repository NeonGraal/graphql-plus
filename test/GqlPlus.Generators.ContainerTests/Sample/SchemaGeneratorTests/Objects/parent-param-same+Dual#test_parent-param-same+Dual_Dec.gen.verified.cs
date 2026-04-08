//HintName: test_parent-param-same+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

public interface ItestPrntParamSameDual<TA>
  : ItestRefPrntParamSameDual<TA>
{
  ItestPrntParamSameDualObject<TA>? As_PrntParamSameDual { get; }
}

public interface ItestPrntParamSameDualObject<TA>
  : ItestRefPrntParamSameDualObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameDual<TA>
  // No Base because it's Class
{
  TA? Asa { get; }
  ItestRefPrntParamSameDualObject<TA>? As_RefPrntParamSameDual { get; }
}

public interface ItestRefPrntParamSameDualObject<TA>
  // No Base because it's Class
{
}
