//HintName: test_parent-param-same+Output_Impl.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Output;

public class testPrntParamSameOutp<TA>
  : testRefPrntParamSameOutp<TA>
  , ItestPrntParamSameOutp<TA>
{
  public TA Field { get; set; }
}

public class testRefPrntParamSameOutp<TA>
  : ItestRefPrntParamSameOutp<TA>
{
}
