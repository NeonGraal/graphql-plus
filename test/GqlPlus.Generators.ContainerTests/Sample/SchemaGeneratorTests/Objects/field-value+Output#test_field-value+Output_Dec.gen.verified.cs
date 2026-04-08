//HintName: test_field-value+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Output;

public interface ItestFieldValueOutp
  // No Base because it's Class
{
  ItestFieldValueOutpObject? As_FieldValueOutp { get; }
}

public interface ItestFieldValueOutpObject
  // No Base because it's Class
{
  testEnumFieldValueOutp Field { get; }
}

public enum testEnumFieldValueOutp
{
  fieldValueOutp,
}
