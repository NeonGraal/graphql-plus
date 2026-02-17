//HintName: test_generic-parent-dual+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public class testGnrcPrntDualDual
  : testRefGnrcPrntDualDual<ItestAltGnrcPrntDualDual>
  , ItestGnrcPrntDualDual
{
}

public class testRefGnrcPrntDualDual<TRef>
  : ItestRefGnrcPrntDualDual<TRef>
{
}

public class testAltGnrcPrntDualDual
  : ItestAltGnrcPrntDualDual
{
  public decimal Alt { get; set; }
}
