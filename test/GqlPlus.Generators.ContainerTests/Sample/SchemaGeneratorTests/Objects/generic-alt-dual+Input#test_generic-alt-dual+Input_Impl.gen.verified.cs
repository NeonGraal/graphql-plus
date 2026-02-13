//HintName: test_generic-alt-dual+Input_Impl.gen.cs
// Generated from generic-alt-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public class testGnrcAltDualInp
  : ItestGnrcAltDualInp
{
  public ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp> AsRefGnrcAltDualInp { get; set; }
  public ItestGnrcAltDualInpObject AsGnrcAltDualInp { get; set; }
}

public class testRefGnrcAltDualInp<TRef>
  : ItestRefGnrcAltDualInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltDualInpObject<TRef> AsRefGnrcAltDualInp { get; set; }
}

public class testAltGnrcAltDualInp
  : ItestAltGnrcAltDualInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltDualInpObject AsAltGnrcAltDualInp { get; set; }
}
