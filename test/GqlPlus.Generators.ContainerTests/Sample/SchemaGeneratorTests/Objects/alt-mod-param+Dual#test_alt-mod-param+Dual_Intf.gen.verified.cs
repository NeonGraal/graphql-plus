//HintName: test_alt-mod-param+Dual_Intf.gen.cs
// Generated from alt-mod-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public interface ItestAltModParamDual<Tmod>
{
  IDictionary<Tmod, ItestAltAltModParamDual> AsAltAltModParamDual { get; }
  ItestAltModParamDualObject AsAltModParamDual { get; }
}

public interface ItestAltModParamDualObject<Tmod>
{
}

public interface ItestAltAltModParamDual
{
  string AsString { get; }
  ItestAltAltModParamDualObject AsAltAltModParamDual { get; }
}

public interface ItestAltAltModParamDualObject
{
  decimal Alt { get; }
}
