//HintName: test_field-value-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Input;

public interface ItestFieldValueDescrInp
  // No Base because it's Class
{
  ItestFieldValueDescrInpObject? As_FieldValueDescrInp { get; }
}

public interface ItestFieldValueDescrInpObject
  // No Base because it's Class
{
  testEnumFieldValueDescrInp Field { get; }
}

public enum testEnumFieldValueDescrInp
{
  fieldValueDescrInp,
}
