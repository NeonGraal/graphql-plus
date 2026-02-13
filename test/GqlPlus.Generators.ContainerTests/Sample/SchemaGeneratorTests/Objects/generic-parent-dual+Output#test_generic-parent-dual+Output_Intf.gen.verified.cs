//HintName: test_generic-parent-dual+Output_Intf.gen.cs
// Generated from generic-parent-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public interface ItestGnrcPrntDualOutp
  : ItestRefGnrcPrntDualOutp<ItestAltGnrcPrntDualOutp>
{
  ItestGnrcPrntDualOutpObject AsGnrcPrntDualOutp { get; }
}

public interface ItestGnrcPrntDualOutpObject
  : ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>
{
}

public interface ItestRefGnrcPrntDualOutp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcPrntDualOutpObject<TRef> AsRefGnrcPrntDualOutp { get; }
}

public interface ItestRefGnrcPrntDualOutpObject<TRef>
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
