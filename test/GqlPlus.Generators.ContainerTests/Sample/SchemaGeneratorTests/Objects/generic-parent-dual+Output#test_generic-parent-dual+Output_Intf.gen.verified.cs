//HintName: test_generic-parent-dual+Output_Intf.gen.cs
// Generated from generic-parent-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public interface ItestGnrcPrntDualOutp
  : ItestRefGnrcPrntDualOutp
{
  ItestGnrcPrntDualOutpObject AsGnrcPrntDualOutp { get; }
}

public interface ItestGnrcPrntDualOutpObject
  : ItestRefGnrcPrntDualOutpObject
{
}

public interface ItestRefGnrcPrntDualOutp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcPrntDualOutpObject AsRefGnrcPrntDualOutp { get; }
}

public interface ItestRefGnrcPrntDualOutpObject<Tref>
{
}

public interface ItestAltGnrcPrntDualOutp
{
  string AsString { get; }
  ItestAltGnrcPrntDualOutpObject AsAltGnrcPrntDualOutp { get; }
}

public interface ItestAltGnrcPrntDualOutpObject
{
  decimal Alt { get; }
}
