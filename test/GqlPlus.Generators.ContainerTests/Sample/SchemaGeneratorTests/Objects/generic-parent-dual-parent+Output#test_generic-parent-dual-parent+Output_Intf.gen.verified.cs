//HintName: test_generic-parent-dual-parent+Output_Intf.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public interface ItestGnrcPrntDualPrntOutp
  : ItestRefGnrcPrntDualPrntOutp
{
  ItestGnrcPrntDualPrntOutpObject AsGnrcPrntDualPrntOutp { get; }
}

public interface ItestGnrcPrntDualPrntOutpObject
  : ItestRefGnrcPrntDualPrntOutpObject
{
}

public interface ItestRefGnrcPrntDualPrntOutp<Tref>
  : Itestref
{
  ItestRefGnrcPrntDualPrntOutpObject AsRefGnrcPrntDualPrntOutp { get; }
}

public interface ItestRefGnrcPrntDualPrntOutpObject<Tref>
  : ItestrefObject
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
