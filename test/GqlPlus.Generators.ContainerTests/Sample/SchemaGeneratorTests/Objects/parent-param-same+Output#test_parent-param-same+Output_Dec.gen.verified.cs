//HintName: test_parent-param-same+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Output;

public interface ItestPrntParamSameOutp<TA>
  : ItestRefPrntParamSameOutp<TA>
{
  ItestPrntParamSameOutpObject<TA>? As_PrntParamSameOutp { get; }
}

public interface ItestPrntParamSameOutpObject<TA>
  : ItestRefPrntParamSameOutpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameOutp<TA>
  // No Base because it's Class
{
  TA? Asa { get; }
  ItestRefPrntParamSameOutpObject<TA>? As_RefPrntParamSameOutp { get; }
}

public interface ItestRefPrntParamSameOutpObject<TA>
  // No Base because it's Class
{
}
