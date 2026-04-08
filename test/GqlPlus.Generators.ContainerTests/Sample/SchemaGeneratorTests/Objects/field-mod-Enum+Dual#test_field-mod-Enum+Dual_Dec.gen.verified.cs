//HintName: test_field-mod-Enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Dual;

public interface ItestFieldModEnumDual
  // No Base because it's Class
{
  ItestFieldModEnumDualObject? As_FieldModEnumDual { get; }
}

public interface ItestFieldModEnumDualObject
  // No Base because it's Class
{
  IDictionary<testEnumFieldModEnumDual, string> Field { get; }
}

public enum testEnumFieldModEnumDual
{
  value,
}
