//HintName: test_generic-parent-dual-parent+Input_Intf.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public interface ItestGnrcPrntDualPrntInp
  : ItestRefGnrcPrntDualPrntInp
{
  public ItestGnrcPrntDualPrntInpObject AsGnrcPrntDualPrntInp { get; set; }
}

public interface ItestGnrcPrntDualPrntInpObject
  : ItestRefGnrcPrntDualPrntInpObject
{
}

public interface ItestRefGnrcPrntDualPrntInp<Tref>
  : Itestref
{
  public ItestRefGnrcPrntDualPrntInpObject AsRefGnrcPrntDualPrntInp { get; set; }
}

public interface ItestRefGnrcPrntDualPrntInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntDualPrntInp
{
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualPrntInpObject AsAltGnrcPrntDualPrntInp { get; set; }
}

public interface ItestAltGnrcPrntDualPrntInpObject
{
  public decimal Alt { get; set; }
}
