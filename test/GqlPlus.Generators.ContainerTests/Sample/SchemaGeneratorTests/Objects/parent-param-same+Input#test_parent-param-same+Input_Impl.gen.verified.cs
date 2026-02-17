//HintName: test_parent-param-same+Input_Impl.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

public class testPrntParamSameInp<TA>
  : testRefPrntParamSameInp<TA>
  , ItestPrntParamSameInp<TA>
{
  public TA Field { get; set; }
}

public class testRefPrntParamSameInp<TA>
  : ItestRefPrntParamSameInp<TA>
{
}
