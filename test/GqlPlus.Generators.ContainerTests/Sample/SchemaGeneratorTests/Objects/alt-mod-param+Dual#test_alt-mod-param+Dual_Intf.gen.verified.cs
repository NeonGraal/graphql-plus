//HintName: test_alt-mod-param+Dual_Intf.gen.cs
// Generated from alt-mod-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public interface ItestAltModParamDual<Tmod>
{
  public IDictionary<Tmod, ItestAltAltModParamDual> AsAltAltModParamDual { get; set; }
  public ItestAltModParamDualObject AsAltModParamDual { get; set; }
}

public interface ItestAltModParamDualObject<Tmod>
{
}

public interface ItestAltAltModParamDual
{
  public string AsString { get; set; }
  public ItestAltAltModParamDualObject AsAltAltModParamDual { get; set; }
}

public interface ItestAltAltModParamDualObject
{
  public decimal Alt { get; set; }
}
