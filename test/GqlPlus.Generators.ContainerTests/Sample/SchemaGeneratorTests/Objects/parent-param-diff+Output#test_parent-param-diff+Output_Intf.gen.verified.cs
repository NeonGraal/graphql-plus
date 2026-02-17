//HintName: test_parent-param-diff+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

public interface ItestPrntParamDiffOutp<TA>
  : ItestRefPrntParamDiffOutp<TA>
{
  ItestPrntParamDiffOutpObject<TA> AsPrntParamDiffOutp { get; }
}

public interface ItestPrntParamDiffOutpObject<TA>
  : ItestRefPrntParamDiffOutpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffOutp<TB>
  : IGqlpModelImplementationBase
{
  TB Asb { get; }
  ItestRefPrntParamDiffOutpObject<TB> AsRefPrntParamDiffOutp { get; }
}

public interface ItestRefPrntParamDiffOutpObject<TB>
{
}
