//HintName: test_alt-mod-param+Output_Intf.gen.cs
// Generated from alt-mod-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

public interface ItestAltModParamOutp<Tmod>
{
  IDictionary<Tmod, ItestAltAltModParamOutp> AsAltAltModParamOutp { get; }
  ItestAltModParamOutpObject AsAltModParamOutp { get; }
}

public interface ItestAltModParamOutpObject<Tmod>
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
