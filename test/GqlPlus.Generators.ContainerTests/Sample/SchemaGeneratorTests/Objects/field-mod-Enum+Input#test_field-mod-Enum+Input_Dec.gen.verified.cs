//HintName: test_field-mod-Enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Input;

public interface ItestFieldModEnumInp
  // No Base because it's Class
{
  ItestFieldModEnumInpObject? As_FieldModEnumInp { get; }
}

public interface ItestFieldModEnumInpObject
  // No Base because it's Class
{
  IDictionary<testEnumFieldModEnumInp, string> Field { get; }
}

public enum testEnumFieldModEnumInp
{
  value,
}
