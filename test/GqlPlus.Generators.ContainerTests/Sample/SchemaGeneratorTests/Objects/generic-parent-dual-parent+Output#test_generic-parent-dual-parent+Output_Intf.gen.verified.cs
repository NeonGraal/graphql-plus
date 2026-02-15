//HintName: test_generic-parent-dual-parent+Output_Intf.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public interface ItestGnrcPrntDualPrntOutp
  : ItestRefGnrcPrntDualPrntOutp<ItestAltGnrcPrntDualPrntOutp>
{
  ItestGnrcPrntDualPrntOutpObject AsGnrcPrntDualPrntOutp { get; }
}

public interface ItestGnrcPrntDualPrntOutpObject
  : ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>
{
}

public interface ItestRefGnrcPrntDualPrntOutp<TRef>
{
  TRef AsParent { get; }
  ItestRefGnrcPrntDualPrntOutpObject<TRef> AsRefGnrcPrntDualPrntOutp { get; }
}

public interface ItestRefGnrcPrntDualPrntOutpObject<TRef>
{
}

public interface ItestAltGnrcPrntDualPrntOutp
{
  string AsString { get; }
  ItestAltGnrcPrntDualPrntOutpObject AsAltGnrcPrntDualPrntOutp { get; }
}

public interface ItestAltGnrcPrntDualPrntOutpObject
{
  decimal Alt { get; }
}
