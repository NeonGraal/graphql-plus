//HintName: test_parent-param-same+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

public class testPrntParamSameDual<TA>
  : testRefPrntParamSameDual<TA>
  , ItestPrntParamSameDual<TA>
{
  public TA Field { get; set; }
}

public class testRefPrntParamSameDual<TA>
  : ItestRefPrntParamSameDual<TA>
{
}
