//HintName: test_generic-alt-param+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public class testGnrcAltParamInp
  : ItestGnrcAltParamInp
{
}

public class testRefGnrcAltParamInp<TRef>
  : ItestRefGnrcAltParamInp<TRef>
{
}

public class testAltGnrcAltParamInp
  : ItestAltGnrcAltParamInp
{
  public decimal Alt { get; set; }
}
