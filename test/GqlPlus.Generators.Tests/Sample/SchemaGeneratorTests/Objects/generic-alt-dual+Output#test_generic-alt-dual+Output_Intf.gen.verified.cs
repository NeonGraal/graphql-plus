//HintName: test_generic-alt-dual+Output_Intf.gen.cs
// Generated from generic-alt-dual+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public interface ItestGnrcAltDualOutp
{
  RefGnrcAltDualOutp<AltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; }
}

public interface ItestRefGnrcAltDualOutp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcAltDualOutp
{
  Number alt { get; }
  String AsString { get; }
}
