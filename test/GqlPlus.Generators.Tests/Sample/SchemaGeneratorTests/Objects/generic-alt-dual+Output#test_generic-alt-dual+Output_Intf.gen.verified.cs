//HintName: test_generic-alt-dual+Output_Intf.gen.cs
// Generated from generic-alt-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public interface ItestGnrcAltDualOutp
{
  public testRefGnrcAltDualOutp<testAltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; set; }
  public testGnrcAltDualOutp GnrcAltDualOutp { get; set; }
}

public interface ItestGnrcAltDualOutpField
{
}

public interface ItestRefGnrcAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltDualOutp RefGnrcAltDualOutp { get; set; }
}

public interface ItestRefGnrcAltDualOutpField<Tref>
{
}

public interface ItestAltGnrcAltDualOutp
{
  public testString AsString { get; set; }
  public testAltGnrcAltDualOutp AltGnrcAltDualOutp { get; set; }
}

public interface ItestAltGnrcAltDualOutpField
{
  public testNumber alt { get; set; }
}
