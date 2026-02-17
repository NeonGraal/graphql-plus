//HintName: test_generic-parent-param+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public class testGnrcPrntParamInp
  : testRefGnrcPrntParamInp<ItestAltGnrcPrntParamInp>
  , ItestGnrcPrntParamInp
{
}

public class testRefGnrcPrntParamInp<TRef>
  : ItestRefGnrcPrntParamInp<TRef>
{
}

public class testAltGnrcPrntParamInp
  : ItestAltGnrcPrntParamInp
{
  public decimal Alt { get; set; }
}
