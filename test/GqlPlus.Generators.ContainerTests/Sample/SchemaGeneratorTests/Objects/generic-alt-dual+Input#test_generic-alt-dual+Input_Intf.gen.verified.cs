//HintName: test_generic-alt-dual+Input_Intf.gen.cs
// Generated from generic-alt-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public interface ItestGnrcAltDualInp
{
  ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp> AsRefGnrcAltDualInp { get; }
  ItestGnrcAltDualInpObject AsGnrcAltDualInp { get; }
}

public interface ItestGnrcAltDualInpObject
{
}

public interface ItestRefGnrcAltDualInp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltDualInpObject AsRefGnrcAltDualInp { get; }
}

public interface ItestRefGnrcAltDualInpObject<TRef>
{
}

public interface ItestAltGnrcAltDualInp
{
  string AsString { get; }
  ItestAltGnrcAltDualInpObject AsAltGnrcAltDualInp { get; }
}

public interface ItestAltGnrcAltDualInpObject
{
  decimal Alt { get; }
}
