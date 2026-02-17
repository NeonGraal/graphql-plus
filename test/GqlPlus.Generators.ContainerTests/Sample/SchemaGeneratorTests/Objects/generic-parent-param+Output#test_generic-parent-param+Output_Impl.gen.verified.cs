//HintName: test_generic-parent-param+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public class testGnrcPrntParamOutp
  : testRefGnrcPrntParamOutp<ItestAltGnrcPrntParamOutp>
  , ItestGnrcPrntParamOutp
{
}

public class testRefGnrcPrntParamOutp<TRef>
  : ItestRefGnrcPrntParamOutp<TRef>
{
}

public class testAltGnrcPrntParamOutp
  : ItestAltGnrcPrntParamOutp
{
  public decimal Alt { get; set; }
}
