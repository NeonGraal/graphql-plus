//HintName: test_alt-mod-param+Dual_Impl.gen.cs
// Generated from alt-mod-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

public class DualtestAltModParamDual<Tmod>
  : ItestAltModParamDual<Tmod>
{
  public AltAltModParamDual AsAltAltModParamDual { get; set; }
}

public class DualtestAltAltModParamDual
  : ItestAltAltModParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
