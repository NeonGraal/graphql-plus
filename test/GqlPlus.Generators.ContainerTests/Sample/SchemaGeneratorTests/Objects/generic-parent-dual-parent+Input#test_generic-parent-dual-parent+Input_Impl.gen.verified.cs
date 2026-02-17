//HintName: test_generic-parent-dual-parent+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public class testGnrcPrntDualPrntInp
  : testRefGnrcPrntDualPrntInp<ItestAltGnrcPrntDualPrntInp>
  , ItestGnrcPrntDualPrntInp
{
}

public class testRefGnrcPrntDualPrntInp<TRef>
  : ItestRefGnrcPrntDualPrntInp<TRef>
{
}

public class testAltGnrcPrntDualPrntInp
  : ItestAltGnrcPrntDualPrntInp
{
  public decimal Alt { get; set; }
}
