//HintName: test_alt-mod-Boolean+Output_Intf.gen.cs
// Generated from alt-mod-Boolean+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

public interface ItestAltModBoolOutp
{
  IDictionary<bool, ItestAltAltModBoolOutp> AsAltAltModBoolOutp { get; }
  ItestAltModBoolOutpObject AsAltModBoolOutp { get; }
}

public interface ItestAltModBoolOutpObject
{
}

public interface ItestAltAltModBoolOutp
{
  string AsString { get; }
  ItestAltAltModBoolOutpObject AsAltAltModBoolOutp { get; }
}

public interface ItestAltAltModBoolOutpObject
{
  decimal Alt { get; }
}
