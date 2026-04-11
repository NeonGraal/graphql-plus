//HintName: test_parent-param-same+Input_Intf.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

public interface ItestPrntParamSameInp<TA>
  : ItestRefPrntParamSameInp<TA>
{
  ItestPrntParamSameInpObject<TA>? As_PrntParamSameInp { get; }
}

public interface ItestPrntParamSameInpObject<TA>
  : ItestRefPrntParamSameInpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameInp<TA>
  : IGqlpInterfaceBase
{
  TA? Asa { get; }
  ItestRefPrntParamSameInpObject<TA>? As_RefPrntParamSameInp { get; }
}

public interface ItestRefPrntParamSameInpObject<TA>
  : IGqlpInterfaceBase
{
}
