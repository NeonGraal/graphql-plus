//HintName: test_field-mod-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public interface ItestFieldModParamOutp<TMod>
  // No Base because it's Class
{
  ItestFieldModParamOutpObject<TMod>? As_FieldModParamOutp { get; }
}

public interface ItestFieldModParamOutpObject<TMod>
  // No Base because it's Class
{
  IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; }
}

public interface ItestFldFieldModParamOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestFldFieldModParamOutpObject? As_FldFieldModParamOutp { get; }
}

public interface ItestFldFieldModParamOutpObject
  // No Base because it's Class
{
  decimal Field { get; }
}
