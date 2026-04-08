//HintName: test_field-value+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Dual;

public interface ItestFieldValueDual
  // No Base because it's Class
{
  ItestFieldValueDualObject? As_FieldValueDual { get; }
}

public interface ItestFieldValueDualObject
  // No Base because it's Class
{
  testEnumFieldValueDual Field { get; }
}

public enum testEnumFieldValueDual
{
  fieldValueDual,
}
