//HintName: test_field-mod-param+Dual_Impl.gen.cs
// Generated from field-mod-param+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public class testFieldModParamDual<Tmod>
  : ItestFieldModParamDual<Tmod>
{
  public IDictionary<Tmod, testFldFieldModParamDual> field { get; set; }
  public testFieldModParamDual FieldModParamDual { get; set; }
}

public class testFldFieldModParamDual
  : ItestFldFieldModParamDual
{
  public testNumber field { get; set; }
  public testString AsString { get; set; }
  public testFldFieldModParamDual FldFieldModParamDual { get; set; }
}
