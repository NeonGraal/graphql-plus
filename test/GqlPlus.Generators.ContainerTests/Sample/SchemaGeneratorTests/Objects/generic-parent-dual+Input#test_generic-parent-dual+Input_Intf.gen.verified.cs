//HintName: test_generic-parent-dual+Input_Intf.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public interface ItestGnrcPrntDualInp
  : ItestRefGnrcPrntDualInp<ItestAltGnrcPrntDualInp>
{
  ItestGnrcPrntDualInpObject AsGnrcPrntDualInp { get; }
}

public interface ItestGnrcPrntDualInpObject
  : ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>
{
}

public interface ItestRefGnrcPrntDualInp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcPrntDualInpObject AsRefGnrcPrntDualInp { get; }
}

public interface ItestRefGnrcPrntDualInpObject<TRef>
{
}

public interface ItestAltGnrcPrntDualInp
{
  string AsString { get; }
  ItestAltGnrcPrntDualInpObject AsAltGnrcPrntDualInp { get; }
}

public interface ItestAltGnrcPrntDualInpObject
{
  decimal Alt { get; }
}
