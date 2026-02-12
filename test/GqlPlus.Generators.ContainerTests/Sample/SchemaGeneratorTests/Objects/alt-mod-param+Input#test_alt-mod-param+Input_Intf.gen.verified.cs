//HintName: test_alt-mod-param+Input_Intf.gen.cs
// Generated from alt-mod-param+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

public interface ItestAltModParamInp<TMod>
{
  IDictionary<TMod, ItestAltAltModParamInp> AsAltAltModParamInp { get; }
  ItestAltModParamInpObject<TMod> AsAltModParamInp { get; }
}

public interface ItestAltModParamInpObject<TMod>
{
}

public interface ItestAltAltModParamInp
{
  string AsString { get; }
  ItestAltAltModParamInpObject AsAltAltModParamInp { get; }
}

public interface ItestAltAltModParamInpObject
{
  decimal Alt { get; }
}
