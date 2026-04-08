//HintName: test_field-mod-Enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Output;

public interface ItestFieldModEnumOutp
  // No Base because it's Class
{
  ItestFieldModEnumOutpObject? As_FieldModEnumOutp { get; }
}

public interface ItestFieldModEnumOutpObject
  // No Base because it's Class
{
  IDictionary<testEnumFieldModEnumOutp, string> Field { get; }
}

public enum testEnumFieldModEnumOutp
{
  value,
}
