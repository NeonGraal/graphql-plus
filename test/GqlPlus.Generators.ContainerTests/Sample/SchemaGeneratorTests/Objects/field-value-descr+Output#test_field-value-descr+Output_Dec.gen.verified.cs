//HintName: test_field-value-descr+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Output;

public interface ItestFieldValueDescrOutp
  // No Base because it's Class
{
  ItestFieldValueDescrOutpObject? As_FieldValueDescrOutp { get; }
}

public interface ItestFieldValueDescrOutpObject
  // No Base because it's Class
{
  testEnumFieldValueDescrOutp Field { get; }
}

public enum testEnumFieldValueDescrOutp
{
  fieldValueDescrOutp,
}
