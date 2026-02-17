//HintName: test_parent-param-diff+Input_Impl.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

public class testPrntParamDiffInp<TA>
  : testRefPrntParamDiffInp<TA>
  , ItestPrntParamDiffInp<TA>
{
  public TA Field { get; set; }
}

public class testRefPrntParamDiffInp<TB>
  : ItestRefPrntParamDiffInp<TB>
{
}
