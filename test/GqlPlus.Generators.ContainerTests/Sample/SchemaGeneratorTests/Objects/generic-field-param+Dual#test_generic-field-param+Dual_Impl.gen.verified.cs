//HintName: test_generic-field-param+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public class testGnrcFieldParamDual
  : ItestGnrcFieldParamDual
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }
}

public class testRefGnrcFieldParamDual<TRef>
  : ItestRefGnrcFieldParamDual<TRef>
{
}

public class testAltGnrcFieldParamDual
  : ItestAltGnrcFieldParamDual
{
  public decimal Alt { get; set; }
}
