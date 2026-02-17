//HintName: test_generic-parent-param-parent+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public class testGnrcPrntParamPrntDual
  : testRefGnrcPrntParamPrntDual<ItestAltGnrcPrntParamPrntDual>
  , ItestGnrcPrntParamPrntDual
{
}

public class testRefGnrcPrntParamPrntDual<TRef>
  : ItestRefGnrcPrntParamPrntDual<TRef>
{
}

public class testAltGnrcPrntParamPrntDual
  : ItestAltGnrcPrntParamPrntDual
{
  public decimal Alt { get; set; }
}
