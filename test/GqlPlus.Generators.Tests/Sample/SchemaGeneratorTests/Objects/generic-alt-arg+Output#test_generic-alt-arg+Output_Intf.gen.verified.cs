//HintName: test_generic-alt-arg+Output_Intf.gen.cs
// Generated from generic-alt-arg+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public interface ItestGnrcAltArgOutp<Ttype>
{
  RefGnrcAltArgOutp<Ttype> AsRefGnrcAltArgOutp { get; }
}

public interface ItestRefGnrcAltArgOutp<Tref>
{
  Tref Asref { get; }
}
