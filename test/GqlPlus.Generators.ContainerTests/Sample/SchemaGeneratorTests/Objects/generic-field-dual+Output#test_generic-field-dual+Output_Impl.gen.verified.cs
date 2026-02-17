//HintName: test_generic-field-dual+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public class testGnrcFieldDualOutp
  : ItestGnrcFieldDualOutp
{
  public ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; set; }
}

public class testRefGnrcFieldDualOutp<TRef>
  : ItestRefGnrcFieldDualOutp<TRef>
{
}

public class testAltGnrcFieldDualOutp
  : ItestAltGnrcFieldDualOutp
{
  public decimal Alt { get; set; }
}
