//HintName: test_input-field-Enum_Dec.gen.cs
// Generated from {CurrentDirectory}input-field-Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Enum;

public interface ItestInpFieldEnum
  // No Base because it's Class
{
  ItestInpFieldEnumObject? As_InpFieldEnum { get; }
}

public interface ItestInpFieldEnumObject
  // No Base because it's Class
{
  testEnumInpFieldEnum Field { get; }
}

public enum testEnumInpFieldEnum
{
  inpFieldEnum,
}
