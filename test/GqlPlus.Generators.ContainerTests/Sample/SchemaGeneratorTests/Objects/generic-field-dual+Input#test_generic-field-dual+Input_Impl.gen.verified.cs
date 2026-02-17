//HintName: test_generic-field-dual+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public class testGnrcFieldDualInp
  : ItestGnrcFieldDualInp
{
  public ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; set; }
}

public class testRefGnrcFieldDualInp<TRef>
  : ItestRefGnrcFieldDualInp<TRef>
{
}

public class testAltGnrcFieldDualInp
  : ItestAltGnrcFieldDualInp
{
  public decimal Alt { get; set; }
}
