//HintName: test_generic-parent-dual-parent+Input_Intf.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public interface ItestGnrcPrntDualPrntInp
  : ItestRefGnrcPrntDualPrntInp
{
  ItestGnrcPrntDualPrntInpObject AsGnrcPrntDualPrntInp { get; }
}

public interface ItestGnrcPrntDualPrntInpObject
  : ItestRefGnrcPrntDualPrntInpObject
{
}

public interface ItestRefGnrcPrntDualPrntInp<Tref>
  : Itestref
{
  ItestRefGnrcPrntDualPrntInpObject AsRefGnrcPrntDualPrntInp { get; }
}

public interface ItestRefGnrcPrntDualPrntInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntDualPrntInp
{
  string AsString { get; }
  ItestAltGnrcPrntDualPrntInpObject AsAltGnrcPrntDualPrntInp { get; }
}

public interface ItestAltGnrcPrntDualPrntInpObject
{
  decimal Alt { get; }
}
