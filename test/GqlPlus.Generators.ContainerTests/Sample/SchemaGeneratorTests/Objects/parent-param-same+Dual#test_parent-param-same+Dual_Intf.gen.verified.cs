//HintName: test_parent-param-same+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

public interface ItestPrntParamSameDual<TA>
  : ItestRefPrntParamSameDual<TA>
{
  ItestPrntParamSameDualObject<TA> AsPrntParamSameDual { get; }
}

public interface ItestPrntParamSameDualObject<TA>
  : ItestRefPrntParamSameDualObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameDual<TA>
  : IGqlpModelImplementationBase
{
  TA Asa { get; }
  ItestRefPrntParamSameDualObject<TA> AsRefPrntParamSameDual { get; }
}

public interface ItestRefPrntParamSameDualObject<TA>
{
}
