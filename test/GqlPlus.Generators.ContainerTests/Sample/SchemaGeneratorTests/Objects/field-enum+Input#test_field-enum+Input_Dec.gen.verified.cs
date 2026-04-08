//HintName: test_field-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Input;

public interface ItestFieldEnumInp
  // No Base because it's Class
{
  ItestFieldEnumInpObject? As_FieldEnumInp { get; }
}

public interface ItestFieldEnumInpObject
  // No Base because it's Class
{
  testEnumFieldEnumInp Field { get; }
}

public enum testEnumFieldEnumInp
{
  fieldEnumInp,
}
