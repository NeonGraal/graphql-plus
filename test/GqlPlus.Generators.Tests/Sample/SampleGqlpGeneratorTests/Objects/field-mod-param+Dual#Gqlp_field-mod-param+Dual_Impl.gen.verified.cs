//HintName: Gqlp_field-mod-param+Dual_Impl.gen.cs
// Generated from field-mod-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_field_mod_param_Dual;
public class DualFieldModParamDual<Tmod>
  : IFieldModParamDual<Tmod>
{
  public FldFieldModParamDual field { get; set; }
}
public class DualFldFieldModParamDual
  : IFldFieldModParamDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
