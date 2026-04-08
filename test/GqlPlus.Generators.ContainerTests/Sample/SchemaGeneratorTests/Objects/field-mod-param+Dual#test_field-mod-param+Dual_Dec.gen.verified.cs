//HintName: test_field-mod-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public interface ItestFieldModParamDual<TMod>
  // No Base because it's Class
{
  ItestFieldModParamDualObject<TMod>? As_FieldModParamDual { get; }
}

public interface ItestFieldModParamDualObject<TMod>
  // No Base because it's Class
{
  IDictionary<TMod, ItestFldFieldModParamDual> Field { get; }
}

public interface ItestFldFieldModParamDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestFldFieldModParamDualObject? As_FldFieldModParamDual { get; }
}

public interface ItestFldFieldModParamDualObject
  // No Base because it's Class
{
  decimal Field { get; }
}
