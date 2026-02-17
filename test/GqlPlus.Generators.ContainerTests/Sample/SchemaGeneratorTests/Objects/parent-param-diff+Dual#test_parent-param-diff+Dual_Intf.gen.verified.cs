//HintName: test_parent-param-diff+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

public interface ItestPrntParamDiffDual<TA>
  : ItestRefPrntParamDiffDual<TA>
{
  ItestPrntParamDiffDualObject<TA> AsPrntParamDiffDual { get; }
}

public interface ItestPrntParamDiffDualObject<TA>
  : ItestRefPrntParamDiffDualObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffDual<TB>
  : IGqlpModelImplementationBase
{
  TB Asb { get; }
  ItestRefPrntParamDiffDualObject<TB> AsRefPrntParamDiffDual { get; }
}

public interface ItestRefPrntParamDiffDualObject<TB>
{
}
