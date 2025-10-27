//HintName: test_generic-alt-simple+Output_Intf.gen.cs
// Generated from generic-alt-simple+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public interface ItestGnrcAltSmplOutp
{
  RefGnrcAltSmplOutp<String> AsRefGnrcAltSmplOutp { get; }
}

public interface ItestRefGnrcAltSmplOutp<Tref>
{
  Tref Asref { get; }
}
