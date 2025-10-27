//HintName: test_field-mod-param+Dual_Impl.gen.cs
// Generated from field-mod-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public class testFieldModParamDual<Tmod>
  : ItestFieldModParamDual<Tmod>
{
  public FldFieldModParamDual field { get; set; }
}

public class testFldFieldModParamDual
  : ItestFldFieldModParamDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
