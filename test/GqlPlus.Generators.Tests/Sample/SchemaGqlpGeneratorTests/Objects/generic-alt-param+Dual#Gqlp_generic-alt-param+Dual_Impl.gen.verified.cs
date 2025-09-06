//HintName: Gqlp_generic-alt-param+Dual_Impl.gen.cs
// Generated from generic-alt-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_param_Dual;

public class DualGnrcAltParamDual
  : IGnrcAltParamDual
{
  public RefGnrcAltParamDual<AltGnrcAltParamDual> AsRefGnrcAltParamDual { get; set; }
}

public class DualRefGnrcAltParamDual<Tref>
  : IRefGnrcAltParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public class DualAltGnrcAltParamDual
  : IAltGnrcAltParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
