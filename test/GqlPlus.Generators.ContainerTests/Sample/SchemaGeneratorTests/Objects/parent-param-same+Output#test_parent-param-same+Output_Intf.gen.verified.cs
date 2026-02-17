//HintName: test_parent-param-same+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Output;

public interface ItestPrntParamSameOutp<TA>
  : ItestRefPrntParamSameOutp<TA>
{
  ItestPrntParamSameOutpObject<TA> AsPrntParamSameOutp { get; }
}

public interface ItestPrntParamSameOutpObject<TA>
  : ItestRefPrntParamSameOutpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameOutp<TA>
  : IGqlpModelImplementationBase
{
  TA Asa { get; }
  ItestRefPrntParamSameOutpObject<TA> AsRefPrntParamSameOutp { get; }
}

public interface ItestRefPrntParamSameOutpObject<TA>
{
}
