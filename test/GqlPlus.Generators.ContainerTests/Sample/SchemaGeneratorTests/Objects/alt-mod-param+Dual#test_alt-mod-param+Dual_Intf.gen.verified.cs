//HintName: test_alt-mod-param+Dual_Intf.gen.cs
// Generated from alt-mod-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public interface ItestAltModParamDual<Tmod>
{
  public IDictionary<Tmod, ItestAltAltModParamDual> AsAltAltModParamDual { get; set; }
}

public interface ItestAltModParamDualObject<Tmod>
{
}

public interface ItestAltAltModParamDual
{
  public ItestString AsString { get; set; }
}

public interface ItestAltAltModParamDualObject
{
  public ItestNumber Alt { get; set; }
}
