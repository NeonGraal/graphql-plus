//HintName: test_field-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Output;

public interface ItestFieldEnumOutp
  // No Base because it's Class
{
  ItestFieldEnumOutpObject? As_FieldEnumOutp { get; }
}

public interface ItestFieldEnumOutpObject
  // No Base because it's Class
{
  testEnumFieldEnumOutp Field { get; }
}

public enum testEnumFieldEnumOutp
{
  fieldEnumOutp,
}
