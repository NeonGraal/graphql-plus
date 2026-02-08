//HintName: test_field-mod-param+Dual_Impl.gen.cs
// Generated from field-mod-param+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public class testFieldModParamDual<Tmod>
  : ItestFieldModParamDual<Tmod>
{
  public IDictionary<Tmod, ItestFldFieldModParamDual> Field { get; set; }
  public ItestFieldModParamDualObject AsFieldModParamDual { get; set; }
}

public class testFldFieldModParamDual
  : ItestFldFieldModParamDual
{
  public ItestNumber Field { get; set; }
  public ItestString AsString { get; set; }
  public ItestFldFieldModParamDualObject AsFldFieldModParamDual { get; set; }
}
