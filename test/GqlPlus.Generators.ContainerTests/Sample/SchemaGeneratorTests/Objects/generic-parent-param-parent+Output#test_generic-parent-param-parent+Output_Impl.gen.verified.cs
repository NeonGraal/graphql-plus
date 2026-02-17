//HintName: test_generic-parent-param-parent+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public class testGnrcPrntParamPrntOutp
  : testRefGnrcPrntParamPrntOutp<ItestAltGnrcPrntParamPrntOutp>
  , ItestGnrcPrntParamPrntOutp
{
}

public class testRefGnrcPrntParamPrntOutp<TRef>
  : ItestRefGnrcPrntParamPrntOutp<TRef>
{
}

public class testAltGnrcPrntParamPrntOutp
  : ItestAltGnrcPrntParamPrntOutp
{
  public decimal Alt { get; set; }
}
