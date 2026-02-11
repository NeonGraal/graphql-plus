//HintName: test_generic-alt-dual+Output_Intf.gen.cs
// Generated from generic-alt-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public interface ItestGnrcAltDualOutp
{
  ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; }
  ItestGnrcAltDualOutpObject AsGnrcAltDualOutp { get; }
}

public interface ItestGnrcAltDualOutpObject
{
}

public interface ItestRefGnrcAltDualOutp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltDualOutpObject AsRefGnrcAltDualOutp { get; }
}

public interface ItestRefGnrcAltDualOutpObject<TRef>
{
}

public interface ItestAltGnrcAltDualOutp
{
  string AsString { get; }
  ItestAltGnrcAltDualOutpObject AsAltGnrcAltDualOutp { get; }
}

public interface ItestAltGnrcAltDualOutpObject
{
  decimal Alt { get; }
}
