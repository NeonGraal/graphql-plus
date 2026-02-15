//HintName: test_generic-parent-dual+Input_Impl.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public class testGnrcPrntDualInp
  : testRefGnrcPrntDualInp<ItestAltGnrcPrntDualInp>
  , ItestGnrcPrntDualInp
{
}

public class testRefGnrcPrntDualInp<TRef>
  : ItestRefGnrcPrntDualInp<TRef>
{
}

public class testAltGnrcPrntDualInp
  : ItestAltGnrcPrntDualInp
{
  public decimal Alt { get; set; }
}
