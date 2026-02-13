//HintName: test_field-mod-param+Dual_Intf.gen.cs
// Generated from field-mod-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public interface ItestFieldModParamDual<TMod>
{
  ItestFieldModParamDualObject<TMod> AsFieldModParamDual { get; }
}

public interface ItestFieldModParamDualObject<TMod>
{
  IDictionary<TMod, ItestFldFieldModParamDual> Field { get; }
}

public interface ItestFldFieldModParamDual
{
  string AsString { get; }
  ItestFldFieldModParamDualObject AsFldFieldModParamDual { get; }
}

public interface ItestFldFieldModParamDualObject
{
  decimal Field { get; }
}
