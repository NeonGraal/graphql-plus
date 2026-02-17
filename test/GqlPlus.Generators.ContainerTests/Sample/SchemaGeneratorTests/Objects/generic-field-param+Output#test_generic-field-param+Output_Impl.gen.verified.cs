//HintName: test_generic-field-param+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public class testGnrcFieldParamOutp
  : ItestGnrcFieldParamOutp
{
  public ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; set; }
}

public class testRefGnrcFieldParamOutp<TRef>
  : ItestRefGnrcFieldParamOutp<TRef>
{
}

public class testAltGnrcFieldParamOutp
  : ItestAltGnrcFieldParamOutp
{
  public decimal Alt { get; set; }
}
