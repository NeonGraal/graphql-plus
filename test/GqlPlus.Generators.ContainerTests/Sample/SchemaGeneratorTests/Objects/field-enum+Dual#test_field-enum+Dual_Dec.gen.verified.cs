//HintName: test_field-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Dual;

public interface ItestFieldEnumDual
  // No Base because it's Class
{
  ItestFieldEnumDualObject? As_FieldEnumDual { get; }
}

public interface ItestFieldEnumDualObject
  // No Base because it's Class
{
  testEnumFieldEnumDual Field { get; }
}

public enum testEnumFieldEnumDual
{
  fieldEnumDual,
}
