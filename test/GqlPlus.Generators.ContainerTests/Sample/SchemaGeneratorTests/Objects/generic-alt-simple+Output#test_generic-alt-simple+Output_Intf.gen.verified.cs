//HintName: test_generic-alt-simple+Output_Intf.gen.cs
// Generated from generic-alt-simple+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public interface ItestGnrcAltSmplOutp
{
  public ItestRefGnrcAltSmplOutp<ItestString> AsRefGnrcAltSmplOutp { get; set; }
  public ItestGnrcAltSmplOutpObject AsGnrcAltSmplOutp { get; set; }
}

public interface ItestGnrcAltSmplOutpObject
{
}

public interface ItestRefGnrcAltSmplOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltSmplOutpObject AsRefGnrcAltSmplOutp { get; set; }
}

public interface ItestRefGnrcAltSmplOutpObject<Tref>
{
}
