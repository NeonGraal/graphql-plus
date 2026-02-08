//HintName: test_field-mod-param+Dual_Intf.gen.cs
// Generated from field-mod-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public interface ItestFieldModParamDual<Tmod>
{
}

public interface ItestFieldModParamDualObject<Tmod>
{
  public IDictionary<Tmod, ItestFldFieldModParamDual> Field { get; set; }
}

public interface ItestFldFieldModParamDual
{
  public ItestString AsString { get; set; }
}

public interface ItestFldFieldModParamDualObject
{
  public ItestNumber Field { get; set; }
}
