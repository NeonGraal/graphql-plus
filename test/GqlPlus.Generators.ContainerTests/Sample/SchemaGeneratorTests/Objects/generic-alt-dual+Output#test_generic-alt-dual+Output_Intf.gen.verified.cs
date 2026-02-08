//HintName: test_generic-alt-dual+Output_Intf.gen.cs
// Generated from generic-alt-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public interface ItestGnrcAltDualOutp
{
  public ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; set; }
  public ItestGnrcAltDualOutpObject AsGnrcAltDualOutp { get; set; }
}

public interface ItestGnrcAltDualOutpObject
{
}

public interface ItestRefGnrcAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltDualOutpObject AsRefGnrcAltDualOutp { get; set; }
}

public interface ItestRefGnrcAltDualOutpObject<Tref>
{
}

public interface ItestAltGnrcAltDualOutp
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcAltDualOutpObject AsAltGnrcAltDualOutp { get; set; }
}

public interface ItestAltGnrcAltDualOutpObject
{
  public ItestNumber Alt { get; set; }
}
