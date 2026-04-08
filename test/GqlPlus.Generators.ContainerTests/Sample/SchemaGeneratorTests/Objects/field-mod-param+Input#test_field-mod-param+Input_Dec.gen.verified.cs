//HintName: test_field-mod-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public interface ItestFieldModParamInp<TMod>
  // No Base because it's Class
{
  ItestFieldModParamInpObject<TMod>? As_FieldModParamInp { get; }
}

public interface ItestFieldModParamInpObject<TMod>
  // No Base because it's Class
{
  IDictionary<TMod, ItestFldFieldModParamInp> Field { get; }
}

public interface ItestFldFieldModParamInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestFldFieldModParamInpObject? As_FldFieldModParamInp { get; }
}

public interface ItestFldFieldModParamInpObject
  // No Base because it's Class
{
  decimal Field { get; }
}
