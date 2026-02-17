//HintName: test_parent-param-same+Input_Intf.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

public interface ItestPrntParamSameInp<TA>
  : ItestRefPrntParamSameInp<TA>
{
  ItestPrntParamSameInpObject<TA> AsPrntParamSameInp { get; }
}

public interface ItestPrntParamSameInpObject<TA>
  : ItestRefPrntParamSameInpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameInp<TA>
  : IGqlpModelImplementationBase
{
  TA Asa { get; }
  ItestRefPrntParamSameInpObject<TA> AsRefPrntParamSameInp { get; }
}

public interface ItestRefPrntParamSameInpObject<TA>
{
}
