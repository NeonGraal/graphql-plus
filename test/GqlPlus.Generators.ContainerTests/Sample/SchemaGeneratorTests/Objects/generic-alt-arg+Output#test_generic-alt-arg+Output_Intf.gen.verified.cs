//HintName: test_generic-alt-arg+Output_Intf.gen.cs
// Generated from generic-alt-arg+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public interface ItestGnrcAltArgOutp<TType>
{
  ItestRefGnrcAltArgOutp<TType> AsRefGnrcAltArgOutp { get; }
  ItestGnrcAltArgOutpObject<TType> AsGnrcAltArgOutp { get; }
}

public interface ItestGnrcAltArgOutpObject<TType>
{
}

public interface ItestRefGnrcAltArgOutp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltArgOutpObject<TRef> AsRefGnrcAltArgOutp { get; }
}

public interface ItestRefGnrcAltArgOutpObject<TRef>
{
}
