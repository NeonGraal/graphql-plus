//HintName: test_parent-param-diff+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

public class testPrntParamDiffDual<TA>
  : testRefPrntParamDiffDual<TA>
  , ItestPrntParamDiffDual<TA>
{
  public TA Field { get; set; }
}

public class testRefPrntParamDiffDual<TB>
  : ItestRefPrntParamDiffDual<TB>
{
}
