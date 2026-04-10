//HintName: test_parent-param-same+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Output;

public interface ItestPrntParamSameOutp<TA>
  : ItestRefPrntParamSameOutp<TA>
{
  ItestPrntParamSameOutpObject<TA>? As_PrntParamSameOutp { get; }
}

public interface ItestPrntParamSameOutpObject<TA>
  : ItestRefPrntParamSameOutpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameOutp<TA>
  : IGqlpInterfaceBase
{
  TA? Asa { get; }
  ItestRefPrntParamSameOutpObject<TA>? As_RefPrntParamSameOutp { get; }
}

public interface ItestRefPrntParamSameOutpObject<TA>
  : IGqlpInterfaceBase
{
}
