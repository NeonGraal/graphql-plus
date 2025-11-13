//HintName: test_alt-mod-param+Dual_Intf.gen.cs
// Generated from alt-mod-param+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public interface ItestAltModParamDual<Tmod>
{
  public IDictionary<Tmod, testAltAltModParamDual> AsAltAltModParamDual { get; set; }
  public testAltModParamDual AltModParamDual { get; set; }
}

public interface ItestAltModParamDualField<Tmod>
{
}

public interface ItestAltAltModParamDual
{
  public testString AsString { get; set; }
  public testAltAltModParamDual AltAltModParamDual { get; set; }
}

public interface ItestAltAltModParamDualField
{
  public testNumber alt { get; set; }
}
