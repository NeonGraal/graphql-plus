//HintName: test_generic-parent-dual+Input_Intf.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public interface ItestGnrcPrntDualInp
  : ItestRefGnrcPrntDualInp
{
  public ItestGnrcPrntDualInpObject AsGnrcPrntDualInp { get; set; }
}

public interface ItestGnrcPrntDualInpObject
  : ItestRefGnrcPrntDualInpObject
{
}

public interface ItestRefGnrcPrntDualInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcPrntDualInpObject AsRefGnrcPrntDualInp { get; set; }
}

public interface ItestRefGnrcPrntDualInpObject<Tref>
{
}

public interface ItestAltGnrcPrntDualInp
{
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualInpObject AsAltGnrcPrntDualInp { get; set; }
}

public interface ItestAltGnrcPrntDualInpObject
{
  public decimal Alt { get; set; }
}
