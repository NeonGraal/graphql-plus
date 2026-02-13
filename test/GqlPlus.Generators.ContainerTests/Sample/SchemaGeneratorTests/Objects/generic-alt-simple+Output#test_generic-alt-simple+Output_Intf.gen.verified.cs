//HintName: test_generic-alt-simple+Output_Intf.gen.cs
// Generated from generic-alt-simple+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public interface ItestGnrcAltSmplOutp
{
  ItestRefGnrcAltSmplOutp<string> AsRefGnrcAltSmplOutp { get; }
  ItestGnrcAltSmplOutpObject AsGnrcAltSmplOutp { get; }
}

public interface ItestGnrcAltSmplOutpObject
{
}

public interface ItestRefGnrcAltSmplOutp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltSmplOutpObject<TRef> AsRefGnrcAltSmplOutp { get; }
}

public interface ItestRefGnrcAltSmplOutpObject<TRef>
{
}
