//HintName: test_generic-alt-simple+Output_Impl.gen.cs
// Generated from generic-alt-simple+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public class OutputtestGnrcAltSmplOutp
  : ItestGnrcAltSmplOutp
{
  public RefGnrcAltSmplOutp<String> AsRefGnrcAltSmplOutp { get; set; }
}

public class OutputtestRefGnrcAltSmplOutp<Tref>
  : ItestRefGnrcAltSmplOutp<Tref>
{
  public Tref Asref { get; set; }
}
