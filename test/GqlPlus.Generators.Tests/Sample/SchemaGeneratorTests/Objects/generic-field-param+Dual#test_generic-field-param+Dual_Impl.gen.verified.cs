//HintName: test_generic-field-param+Dual_Impl.gen.cs
// Generated from generic-field-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public class testGnrcFieldParamDual
  : ItestGnrcFieldParamDual
{
  public RefGnrcFieldParamDual<AltGnrcFieldParamDual> field { get; set; }
}

public class testRefGnrcFieldParamDual<Tref>
  : ItestRefGnrcFieldParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcFieldParamDual
  : ItestAltGnrcFieldParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
