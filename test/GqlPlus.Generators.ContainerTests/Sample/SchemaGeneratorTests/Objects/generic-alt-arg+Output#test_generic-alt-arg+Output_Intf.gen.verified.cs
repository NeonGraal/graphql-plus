//HintName: test_generic-alt-arg+Output_Intf.gen.cs
// Generated from generic-alt-arg+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public interface ItestGnrcAltArgOutp<Ttype>
{
  public ItestRefGnrcAltArgOutp<Ttype> AsRefGnrcAltArgOutp { get; set; }
  public ItestGnrcAltArgOutpObject AsGnrcAltArgOutp { get; set; }
}

public interface ItestGnrcAltArgOutpObject<Ttype>
{
}

public interface ItestRefGnrcAltArgOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltArgOutpObject AsRefGnrcAltArgOutp { get; set; }
}

public interface ItestRefGnrcAltArgOutpObject<Tref>
{
}
