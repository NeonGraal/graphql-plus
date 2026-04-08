//HintName: test_field-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Dual;

public class testFieldEnumDual
  : GqlpEncoderBase
  , ItestFieldEnumDual
{
  public ItestFieldEnumDualObject? As_FieldEnumDual { get; set; }
}

public class testFieldEnumDualObject
  : GqlpEncoderBase
  , ItestFieldEnumDualObject
{
  public testEnumFieldEnumDual Field { get; set; }

  public testFieldEnumDualObject
    ( testEnumFieldEnumDual field
    )
  {
    Field = field;
  }
}

public enum testEnumFieldEnumDual
{
  fieldEnumDual,
}
