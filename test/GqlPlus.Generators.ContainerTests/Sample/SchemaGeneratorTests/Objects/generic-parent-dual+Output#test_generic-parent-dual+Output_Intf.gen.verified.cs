//HintName: test_generic-parent-dual+Output_Intf.gen.cs
// Generated from generic-parent-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public interface ItestGnrcPrntDualOutp
  : ItestRefGnrcPrntDualOutp
{
}

public interface ItestGnrcPrntDualOutpObject
  : ItestRefGnrcPrntDualOutpObject
{
}

public interface ItestRefGnrcPrntDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcPrntDualOutpObject<Tref>
{
}

public interface ItestAltGnrcPrntDualOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestAltGnrcPrntDualOutpObject
{
  public ItestNumber Alt { get; set; }
}
