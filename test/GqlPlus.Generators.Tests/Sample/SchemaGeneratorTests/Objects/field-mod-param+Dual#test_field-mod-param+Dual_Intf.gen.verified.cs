//HintName: test_field-mod-param+Dual_Intf.gen.cs
// Generated from field-mod-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public interface ItestFieldModParamDual<Tmod>
{
  public testFieldModParamDual FieldModParamDual { get; set; }
}

public interface ItestFieldModParamDualField<Tmod>
{
  public IDictionary<Tmod, testFldFieldModParamDual> field { get; set; }
}

public interface ItestFldFieldModParamDual
{
  public testString AsString { get; set; }
  public testFldFieldModParamDual FldFieldModParamDual { get; set; }
}

public interface ItestFldFieldModParamDualField
{
  public testNumber field { get; set; }
}
