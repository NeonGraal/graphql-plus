//HintName: test_generic-alt-arg+Output_Intf.gen.cs
// Generated from generic-alt-arg+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public interface ItestGnrcAltArgOutp<Ttype>
{
  ItestRefGnrcAltArgOutp<Ttype> AsRefGnrcAltArgOutp { get; }
  ItestGnrcAltArgOutpObject AsGnrcAltArgOutp { get; }
}

public interface ItestGnrcAltArgOutpObject<Ttype>
{
}

public interface ItestRefGnrcAltArgOutp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcAltArgOutpObject AsRefGnrcAltArgOutp { get; }
}

public interface ItestRefGnrcAltArgOutpObject<Tref>
{
}
