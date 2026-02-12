//HintName: test_generic-parent-dual+Input_Impl.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public class testGnrcPrntDualInp
  : testRefGnrcPrntDualInp<ItestAltGnrcPrntDualInp>
  , ItestGnrcPrntDualInp
{
  public ItestGnrcPrntDualInpObject AsGnrcPrntDualInp { get; set; }
}

public class testRefGnrcPrntDualInp<TRef>
  : ItestRefGnrcPrntDualInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntDualInpObject<TRef> AsRefGnrcPrntDualInp { get; set; }
}

public class testAltGnrcPrntDualInp
  : ItestAltGnrcPrntDualInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualInpObject AsAltGnrcPrntDualInp { get; set; }
}
