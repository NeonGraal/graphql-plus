//HintName: test_parent-param-diff+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public interface ItestPrntParamDiffOutp<TA>
  : ItestRefPrntParamDiffOutp<TA>
{
  ItestPrntParamDiffOutpObject<TA>? As_PrntParamDiffOutp { get; }
}

public interface ItestPrntParamDiffOutpObject<TA>
  : ItestRefPrntParamDiffOutpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffOutp<TB>
  : IGqlpInterfaceBase
{
  TB? Asb { get; }
  ItestRefPrntParamDiffOutpObject<TB>? As_RefPrntParamDiffOutp { get; }
}

public interface ItestRefPrntParamDiffOutpObject<TB>
  : IGqlpInterfaceBase
{
}
