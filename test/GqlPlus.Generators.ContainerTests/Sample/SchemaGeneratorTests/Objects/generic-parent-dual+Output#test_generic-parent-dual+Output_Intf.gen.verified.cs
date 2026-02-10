//HintName: test_generic-parent-dual+Output_Intf.gen.cs
// Generated from generic-parent-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public interface ItestGnrcPrntDualOutp
  : ItestRefGnrcPrntDualOutp
{
  public ItestGnrcPrntDualOutpObject AsGnrcPrntDualOutp { get; set; }
}

public interface ItestGnrcPrntDualOutpObject
  : ItestRefGnrcPrntDualOutpObject
{
}

public interface ItestRefGnrcPrntDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcPrntDualOutpObject AsRefGnrcPrntDualOutp { get; set; }
}

public interface ItestRefGnrcPrntDualOutpObject<Tref>
{
}

public interface ItestAltGnrcPrntDualOutp
{
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualOutpObject AsAltGnrcPrntDualOutp { get; set; }
}

public interface ItestAltGnrcPrntDualOutpObject
{
  public decimal Alt { get; set; }
}
