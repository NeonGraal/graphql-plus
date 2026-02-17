//HintName: test_generic-field-dual+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public class testGnrcFieldDualDual
  : ItestGnrcFieldDualDual
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; set; }
}

public class testRefGnrcFieldDualDual<TRef>
  : ItestRefGnrcFieldDualDual<TRef>
{
}

public class testAltGnrcFieldDualDual
  : ItestAltGnrcFieldDualDual
{
  public decimal Alt { get; set; }
}
