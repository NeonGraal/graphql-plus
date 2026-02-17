//HintName: test_generic-field-param+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public class testGnrcFieldParamInp
  : ItestGnrcFieldParamInp
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }
}

public class testRefGnrcFieldParamInp<TRef>
  : ItestRefGnrcFieldParamInp<TRef>
{
}

public class testAltGnrcFieldParamInp
  : ItestAltGnrcFieldParamInp
{
  public decimal Alt { get; set; }
}
