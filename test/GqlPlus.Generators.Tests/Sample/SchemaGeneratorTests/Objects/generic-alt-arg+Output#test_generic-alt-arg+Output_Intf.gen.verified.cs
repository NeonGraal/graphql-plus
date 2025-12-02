//HintName: test_generic-alt-arg+Output_Intf.gen.cs
// Generated from generic-alt-arg+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public interface ItestGnrcAltArgOutp<Ttype>
{
  public testRefGnrcAltArgOutp<Ttype> AsRefGnrcAltArgOutp { get; set; }
  public testGnrcAltArgOutp GnrcAltArgOutp { get; set; }
}

public interface ItestGnrcAltArgOutpField<Ttype>
{
}

public interface ItestRefGnrcAltArgOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltArgOutp RefGnrcAltArgOutp { get; set; }
}

public interface ItestRefGnrcAltArgOutpField<Tref>
{
}
