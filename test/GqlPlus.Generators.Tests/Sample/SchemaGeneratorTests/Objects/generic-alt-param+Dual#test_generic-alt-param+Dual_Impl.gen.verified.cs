//HintName: test_generic-alt-param+Dual_Impl.gen.cs
// Generated from generic-alt-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public class testGnrcAltParamDual
  : ItestGnrcAltParamDual
{
  public RefGnrcAltParamDual<AltGnrcAltParamDual> AsRefGnrcAltParamDual { get; set; }
}

public class testRefGnrcAltParamDual<Tref>
  : ItestRefGnrcAltParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcAltParamDual
  : ItestAltGnrcAltParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
