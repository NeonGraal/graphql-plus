//HintName: test_generic-parent-param+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public class testGnrcPrntParamDual
  : testRefGnrcPrntParamDual<ItestAltGnrcPrntParamDual>
  , ItestGnrcPrntParamDual
{
}

public class testRefGnrcPrntParamDual<TRef>
  : ItestRefGnrcPrntParamDual<TRef>
{
}

public class testAltGnrcPrntParamDual
  : ItestAltGnrcPrntParamDual
{
  public decimal Alt { get; set; }
}
