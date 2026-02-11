//HintName: test_alt-mod-param+Output_Intf.gen.cs
// Generated from alt-mod-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public interface ItestAltModParamOutp<TMod>
{
  IDictionary<TMod, ItestAltAltModParamOutp> AsAltAltModParamOutp { get; }
  ItestAltModParamOutpObject AsAltModParamOutp { get; }
}

public interface ItestAltModParamOutpObject<TMod>
{
}

public interface ItestAltAltModParamOutp
{
  string AsString { get; }
  ItestAltAltModParamOutpObject AsAltAltModParamOutp { get; }
}

public interface ItestAltAltModParamOutpObject
{
  decimal Alt { get; }
}
