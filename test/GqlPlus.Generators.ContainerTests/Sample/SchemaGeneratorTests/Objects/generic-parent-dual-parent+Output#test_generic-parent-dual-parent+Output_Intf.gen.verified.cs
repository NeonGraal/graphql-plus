//HintName: test_generic-parent-dual-parent+Output_Intf.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public interface ItestGnrcPrntDualPrntOutp
  : ItestRefGnrcPrntDualPrntOutp
{
  public ItestGnrcPrntDualPrntOutpObject AsGnrcPrntDualPrntOutp { get; set; }
}

public interface ItestGnrcPrntDualPrntOutpObject
  : ItestRefGnrcPrntDualPrntOutpObject
{
}

public interface ItestRefGnrcPrntDualPrntOutp<Tref>
  : Itestref
{
  public ItestRefGnrcPrntDualPrntOutpObject AsRefGnrcPrntDualPrntOutp { get; set; }
}

public interface ItestRefGnrcPrntDualPrntOutpObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntDualPrntOutp
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcPrntDualPrntOutpObject AsAltGnrcPrntDualPrntOutp { get; set; }
}

public interface ItestAltGnrcPrntDualPrntOutpObject
{
  public ItestNumber Alt { get; set; }
}
