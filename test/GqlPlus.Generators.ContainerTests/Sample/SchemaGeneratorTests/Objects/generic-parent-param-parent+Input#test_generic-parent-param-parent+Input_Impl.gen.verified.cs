//HintName: test_generic-parent-param-parent+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public class testGnrcPrntParamPrntInp
  : testRefGnrcPrntParamPrntInp<ItestAltGnrcPrntParamPrntInp>
  , ItestGnrcPrntParamPrntInp
{
}

public class testRefGnrcPrntParamPrntInp<TRef>
  : ItestRefGnrcPrntParamPrntInp<TRef>
{
}

public class testAltGnrcPrntParamPrntInp
  : ItestAltGnrcPrntParamPrntInp
{
  public decimal Alt { get; set; }
}
