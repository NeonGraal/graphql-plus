//HintName: test_field-enum-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

public interface ItestFieldEnumPrntDual
  // No Base because it's Class
{
  ItestFieldEnumPrntDualObject? As_FieldEnumPrntDual { get; }
}

public interface ItestFieldEnumPrntDualObject
  // No Base because it's Class
{
  testEnumFieldEnumPrntDual Field { get; }
}

public enum testEnumFieldEnumPrntDual
{
  prnt_fieldEnumPrntDual = testPrntFieldEnumPrntDual.prnt_fieldEnumPrntDual,
  fieldEnumPrntDual,
}

public enum testPrntFieldEnumPrntDual
{
  prnt_fieldEnumPrntDual,
}
