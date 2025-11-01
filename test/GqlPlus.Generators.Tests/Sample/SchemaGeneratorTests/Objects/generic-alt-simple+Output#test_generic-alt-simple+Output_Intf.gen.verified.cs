//HintName: test_generic-alt-simple+Output_Intf.gen.cs
// Generated from generic-alt-simple+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public interface ItestGnrcAltSmplOutp
{
  public testRefGnrcAltSmplOutp<testString> AsRefGnrcAltSmplOutp { get; set; }
  public testGnrcAltSmplOutp GnrcAltSmplOutp { get; set; }
}

public interface ItestGnrcAltSmplOutpField
{
}

public interface ItestRefGnrcAltSmplOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltSmplOutp RefGnrcAltSmplOutp { get; set; }
}

public interface ItestRefGnrcAltSmplOutpField<Tref>
{
}
