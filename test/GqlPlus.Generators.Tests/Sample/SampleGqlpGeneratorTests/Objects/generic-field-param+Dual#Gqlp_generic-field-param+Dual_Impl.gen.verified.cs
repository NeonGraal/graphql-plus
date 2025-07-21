//HintName: Gqlp_generic-field-param+Dual_Impl.gen.cs
// Generated from generic-field-param+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_param_Dual;
public class DualGnrcFieldParamDual
  : IGnrcFieldParamDual
{
  public RefGnrcFieldParamDual<AltGnrcFieldParamDual> field { get; set; }
}
public class DualRefGnrcFieldParamDual<Tref>
  : IRefGnrcFieldParamDual<Tref>
{
  public Tref Asref { get; set; }
}
public class DualAltGnrcFieldParamDual
  : IAltGnrcFieldParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
