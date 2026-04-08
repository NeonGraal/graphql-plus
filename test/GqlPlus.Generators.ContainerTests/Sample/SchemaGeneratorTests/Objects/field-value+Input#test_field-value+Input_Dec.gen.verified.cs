//HintName: test_field-value+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Input;

public interface ItestFieldValueInp
  // No Base because it's Class
{
  ItestFieldValueInpObject? As_FieldValueInp { get; }
}

public interface ItestFieldValueInpObject
  // No Base because it's Class
{
  testEnumFieldValueInp Field { get; }
}

public enum testEnumFieldValueInp
{
  fieldValueInp,
}
