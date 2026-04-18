//HintName: test_parent-param-same+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  : IGqlpInterfaceBase
{
  TA? Asa { get; }
  ItestRefPrntParamSameDualObject<TA>? As_RefPrntParamSameDual { get; }
}

public interface ItestRefPrntParamSameDualObject<TA>
  : IGqlpInterfaceBase
{
}
