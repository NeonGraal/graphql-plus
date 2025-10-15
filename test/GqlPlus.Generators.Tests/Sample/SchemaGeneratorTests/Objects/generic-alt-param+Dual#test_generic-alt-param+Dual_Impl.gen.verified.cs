//HintName: test_generic-alt-param+Dual_Impl.gen.cs
// Generated from generic-alt-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public class DualtestGnrcAltParamDual
  : ItestGnrcAltParamDual
{
  public RefGnrcAltParamDual<AltGnrcAltParamDual> AsRefGnrcAltParamDual { get; set; }
}

public class DualtestRefGnrcAltParamDual<Tref>
  : ItestRefGnrcAltParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public class DualtestAltGnrcAltParamDual
  : ItestAltGnrcAltParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
